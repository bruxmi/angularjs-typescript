# Use the Update-SolutionScripts cmdlet after changes
function global:Update-TestTenant-Database() {
	Write-Host "Updating Test Tenant Database."		
	Update-Database -ConnectionStringName WebApiTypeScriptContext -ProjectName WebApiTypeScript.Data.AppContext -StartUpProjectName WebApiTypeScript.IntegrationTest
}