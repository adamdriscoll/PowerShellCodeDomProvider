#
# Expectations.ps1
#

#region Classes

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

$MethodWithParameters = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
param(
[System.Int32]$parameter1,
[System.String]$parameter2
)
}
Export-ModuleMember -Function Start
}
}

#endregion

#region Methods

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

$InvokeMethodWithParameters = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$dateTime = New-Object -TypeName DateTime
$dateTime.AddMinutes(1)
}
Export-ModuleMember -Function Start
}
}

#endregion

#region Instantiation

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

$ArrayInitialization = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$array = @(1,2,3)
}
Export-ModuleMember -Function Start
}
}

#endregion

#region Properties

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

$GetProperty = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
$obj = New-Object -TypeName System.Net.IPAddress
$address = $obj.Address
}
Export-ModuleMember -Function Start
}
}

#endregion

#region Conditions

$IfElseStatement = {
$MyClass = New-Module -AsCustomObject -Name MyClass -ScriptBlock {
function Start
{
if ($true)
{
$obj = New-Object -TypeName System.Object
}
else
{
$obj2 = New-Object -TypeName System.Object
}
}
Export-ModuleMember -Function Start
}
}

#endregion