//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------
// <auto-generatedInfo>
// 	This code was generated by ResW File Code Generator (http://reswcodegen.codeplex.com)
// 	ResW File Code Generator was written by Christian Resma Helle
// 	and is under GNU General Public License version 2 (GPLv2)
// 
// 	This code contains a helper class exposing property representations
// 	of the string resources defined in the specified .ResW file
// 
// 	Generated: 12/09/2013 12:34:22
// </auto-generatedInfo>
// --------------------------------------------------------------------------------------------------
namespace Subsonic8
{
    using Windows.ApplicationModel.Resources;
    
    
    public partial class LastFmCredentials
    {
        
        private static ResourceLoader resourceLoader;
        
        static LastFmCredentials()
        {
            string executingAssemblyName;
            executingAssemblyName = Windows.UI.Xaml.Application.Current.GetType().AssemblyQualifiedName;
            string[] executingAssemblySplit;
            executingAssemblySplit = executingAssemblyName.Split(',');
            executingAssemblyName = executingAssemblySplit[1];
            string currentAssemblyName;
            currentAssemblyName = typeof(LastFmCredentials).AssemblyQualifiedName;
            string[] currentAssemblySplit;
            currentAssemblySplit = currentAssemblyName.Split(',');
            currentAssemblyName = currentAssemblySplit[1];
            if (executingAssemblyName.Equals(currentAssemblyName))
            {
                resourceLoader = new ResourceLoader("LastFmCredentials");
            }
            else
            {
                resourceLoader = new ResourceLoader(currentAssemblyName + "/LastFmCredentials");
            }
        }
        
        /// <summary>
        /// Localized resource similar to "fillIn"
        /// </summary>
        public static string ApiKey
        {
            get
            {
                return resourceLoader.GetString("ApiKey");
            }
        }
    }
}