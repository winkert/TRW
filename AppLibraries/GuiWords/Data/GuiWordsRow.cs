using System;

namespace TRW.AppLibraries.GuiWords
{
    public class GuiWordsRow : TRW.CommonLibraries.Data.Core.CustomDataRow
    {
        #region Fields

        #endregion

        #region Constructors
        public GuiWordsRow() : base()
        {

        }
        public GuiWordsRow(CommonLibraries.Data.Core.CustomDataColumnCollection columns) : base(columns)
        {

        }

        #endregion

        #region Properties
        public int DictionaryId { get { return Convert.ToInt32(Items[0]); } set { base[0] = value; } }
        public string DictionaryWord { get { return Convert.ToString(Items[1]); } set { base[1] = value; } }
        public string Meaning { get { return Convert.ToString(Items[2]); } set { base[2] = value; } }
        public int StemId { get { return Convert.ToInt32(Items[3]); } set { base[3] = value; } }
        public string Form { get { return Convert.ToString(Items[4]); } set { base[4] = value; } }
        public int EndingId { get { return Convert.ToInt32(Items[5]); } set { base[5] = value; } }
        public short ConjugationId { get { return Convert.ToInt16(Items[6]); } set { base[6] = value; } }
        public short VerbTypeId { get { return Convert.ToInt16(Items[7]); } set { base[7] = value; } }
        public short CaseId { get { return Convert.ToInt16(Items[8]); } set { base[8] = value; } }
        public short AdjectiveTypeId { get; set; } // not in query and I'm not sure why
        public short DeclensionId { get { return Convert.ToInt16(Items[9]); } set { base[9] = value; } }
        public short GenderId { get { return Convert.ToInt16(Items[10]); } set { base[10] = value; } }
        public short MoodId { get { return Convert.ToInt16(Items[11]); } set { base[11] = value; } }
        public short NumberId { get { return Convert.ToInt16(Items[12]); } set { base[12] = value; } }
        public short PartOfSpeechId { get { return Convert.ToInt16(Items[13]); } set { base[13] = value; } }
        public short PersonId { get { return Convert.ToInt16(Items[14]); } set { base[14] = value; } }
        public short TenseId { get { return Convert.ToInt16(Items[15]); } set { base[15] = value; } }
        public short VoiceId { get { return Convert.ToInt16(Items[16]); } set { base[16] = value; } }
        public int WordFormId { get { return Convert.ToInt32(Items[17]); } set { base[17] = value; } }
        #endregion

        #region Publics
        #endregion
    }
}
