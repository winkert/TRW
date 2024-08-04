using System;

namespace MobileWords.Models
{
    public class QueryResult
    {
        public string Id { get; set; }
        public string DictionaryWord { get; set; }
        public string Form { get; set; }
        public string Definition { get; set; }
        public string ShortDefinition
        {
            get
            {
                return Definition.Substring(0, Definition.IndexOf(';'));
            }
        }
        public string Parsing { get; set; }
        public TRW.AppLibraries.GuiWords.PartsOfSpeech PartOfSpeech { get; set; }

        public string FormParsing
        {
            get
            {
                return $"{Form} - {Parsing}";
            }
        }

        public int DictionaryId { get; set; }

        public string GetAllFormsString()
        {
            TRW.AppLibraries.GuiWords.GuiWordsFormsCollection forms;
            
            forms = App.Table.GetAllForms(DictionaryId, PartOfSpeech);

            return forms.ToString();
        }
    }
}