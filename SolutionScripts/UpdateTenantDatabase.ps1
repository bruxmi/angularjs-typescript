# Use the Update-SolutionScripts cmdlet after changes
function global:Update-Tenant-Database() {
	Write-Host "Updating Tenant Database."		
	Update-Database -ConnectionStringName WebApiTypeScriptContext -ProjectName WebApiTypeScript.Data.AppContext -StartUpProjectName WebApiTypeScript.Data.AppContext
}