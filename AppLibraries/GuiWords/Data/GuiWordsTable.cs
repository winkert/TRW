using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using TRW.CommonLibraries.Data.Core;

namespace TRW.AppLibraries.GuiWords
{
    [Serializable]
    public class GuiWordsTable : CustomDataTableBase<GuiWordsRow>
    {
        #region Fields
        public const string FetchAllQuery = @"SELECT
	[d_ID],[d_Word],[d_Meaning],[s_ID],[wf_Form],[e_ID],[vc_ID],[vb_ID],[nc_ID],[nd_ID],[ge_ID],[vm_ID],[num_ID],[part_ID],[vp_ID],[vt_ID],[vv_ID], [wf_ID]
FROM [dbo].[tWordForms]";

        public static CustomDataColumn[] GuiWordsColumns = new CustomDataColumn[]
        {
            new CustomDataColumn("d_ID", DataType.Integer)
            , new CustomDataColumn("d_Word", DataType.String)
            , new CustomDataColumn("d_Meaning", DataType.String)
            , new CustomDataColumn("s_ID", DataType.Integer)
            , new CustomDataColumn("wf_Form", DataType.String)
            , new CustomDataColumn("e_ID", DataType.Integer)
            , new CustomDataColumn("vc_ID", DataType.SmallInt)
            , new CustomDataColumn("vb_ID", DataType.SmallInt)
            , new CustomDataColumn("nc_ID", DataType.SmallInt)
            , new CustomDataColumn("nd_ID", DataType.SmallInt)
            , new CustomDataColumn("ge_ID", DataType.SmallInt)
            , new CustomDataColumn("vm_ID", DataType.SmallInt)
            , new CustomDataColumn("num_ID", DataType.SmallInt)
            , new CustomDataColumn("part_ID", DataType.SmallInt)
            , new CustomDataColumn("vp_ID", DataType.SmallInt)
            , new CustomDataColumn("vt_ID", DataType.SmallInt)
            , new CustomDataColumn("vv_ID", DataType.SmallInt)
            , new CustomDataColumn("wf_ID", DataType.Integer)
        };

        internal CustomDataTableIndex<GuiWordsRow> _formIndex;
        internal CustomDataTableIndex<GuiWordsRow> _dictionaryIdIndex;
        internal CustomDataTableIndex<GuiWordsRow> _englishMeaningIndex;

        #endregion

        #region Constructors
        public GuiWordsTable()
            : base(GuiWordsColumns)
        {
            InitializeIndices();
        }

        protected GuiWordsTable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InitializeIndices();
        }

        internal GuiWordsTable(byte[] fileBytes)
            : this()
        {
            System.Diagnostics.Debug.WriteLine($"Opening Memory Stream at {DateTime.Now:t}. Stream Length: {fileBytes.Length}");
            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                stream.Position = 0;
                base.DeserializeFromFile(stream, true);
            }
            System.Diagnostics.Debug.WriteLine($"Closing Memory Stream at {DateTime.Now:t}. Stream Length: {fileBytes.Length}");
        }

        #endregion

        #region Properties
        public new GuiWordsRow Current => base.Current;

        public int DictionaryId { get { return Current.DictionaryId; } set { Current.DictionaryId = value; } }
        public string DictionaryWord { get { return Current.DictionaryWord; } set { Current.DictionaryWord = value; } }
        public string Meaning { get { return Current.Meaning; } set { Current.Meaning = value; } }
        public int StemId { get { return Current.StemId; } set { Current.StemId = value; } }
        public string Form { get { return Current.Form; } set { Current.Form = value; } }
        public int EndingId { get { return Current.EndingId; } set { Current.EndingId = value; } }
        public short ConjugationId { get { return Current.ConjugationId; } set { Current.ConjugationId = value; } }
        public short VerbTypeId { get { return Current.VerbTypeId; } set { Current.VerbTypeId = value; } }
        public short DeclensionId { get { return Current.DeclensionId; } set { Current.DeclensionId = value; } }
        public short AdjectiveTypeId { get { return Current.AdjectiveTypeId; } set { Current.AdjectiveTypeId = value; } }
        public short CaseId { get { return Current.CaseId; } set { Current.CaseId = value; } }
        public short GenderId { get { return Current.GenderId; } set { Current.GenderId = value; } }
        public short MoodId { get { return Current.MoodId; } set { Current.MoodId = value; } }
        public short NumberId { get { return Current.NumberId; } set { Current.NumberId = value; } }
        public short PartOfSpeechId { get { return Current.PartOfSpeechId; } set { Current.PartOfSpeechId = value; } }
        public short PersonId { get { return Current.PersonId; } set { Current.PersonId = value; } }
        public short TenseId { get { return Current.TenseId; } set { Current.TenseId = value; } }
        public short VoiceId { get { return Current.VoiceId; } set { Current.VoiceId = value; } }
        public int WordFormId { get { return Current.WordFormId; } set { Current.WordFormId = value; } }

        #endregion

        #region Publics
        /// <summary>
        /// Grabs the embedded resource
        /// </summary>
        /// <returns></returns>
        public static GuiWordsTable GetGuiWordsResource()
        {
            System.Diagnostics.Debug.WriteLine($"Attempting to get GuiWordsTable from DLL Resource at {DateTime.Now:t}");
            byte[] bytes = Properties.Resources.GuiWords;
            return new GuiWordsTable(bytes);
        }
        
        public int FetchAll()
        {
            throw new NotImplementedException();
            //return base.Fetch(_fetchAll);
        }

        public IEnumerable<GuiWordsRow> SearchLatinWord(string pattern)
        {
            // transform the inbound pattern to a wide regex for i/j u/v changes
            string regexPattern = System.Text.RegularExpressions.Regex.Replace(pattern, "i|j", "[ij]");
            regexPattern = System.Text.RegularExpressions.Regex.Replace(regexPattern, "u|v", "[uv]");
            // force the search to only match whole words ("amas" will not return "calamas" or "amasco")
            regexPattern = $"^{regexPattern}$";

            return base.ScanForMatch(_formIndex, regexPattern);
        }
        
        public IEnumerable<GuiWordsRow> SearchEnglishWord(string pattern)
        {
            return base.ScanForMatch(_englishMeaningIndex, pattern);
        }

        public GuiWordsFormsCollection GetAllForms(int dictionaryId, PartsOfSpeech partOfSpeech)
        {
            switch (partOfSpeech)
            {
                case PartsOfSpeech.Noun:
                case PartsOfSpeech.Pronoun:
                case PartsOfSpeech.Adjective:
                case PartsOfSpeech.Number:
                    return GetAllForms<Declension>(dictionaryId);
                case PartsOfSpeech.Verb:
                    return GetAllForms<Synopsis>(dictionaryId);
                case PartsOfSpeech.Adverb:
                case PartsOfSpeech.Conjunction:
                case PartsOfSpeech.Preposition:
                case PartsOfSpeech.Interjection:
                default:
                    return GetAllForms<GuiWordsForms>(dictionaryId);
            }
        }

        public T GetAllForms<T>(GuiWordsRow row)
            where T: GuiWordsFormsCollection
        {
            return GetAllForms<T>(row.DictionaryId);
        }

        public T GetAllForms<T>(int dictionaryId)
            where T: GuiWordsFormsCollection
        {
            if(this.Seek(_dictionaryIdIndex, dictionaryId))
            {
                T result = (T)GuiWordsFormsCollection.GetCollectionType(this.Current);
                do
                {
                    result.Add(this.Current);
                } while (this.SeekNext(_dictionaryIdIndex, dictionaryId));
                return result;
            }
            return null;
        }

        #endregion

        #region Privates
        private void InitializeIndices()
        {
            _formIndex = new CustomDataTableIndex<GuiWordsRow>(this, "wf_Form");
            _dictionaryIdIndex = new CustomDataTableIndex<GuiWordsRow>(this, "d_ID");
            _englishMeaningIndex = new CustomDataTableIndex<GuiWordsRow>(this, "d_Meaning");
        }
        #endregion

    }
}
