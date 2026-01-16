# This file can be set to unchangeable
# git update-index --assume-unchanged 4_UploadToFtpServer.ps1
# git update-index --no-assume-unchanged 4_UploadToFtpServer.ps1

. "$PSScriptRoot\Config.ps1"

Param([string] $apkPath)

$ftpServer = "server.us/web/mortens"
$ftpUsername = "xxxxxxxxxxxxx"
$ftpPassword = "************"

function UploadFilesToDestinationDirectory($filesToCopy, $destinationDirectory, $credentials)
{
    try
    {
        $webClient = New-Object System.Net.WebClient
        $webClient.Credentials = $credentials

        foreach ($file in $filesToCopy)
        {
            $uri = New-Object System.Uri("$destinationDirectory/$($file.Name)")
            Write-Host "Uploading $($file.Name)..."
            $webClient.UploadFile($uri, $file.FullName)
        }

        $webClient.Dispose()
    }
    catch
    {
        Write-Error "Error: $_"
        Exit 1
    }

    Write-Host "Upload complete."
}

#Write-Host "Connecting to: $($ftpServer) with user $($ftpUsername)" #and pass $($ftpPassword)"

$credentials = New-Object System.Net.NetworkCredential($ftpUsername, $ftpPassword)

UploadFilesToDestinationDirectory @($apkPath) "$($ftpServer)" $credentials

$images = @() # Get-ChildItem -Path ".\$Project\Resources\Images"
UploadFilesToDestinationDirectory $images "$($ftpServer)/Images" $credentials