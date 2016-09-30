Import-Module sqlps -DisableNameChecking
# Use the Update-SolutionScripts cmdlet after changes
function global:Create-Database() {
	Param(
		[Parameter(Mandatory=$True)]
		[string]$Database,
		
		[Parameter(Mandatory=$False)]
		[string]$FilePath,

		[Parameter(Mandatory=$False)]
		[string]$Server
	)
	
	if(!$FilePath) {
		$FilePath = $env:USERPROFILE
	}
	if(!$Server) {
		$Server = "(localdb)\ProjectsV12"
	}
	
	Write-Host "Creating database '$($Database)'."
	
	# Creating SQL from template
	$CreateDatabaseSqlTemplate = "$($PSScriptRoot)\CreateDatabase.sql"
	$CreateDatabaseSql = (Get-Content $CreateDatabaseSqlTemplate).replace("@DATABASE", $Database).replace("@FILE_PATH", $FilePath)
	
	# Writing SQL to temporary file
	$CreateDatabaseSqlFile= "$([System.IO.Path]::GetTempFileName())"
	$CreateDatabaseSql = $CreateDatabaseSql | Set-Content $CreateDatabaseSqlFile
	
	# Executing SQL located in temporary file
	Invoke-Sqlcmd -ServerInstance $Server -InputFile $CreateDatabaseSqlFile

	# Deleting temporary file
	Remove-Item $CreateDatabaseSqlFile
}