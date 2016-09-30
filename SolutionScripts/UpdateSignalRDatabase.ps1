# Use the Update-SolutionScripts cmdlet after changes
function global:Update-SignalR-Database() {
	Write-Host "Updating SignalR Database."		
	Create-Database -Database "KPMG.DE.Traction.Debug.SignalR"
}