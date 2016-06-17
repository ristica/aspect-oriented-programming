using System.Reflection;
using System.Runtime.InteropServices;
using AOPSampleApp.Aspects;

[assembly: AssemblyTitle("AOPSampleApp")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("DB")]
[assembly: AssemblyProduct("AOPSampleApp")]
[assembly: AssemblyCopyright("Copyright © DB 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("223686cd-7907-4ef2-8169-f69daca5985c")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]





/******************************************************/
// attach DataContract and DataMemebr aspects
[assembly: DataContractAspect(AttributeTargetTypes = "AOPSampleApp.DataContracts.*")]
