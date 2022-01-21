using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Carfup.XTBPlugins.PCF2BPF
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "PCF 2 BPF"),
        ExportMetadata("Description", "Integrate PCF into your BPF in few clicks !"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", null),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAABoAAAAaCAYAAACpSkzOAAAA+ElEQVRIS+2WwRWCMAyGkwl0EPFivesGjgAb4CR0A3ACHcG7eLEOAgsYH48Hj5Y2DxDFA1wb8vGnIfkRmMdLwwMCxAC45OIAKCOAQAl5ccWh68C7hz4SxjxAPyWkQG1kYnvHChoCqZK7YC3QJxAOpoHKO8GzKZ0rievDXkT751Zeq1waaJ0eMwBYNEEcpIozYQRwUiLym3lMEPWFmDAbpIhhQQ8RObvS1lmrW7hrlquzor4g7lcYVdEMqisw39HcDP/fDINHUJfJ3R6qlCghA7MxvrQm2rBpFl8h9yer3LUxx3BC09qtWllpVgqfpvkIi8KcgHzOQL4BdZXSG1R5vR0AAAAASUVORK5CYII="),
       ExportMetadata("BigImageBase64", "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"),
       ExportMetadata("BackgroundColor", "DarkGreen"),
       ExportMetadata("PrimaryFontColor", "White"),
       ExportMetadata("SecondaryFontColor", "LimeGreen")]
    public class Plugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PCF2BPF();
        }

      

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}