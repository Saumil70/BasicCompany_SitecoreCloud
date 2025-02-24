using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCompany.Feature.Navigation.Models
{
    public class LanguageSelectorModel
    {
        [SitecoreComponentField]
        public SupportedLanguage[] SupportedLanguages { get; set; }
    }

    public class SupportedLanguage
    {
        public string Name { get; set; }            
        public string NativeName { get; set; } 
        public string Url { get; set; }       
        public string TwoLetterCode { get; set; }  
        public bool IsSelected { get; set; }
    }
}
