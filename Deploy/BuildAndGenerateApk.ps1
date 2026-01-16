. "$PSScriptRoot\Config.ps1"

Write-Host "Cleaning...";
if (Test-Path $PublishOutputDirectory) {
    Remove-Item -Path "$PublishOutputDirectory\*" -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host ".NET Publishing...";
Set-Location $SolutionRoot
Write-Host "$SolutionRoot"
Write-Host ".NET Publishing project: $CsprojFull ..."

#dotnet publish $CsprojFull -c Release -f $framework /p:AndroidPackageFormat=apk
dotnet publish $CsprojFull -c Release -f $framework /p:AndroidPackageFormat=aab #/p:BundleLocalization=hu-HU /p:LocalizationCulture=hu-HU
#dotnet publish $SolutionFull -c Release -f $framework /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB

Write-Host "Searching generated APK..."

if (-not (Test-Path -Path $PublishOutputDirectory))
{
    Write-Host "Not found: $PublishOutputDirectory";
	$PublishOutputDirectory = Get-Location
    Write-Host "Changing to: $PublishOutputDirectory";
}

$apkPath = Get-ChildItem -Path "$PublishOutputDirectory\*-Signed.apk" | Select-Object -ExpandProperty FullName

Write-Host "APK generated at: $apkPath"
return $apkPath