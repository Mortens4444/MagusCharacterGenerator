<#
.SYNOPSIS
    Installs the MAGUS.Assistant Debug or Release APK onto a phone over Wi-Fi ADB, then launches it.

.PARAMETER Configuration
    Debug or Release. Defaults to Debug.

.PARAMETER AdbTarget
    The phone's wireless-debugging address, e.g. 192.168.50.181:33181.
    Find it on the phone under Settings > Developer options > Wireless debugging.
    If omitted, the script reuses the last address that worked and falls back to
    whatever device adb already sees connected.

.PARAMETER Build
    Rebuild the app for Android before installing. Without this switch, the script
    just installs whatever *-Signed.apk was last built for the chosen configuration.

.EXAMPLE
    .\DeployApkOverWifi.ps1
    Installs the newest Debug APK to the last-used (or already-connected) device.

.EXAMPLE
    .\DeployApkOverWifi.ps1 -AdbTarget 192.168.50.181:33181 -Configuration Release -Build
    Connects to that address, rebuilds Release, then installs and launches it.
#>
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Debug',

    [string]$AdbTarget,

    [switch]$Build
)

$ErrorActionPreference = 'Stop'
. "$PSScriptRoot\Deploy\Config.ps1"

$cacheFile = "$PSScriptRoot\Deploy\.last-adb-target.txt"

function Get-ConnectedDevice
{
    $lines = adb devices | Select-Object -Skip 1 | Where-Object { $_.Trim() -ne '' }
    $online = $lines | Where-Object { $_ -match '\bdevice$' } | ForEach-Object { ($_ -split '\s+')[0] }
    return $online
}

# 1) Make sure a device is reachable over Wi-Fi.
if ($AdbTarget)
{
    Write-Host "Connecting to $AdbTarget ..."
    adb connect $AdbTarget | Out-Null
}
elseif (Test-Path $cacheFile)
{
    $lastTarget = (Get-Content $cacheFile -Raw).Trim()
    if ($lastTarget)
    {
        Write-Host "Trying last-known address $lastTarget ..."
        adb connect $lastTarget 2>&1 | Out-Null
    }
}

$devices = @(Get-ConnectedDevice)
if ($devices.Count -eq 0)
{
    Write-Error @"
No adb device is connected.
On the phone: Settings > Developer options > Wireless debugging, read the IP:port shown
there, then re-run with -AdbTarget <ip:port> (pair first with 'adb pair' if this is a new
network/device).
"@
    exit 1
}

if ($devices.Count -gt 1 -and -not $AdbTarget)
{
    Write-Warning "Multiple devices connected, using the first one. Pass -AdbTarget to pick a specific one:"
    $devices | ForEach-Object { Write-Host "  $_" }
}

$target = $devices[0]
Set-Content -Path $cacheFile -Value $target -ErrorAction SilentlyContinue
Write-Host "Using device: $target"

# 2) Optionally rebuild.
if ($Build)
{
    Write-Host "Building ($Configuration) for Android..."
    Set-Location $SolutionRoot
    dotnet build $CsprojFull -f $framework -c $Configuration
    if ($LASTEXITCODE -ne 0)
    {
        Write-Error "Build failed."
        exit $LASTEXITCODE
    }
}

# 3) Find the newest signed APK for the requested configuration.
$searchRoots = @(
    "$SolutionRoot\$Project\bin\$Configuration\$framework",
    "$SolutionRoot\$Project\bin\$Configuration\$framework\publish"
) | Where-Object { Test-Path $_ }

$apk = $searchRoots |
    ForEach-Object { Get-ChildItem -Path $_ -Filter '*-Signed.apk' -ErrorAction SilentlyContinue } |
    Sort-Object LastWriteTime -Descending |
    Select-Object -First 1

if (-not $apk)
{
    Write-Error "No *-Signed.apk found for $Configuration under $($searchRoots -join ', '). Re-run with -Build."
    exit 1
}

Write-Host "Installing $($apk.FullName) ..."
adb -s $target install -r $apk.FullName
if ($LASTEXITCODE -ne 0)
{
    Write-Error "adb install failed."
    exit $LASTEXITCODE
}

# 4) Launch the app.
$manifestContent = Get-Content $ManifestFull -Raw
$appId = if ($manifestContent -match 'package="([^"]+)"') { $Matches[1] } else { $null }

if ($appId)
{
    Write-Host "Launching $appId ..."
    adb -s $target shell monkey -p $appId -c android.intent.category.LAUNCHER 1 | Out-Null
}

Write-Host "Done."
