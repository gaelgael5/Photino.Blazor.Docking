using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;

namespace Photino.Blazor.Docking.Sample;

public static class IocHelper
{

    /// <summary>
    /// Load assemblies that reference the ExposeClassAttribute attribute
    /// </summary>
    /// <param name="failedOnloadError">if true, the method will return false if an error occurs during loading</param>
    /// <returns>return false if item are fail to loading</returns>
    public static bool LoadAssemblies(bool failedOnloadError)
    {

        var o = new AddonsResolver(AssemblyDirectoryResolver.Instance)
             .WithFile(c => !c.InSystemDirectory())
             .WithReference(typeof(ExposeClassAttribute))
             .WhereAssembly(c => !c.IsSdk())
             .SearchListReferences(typeof(Program).Assembly)
             .ToList()
             ;

        var result = o.LoadAssemblies(failedOnloadError);

        return result;

    }

}

