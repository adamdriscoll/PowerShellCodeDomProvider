# PowerShell CodeDOM Provider

A CodeDOM provider for PowerShell. This enables the conversion between other languages such as C# and VB.NET. CodeDOM providers are kind of obsolete due to the introduction of Roslyn but are necessary for things like the Windows Forms editor. This project may be used in future versions of PowerShell Tools for Visual Studio. 
<p/>

Projects like <a href="https://github.com/icsharpcode/NRefactory">NRefactory</a> can create CodeCompileUnits from C# or VB.NET code. Once a CodeCompileUnit has been created, the PowerShell CodeDOM Provider can convert it to PowerShell script. 
<p/>
For example:
<p/>
<img src="http://i.imgur.com/CtBZKxZ.png"/>
<p/>
To 
<p/>
<img src="http://i.imgur.com/XT3saNg.png"/>
<p/>
The PowerShell CodeDOM provider is also capable of parsing a PowerShell script and returning a CodeCompileUnit so conversion between PowerShell to C# or VB.NET can take place. 
<p/>
