function InstallDotnetToolIfNeeded
{
    param ([string]$toolName)

    $toolList = dotnet tool list --global
    $toolInstalled = $toolList -like "*$toolName*"

    if (-not $toolInstalled)
    {
        Write-Host "Installing $toolName...";
        dotnet tool install $toolName --global
    }
    else
    {
        Write-Host "$toolName already installed, skipping installation.";
    }
}