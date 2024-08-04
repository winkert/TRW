using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TRW.AppLibraries.GuiWords.Test
{
    [TestClass]
    public class GuiWordsAllFormsTests : UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void TestGetAllForms()
        {
            GuiWordsTable table = MockGuiWordsTable();
            GuiWordsFormsCollection forms = table.GetAllForms(1, PartsOfSpeech.Verb);


        }


        private GuiWordsTable MockGuiWordsTable()
        {
            GuiWordsTable table = new GuiWordsTable();

            #region amo
            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amat";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.ThirdPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amas";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amo";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amamus";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amatis";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amant";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabat";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.ThirdPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabas";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabam";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabamus";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabatis";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryId = 1;
            table.DictionaryWord = "amo";
            table.Form = "amabant";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Imperfect;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";
            #endregion

            #region Iuppiter
            table.Add();
            table.DictionaryId = 2;
            table.DictionaryWord = "Iuppiter";
            table.Form = "Iovis";
            table.NumberId = (short)Numbers.Singular;
            table.ConjugationId = (short)Conjugations.ThirdConjugation_Common;
            table.CaseId = (short)Cases.Genitive;
            table.GenderId = (short)Genders.Masculine;
            table.Meaning = "Jupiter, the king of the gods";

            table.Add();
            table.DictionaryId = 2;
            table.DictionaryWord = "Iuppiter";
            table.Form = "Iovi";
            table.NumberId = (short)Numbers.Singular;
            table.ConjugationId = (short)Conjugations.ThirdConjugation_Common;
            table.CaseId = (short)Cases.Dative;
            table.GenderId = (short)Genders.Masculine;
            table.Meaning = "Jupiter, the king of the gods";
            #endregion

            return table;
        }
    }
}
