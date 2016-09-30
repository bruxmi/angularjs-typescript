# Use the Update-SolutionScripts cmdlet after changes
function global:Update-Databases() {
	Update-Application-Database
	Update-Tenant-Database
	#Update-TestApplication-Database
	#Update-TestTenant-Database
	Write-Host "Update-Databases done."	
}