. "$PSScriptRoot\Config.ps1"

$xml = [xml](Get-Content $CsprojFull)
$fileVersionPropertyGroup = $xml.Project.PropertyGroup | Where-Object { $_.FileVersion }

git add .
git commit -m "Deployed version: $($xml.Project.PropertyGroup.MajorVersion).$($xml.Project.PropertyGroup.MinorVersion)$($fileVersionPropertyGroup.BuildNumber)"
git push origin main