namespace TRW.AppLibraries.GuiWords
{
    public class GuiWordsRowMatch
    {
        #region Fields

        #endregion

        #region Constructors
        public GuiWordsRowMatch(GuiWordsRow row)
        {
            DictionaryId = row.DictionaryId;
            DictionaryWord = row.DictionaryWord;
            Form = row.Form;
            PartOfSpeech = (PartsOfSpeech)row.PartOfSpeechId;
            Conjugation = (Conjugations)row.ConjugationId;
            Declension = (Declensions)row.DeclensionId;
            Number = (Numbers)row.NumberId;
            Case = (Cases)row.CaseId;
            Gender = (Genders)row.GenderId;
            Person = (Persons)row.PersonId;
            Tense = (Tenses)row.TenseId;
            Voice = (Voices)row.VoiceId;
            Mood = (Moods)row.MoodId;
            AdjectiveType = (AdjectiveTypes)row.AdjectiveTypeId; // not in query and I'm not sure why
            Meaning = row.Meaning;
        }

        #endregion

        #region Properties
        public int DictionaryId { get; }
        public string DictionaryWord { get; }
        public string Form { get; }
        public PartsOfSpeech PartOfSpeech {get;}
        public Conjugations Conjugation { get; }
        public Declensions Declension { get; }
        public Numbers Number { get; }
        public Cases Case { get; }
        public Genders Gender { get; }
        public Persons Person { get; }
        public Tenses Tense { get; }
        public Voices Voice { get; }
        public Moods Mood { get; }
        public AdjectiveTypes AdjectiveType { get; }
        public VerbTypes VerbType { get; }
        public string Meaning { get; }
        #endregion

        #region Publics
        #endregion
    }
}
