param(
    [string]$CsprojPath = "..\M.A.G.U.S.Assistant\M.A.G.U.S.Assistant.csproj",
    [string]$ManifestPath = "..\M.A.G.U.S.Assistant\Platforms\Android\AndroidManifest.xml"
)

$currentDirectory = "C:\Work\MagusCharacterGenerator\Deploy"
$csprojFullPath = [System.IO.Path]::Combine($currentDirectory, $CsprojPath)
$manifestFullPath = [System.IO.Path]::Combine($currentDirectory, $ManifestPath)

function Update-CsprojVersion {
    $xml = [xml](Get-Content $csprojFullPath)

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

            $xml.Save($csprojFullPath)
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
    $manifestXml = [xml](Get-Content $manifestFullPath)

    if ($manifestXml.manifest.attributes["android:versionCode"])
    {
        try
        {
            $currentVersionCode = [Convert]::ToInt32($manifestXml.manifest.attributes["android:versionCode"].value)
            $newVersionCode = $currentVersionCode + 1
            $manifestXml.manifest.attributes["android:versionCode"].value = $newVersionCode
            $manifestXml.Save($manifestFullPath)

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
