#
# Expectations.ps1
#

$Class = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
}
}

$PrivateMethod = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
}
}
}

$PublicMethod = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
}
Export-ModuleMember -Function Start
}
}

$InstantiateObject = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$obj = New-Object -TypeName System.Object
}
Export-ModuleMember -Function Start
}
}

$InstantiateObjectWithParameters = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$obj = New-Object -TypeName System.Object -ArgumentList @($someVariable)
}
Export-ModuleMember -Function Start
}
}

$InvokeMethod = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$obj = New-Object -TypeName System.Object
$obj.ToString()
}
Export-ModuleMember -Function Start
}
}

$ArrayInitialization = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$array = @(1,2,3)
}
Export-ModuleMember -Function Start
}
}

$SetProperty = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$obj = New-Object -TypeName System.Net.IPAddress
$obj.Address = 1234
}
Export-ModuleMember -Function Start
}
}