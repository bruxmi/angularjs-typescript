# Use the Update-SolutionScripts cmdlet after changes
function global:Add-Tenant-Migration() {
	Param(
		[Parameter(Mandatory=$True)]
		[string]$Name
	)
	
	Write-Host "Adding Tenant Migration."		
	Add-Migration $Name -ConnectionStringName WebApiTypeScriptContext -ProjectName WebApiTypeScript.Data.AppContext -StartUpProjectName WebApiTypeScript.Data.AppContext 
}