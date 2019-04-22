#powershell -ExecutionPolicy ByPass -File '.\extract.ps1'
#https://github.com/arkeet/oggextract

dir . -filter "*.rwfile" -Recurse -name | % {
	$command = ".\oggextract.exe "".\$_"""
	iex $command
}