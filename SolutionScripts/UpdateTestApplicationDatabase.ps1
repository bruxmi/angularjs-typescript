# Use the Update-SolutionScripts cmdlet after changes
function global:Update-TestApplication-Database() {
	Write-Host "Updating Test Application Database."		
	Update-Database -ConnectionStringName AppSettingContext -ProjectName WebApiTypeScript.Data.ApplicationSettingsContext -StartUpProjectName WebApiTypeScript.IntegrationTest
}