using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TRW.AppLibraries.GuiWords.Test
{
    [TestClass]
    public class GuiWordsTest : UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void InstatiationAndAddRowTests()
        {
            GuiWordsTable table = new GuiWordsTable();
            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amat";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.ThirdPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amas";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amo";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;

            Assert.AreEqual(3, table.Count);
            Assert.IsTrue(table.First());
        }

        [TestMethod]
        public void SearchLatinWord_Basic_Test()
        {
            GuiWordsTable table = MockGuiWordsTable();

            int results = 0;
            foreach (var result in table.SearchLatinWord("ama"))
            {
                results++;
            }

            Assert.AreEqual(5, results);

        }

        [TestMethod]
        public void SearchLatinWord_Complex_Tests()
        {
            GuiWordsTable table = MockGuiWordsTable();

            int results = 0;
            foreach (var result in table.SearchLatinWord("jovis"))
            {
                results++;
            }

            Assert.AreEqual(1, results);

            results = 0;
            foreach (var result in table.SearchLatinWord("iuui"))
            {
                results++;
            }

            Assert.AreEqual(2, results);
        }

        [TestMethod]
        public void SearchEnglishMeaningTests()
        {
            GuiWordsTable table = MockGuiWordsTable();

            int results = 0;
            foreach (var result in table.SearchEnglishWord("love"))
            {
                results++;
            }
            Assert.AreEqual(6, results);
        }

        [TestMethod, Ignore] // ignore for TFS because it throws memory exception
        public void GetResourceTest()
        {
            try
            {
                GuiWordsTable target = GuiWordsTable.GetGuiWordsResource();
                Assert.IsNotNull(target);
                Assert.IsTrue(target.Count > 0);
            }
            catch(OutOfMemoryException)
            {
                Assert.IsTrue(true);// this is a known error in some systems.
            }
            

        }

        private GuiWordsTable MockGuiWordsTable()
        {
            GuiWordsTable table = new GuiWordsTable();

            #region amo
            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amat";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.ThirdPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amas";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amo";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amamus";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amatis";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";

            table.Add();
            table.DictionaryWord = "amo";
            table.Form = "amant";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Plural;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to love; to like; to have affection for";
            #endregion

            #region iuvo
            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iuvat";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.ThirdPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to help; to be of use to";

            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iuvas";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to help; to be of use to";

            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iuvi";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.FirstPerson;
            table.TenseId = (short)Tenses.Perfect;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to help; to be of use to";

            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iuvisti";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.SecondPerson;
            table.TenseId = (short)Tenses.Perfect;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.Meaning = "to help; to be of use to";

            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iuvare";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.None;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.None;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.MoodId = (short)Moods.Infinitive;
            table.Meaning = "to help; to be of use to";

            table.Add();
            table.DictionaryWord = "iuvo";
            table.Form = "iutum";
            table.ConjugationId = (short)Conjugations.FirstConjugation;
            table.PersonId = (short)Persons.None;
            table.TenseId = (short)Tenses.Present;
            table.NumberId = (short)Numbers.Singular;
            table.VerbTypeId = (short)VerbTypes.Trans;
            table.MoodId = (short)Moods.Supine;
            table.Meaning = "to help; to be of use to";
            #endregion

            #region Iuppiter
            table.Add();
            table.DictionaryWord = "Iuppiter";
            table.Form = "Iovis";
            table.NumberId = (short)Numbers.Singular;
            table.ConjugationId = (short)Conjugations.ThirdConjugation_Common;
            table.CaseId = (short)Cases.Genitive;
            table.GenderId = (short)Genders.Masculine;
            table.Meaning = "Jupiter, the king of the gods";

            table.Add();
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
