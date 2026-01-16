. "$PSScriptRoot\Config.ps1"

function Update-CsprojVersion {
    $xml = [xml](Get-Content $CsprojFull)

    $majorVersionNode = $xml.SelectSingleNode("//PropertyGroup/MajorVersion")
    $minorVersionNode = $xml.SelectSingleNode("//PropertyGroup/MinorVersion")

    if ($majorVersionNode -and $minorVersionNode)
    {
        try
        {
            Write-Host "Current MajorVersion: $($majorVersionNode.InnerText)"
            Write-Host "Current MinorVersion: $($minorVersionNode.InnerText)"

            $minorVersion = [Convert]::ToInt32($minorVersionNode.InnerText) + 1
            $minorVersionNode.InnerText = $minorVersion

            $xml.Save($CsprojFull)
            Write-Host "MinorVersion updated to $($minorVersionNode) in .csproj file."
        }
        catch
        {
            Write-Host "Error updating .csproj version: $_"
        }
    }
    else
    {
        Write-Host "Error: MajorVersion or MinorVersion not found in the .csproj file."
    }
}

function Update-ManifestVersion {
    $manifestXml = [xml](Get-Content $ManifestFull)

    if ($manifestXml.manifest.attributes["android:versionCode"])
    {
        try
        {
            $currentVersionCode = [Convert]::ToInt32($manifestXml.manifest.attributes["android:versionCode"].value)
            $newVersionCode = $currentVersionCode + 1
            $manifestXml.manifest.attributes["android:versionCode"].value = $newVersionCode
            $manifestXml.Save($ManifestFull)

            Write-Host "VersionCode updated to $newVersionCode in AndroidManifest.xml."
        }
        catch
        {
            Write-Host "Error updating AndroidManifest.xml versionCode: $_"
        }
    }
    else
    {
        Write-Host "Error: versionCode attribute not found in AndroidManifest.xml."
    }
}

Update-CsprojVersion
Update-ManifestVersion
