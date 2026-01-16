. "$PSScriptRoot\Config.ps1"
. "$PSScriptRoot\Utils.ps1"

Set-Location $SolutionRoot
#InstallDotnetToolIfNeeded -toolName "dotnet-sonarscanner"

### Start Sonar ###
#Write-Host "Starting Sonar...";
#Start-Process -FilePath E:\sonarqube-10.4.0.87286\bin\windows-x86-64\StartSonar.bat -NoNewWindow

### Sonar scan start ###
Write-Host "Starting Sonar Scan...";
dotnet sonarscanner begin /k:"$Project" /d:sonar.host.url="$SonarHost" /d:sonar.token="$SonarToken" /d:"sonar.cs.vscoveragexml.reportsPaths=**/coverage.xml" /d:sonar.sonarQubeAnalysisConfigPath="$SolutionRoot\.sonarqube\conf\SonarQubeAnalysisConfig.xml" /d:sonar.scanner.scanAll=false
### Build ###
#dotnet build
#$apkPath = "$PSScriptRoot\BuildAndGenerateApk.ps1"
dotnet publish $SolutionFull -c Release -f $framework /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB

#$PSScriptRoot\GenerateTestReport.ps1

### Sonar scan end ###
dotnet sonarscanner end /d:sonar.token="$SonarToken"

#.\SpellCheck.ps1

#start http://localhost:9000/dashboard?id=JUHI_Pulse
start "$SonarHost/dashboard?id=$SonarProjectKey"

# login: admin
# password: admin

return $apkPath