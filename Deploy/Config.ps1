# ==== GLOBAL CONFIG FOR DEPLOY SCRIPTS ====

# Base folders
$Solution = "MagusCharacterGenerator"
$SolutionRoot = "F:\Work\$Solution"
$Project = "M.A.G.U.S.Assistant"

# Project paths
$CsprojRelative = "..\$Project\$Project.csproj"
$ManifestRelative = "..\$Project\Platforms\Android\AndroidManifest.xml"

# Absolute paths
$SolutionFull = Join-Path $SolutionRoot "$Solution.sln"
$CsprojFull = Join-Path $SolutionRoot "$Project\$Project.csproj"
$ManifestFull = Join-Path $SolutionRoot "$Project\Platforms\Android\AndroidManifest.xml"

# SonarQube
$SonarHost = "http://localhost:9000"
$SonarProjectKey = $Project -replace ' ', '_'
$SonarToken = "sqp_GENERATE_ONE"
$SonarConfigPath = "$SolutionRoot\.sonarqube\conf\SonarQubeAnalysisConfig.xml"

# Build paths
$framework = "net10.0-android"
$PublishOutputDirectory = "$SolutionRoot\$Project\bin\Release\$framework\publish"

# Git
$GitBranch = "main"
