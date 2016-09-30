# Use the Update-SolutionScripts cmdlet after changes
function global:Update-Hangfire-Database() {
	Write-Host "Updating Hangfire Database."		
	Create-Database -Database "KPMG.DE.Traction.Debug.Hangfire"
}