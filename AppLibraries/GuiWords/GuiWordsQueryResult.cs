using System.Collections.Generic;

namespace TRW.AppLibraries.GuiWords
{
    public class GuiWordsQueryResult
    {
        public GuiWordsQueryResult()
        {
            ResultRows = new List<GuiWordsRowMatch>();
            Success = false;
        }
        
        public List<GuiWordsRowMatch> ResultRows { get; set; }
        public bool Success { get; set; }
        public string SearchedForm { get; private set; }

        public void Reset()
        {
            ResultRows.Clear();
            Success = false;
            SearchedForm = string.Empty;
        }

        public void RunSearchLatin(GuiWordsTable table, string searchedForm)
        {
            Reset();

            SearchedForm = searchedForm;
            foreach (GuiWordsRow matchedRow in table.SearchLatinWord(searchedForm))
                ResultRows.Add(new GuiWordsRowMatch(matchedRow));

            if (ResultRows.Count > 0)
                Success = true;
        }

        public void RunSearchEnglish(GuiWordsTable table, string searchedWord)
        {
            Reset();

            foreach (GuiWordsRow matchedRow in table.SearchEnglishWord(searchedWord))
                ResultRows.Add(new GuiWordsRowMatch(matchedRow));

            if (ResultRows.Count > 0)
                Success = true;
        }

        public void GetAllForms(GuiWordsTable table, int dictionaryId)
        {
            Reset();
            if(table.Seek(table._dictionaryIdIndex, dictionaryId))
            {
                do
                {
                    ResultRows.Add(new GuiWordsRowMatch(table.Current));
                } while (table.SeekNext(table._dictionaryIdIndex, dictionaryId));
            }

            if (ResultRows.Count > 0)
                Success = true;
        }
    }
}
