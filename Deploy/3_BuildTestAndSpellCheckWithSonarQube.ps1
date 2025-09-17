. "C:\Work\MagusCharacterGenerator\Deploy\Utils.ps1"

Set-Location "C:\Work\MagusCharacterGenerator"
#InstallDotnetToolIfNeeded -toolName "dotnet-sonarscanner"

### Start Sonar ###
#Write-Host "Starting Sonar...";
#Start-Process -FilePath E:\sonarqube-10.4.0.87286\bin\windows-x86-64\StartSonar.bat -NoNewWindow

### Sonar scan start ###
Write-Host "Starting Sonar Scan...";
dotnet sonarscanner begin /k:"MagusCharacterGenerator" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_GENERATE_ONE" /d:"sonar.cs.vscoveragexml.reportsPaths=**/coverage.xml" /d:sonar.sonarQubeAnalysisConfigPath="C:\Work\MagusCharacterGenerator\.sonarqube\conf\SonarQubeAnalysisConfig.xml" /d:sonar.scanner.scanAll=false
### Build ###
#dotnet build
#$apkPath = "C:\Work\MagusCharacterGenerator\Deploy\BuildAndGenerateApk.ps1"
dotnet publish "C:\Work\MagusCharacterGenerator\MagusCharacterGenerator.sln" -c Release -f net8.0-android /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB


#C:\Work\MagusCharacterGenerator\Deploy\GenerateTestReport.ps1

### Sonar scan end ###
dotnet sonarscanner end /d:sonar.token="sqp_GENERATE_ONE"

#.\SpellCheck.ps1

start http://localhost:9000/dashboard?id=MagusCharacterGenerator
# login: admin
# password: admin

return $apkPath