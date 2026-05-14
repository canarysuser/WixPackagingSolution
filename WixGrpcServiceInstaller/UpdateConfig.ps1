$sessionData=$env:CustomActionData

$values=@{} 

$sessioonData.Split(";") | ForEach-Object {
	$pair = $_.Split("=")
	$values[$pair[0]]=$pair[1]
}
$port =$values["PORT"]
$installDir=$values["INSTALLDIR"]

$configFile = Join-Path $installDir "appsettings.json"
$json = Get-Content $configFile -Raw | ConvertFrom-Json
$json.GrpcHttp2.Url="http://*:"+$port
$json | Convert-Json -Depth 10 | Set-Content $configFile 

