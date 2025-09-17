param(
    [string]$CsprojPath = "..\M.A.G.U.S.Assistant\M.A.G.U.S.Assistant.csproj"
)

$currentDirectory = Get-Location
$csprojFullPath = [System.IO.Path]::Combine($currentDirectory, $CsprojPath)
$xml = [xml](Get-Content $csprojFullPath)
$fileVersionPropertyGroup = $xml.Project.PropertyGroup | Where-Object { $_.FileVersion }

git add .
git commit -m "Deployed version: $($xml.Project.PropertyGroup.MajorVersion).$($xml.Project.PropertyGroup.MinorVersion)$($fileVersionPropertyGroup.BuildNumber)"
git push origin main