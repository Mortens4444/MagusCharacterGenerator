. "$PSScriptRoot\Config.ps1"
. "$PSScriptRoot\Utils.ps1"

Set-Location $SolutionRoot

### Install dependencies ###
InstallDotnetToolIfNeeded -toolName "dotnet-coverage"
InstallDotnetToolIfNeeded -toolName "dotnet-reportgenerator-globaltool"

### Coverage data for SonarQube ###
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"

### Report generation ###
Remove-Item -Path "coverage.xml"
dotnet test --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover #,cobertura
reportgenerator "-reports:**\coverage.opencover.xml" "-targetdir:.\TestReport" -reporttypes:Html_Dark "-title:Unit tests"

### Open test coverage report ###
Start-Process -FilePath "$SolutionRoot\TestReport\index.html" -Verb open