using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepL;

namespace TiaXmlGenerator.Helpers
{
    public class Transl
    {
        public Translator translator;
        public bool FreeChars;

        public Transl(string authkey)
        {
            translator = new Translator(authkey);
        }


        public async Task<List<string>> Translate(List<string> texts, string sourceLang, string targetLang)
        {
            List<string> result = new List<string>();
            foreach (string text in texts)
            {
                var translation = await translator.TranslateTextAsync(text, sourceLang, targetLang);
                result.Add(translation.Text);
            }
            return result;
        }


        public async Task<string> Translate(string text, string sourceLang, string targetLang)
        {        
            var translation = await translator.TranslateTextAsync(text, sourceLang, targetLang);
            
            return translation.Text;
        }


        public async Task<bool> CheckUsage()
        {
            var usage = await translator.GetUsageAsync();
            return FreeChars = (usage.Character.Count + 5000 < usage.Character.Limit) ?  false : true;
        }
    }
}
