using Serenity.Services;
using System.Collections.Generic;

namespace Serene.Sample1.Administration
{

    public class TranslationUpdateRequest : ServiceRequest
    {
        public string TargetLanguageID { get; set; }
        public Dictionary<string, string> Translations { get; set; }
    }
}