using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRW.AppLibraries.GuiWords
{
    public abstract class GuiWordsFormsCollection
    {
        protected GuiWordsTable _internalTable = new GuiWordsTable();

        protected abstract bool AddForm(GuiWordsRow formRow);

        public void Add(GuiWordsRow formRow)
        {
            if (AddForm(formRow))
            {
                _internalTable.Append(formRow);
            }
        }

        public static GuiWordsFormsCollection GetCollectionType(GuiWordsRow row)
        {
            switch ((PartsOfSpeech)row.PartOfSpeechId)
            {
                case PartsOfSpeech.Noun:
                case PartsOfSpeech.Pronoun:
                case PartsOfSpeech.Adjective:
                case PartsOfSpeech.Number:
                    return new Declension();
                case PartsOfSpeech.Verb:
                    return new Synopsis();
                case PartsOfSpeech.Adverb:
                case PartsOfSpeech.Conjunction:
                case PartsOfSpeech.Preposition:
                case PartsOfSpeech.Interjection:
                default:
                    return new GuiWordsForms();
            }
        }
    }

    public class Synopsis : GuiWordsFormsCollection
    {
        private const int Alignment = -24;
        internal Dictionary<Tenses, VerbTense> VerbForms { get; } = new Dictionary<Tenses, VerbTense>();
        internal Dictionary<Tuple<Tenses, Genders>, GenderDeclension> ParticipleForms { get; } = new Dictionary<Tuple<Tenses, Genders>, GenderDeclension>();
        internal HashSet<string> SupineForms { get; } = new HashSet<string>();

        protected override bool AddForm(GuiWordsRow formRow)
        {
            Moods currentMood = (Moods)formRow.MoodId;
            Tenses currentTense = (Tenses)formRow.TenseId;

            switch (currentMood)
            {
                case Moods.Indicative:
                case Moods.Subjunctive:
                case Moods.Imperative:
                case Moods.Infinitive:
                    if (!VerbForms.ContainsKey(currentTense))
                    {
                        VerbForms.Add(currentTense, new VerbTense() { Tense = currentTense });
                    }
                    VerbForms[currentTense].AddForm(formRow);
                    break;
                case Moods.Participle:
                    Genders currentGender = (Genders)formRow.GenderId;
                    Tuple<Tenses, Genders> key = Tuple.Create(currentTense, currentGender);
                    if (!ParticipleForms.ContainsKey(key))
                    {
                        ParticipleForms.Add(key, new GenderDeclension() { Gender = currentGender });
                    }
                    ParticipleForms[key].AddForm(formRow);
                    break;
                case Moods.Supine:
                    SupineForms.Add(formRow.Form);
                    break;
                case Moods.None:
                default:
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(GetTenseSynopsis(Tenses.Present));
            builder.AppendLine(GetTenseSynopsis(Tenses.Imperfect));
            builder.AppendLine(GetTenseSynopsis(Tenses.Future));
            builder.AppendLine("-----------------------------");
            builder.AppendLine(GetTenseSynopsis(Tenses.Perfect));
            builder.AppendLine(GetTenseSynopsis(Tenses.Pluperfect));
            builder.AppendLine(GetTenseSynopsis(Tenses.FuturePerfect));
            builder.AppendLine("-----------------------------");
            builder.AppendLine($"{SupineForms.FirstOrDefault(),Alignment}");

            return builder.ToString();
        }

        private string GetTenseSynopsis(Tenses tense)
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine($"{tense}");

            if (VerbForms.ContainsKey(tense))
            {
                results.Append(VerbForms[tense]);
                results.AppendLine();
                if (ParticipleForms.ContainsKey(Tuple.Create(tense, Genders.Masculine)))
                {
                    results.Append(ParticipleForms[Tuple.Create(tense, Genders.Masculine)]);
                    results.AppendLine();
                }
                if (ParticipleForms.ContainsKey(Tuple.Create(tense, Genders.Feminine)))
                {
                    results.Append(ParticipleForms[Tuple.Create(tense, Genders.Feminine)]);
                    results.AppendLine();
                }
                if (ParticipleForms.ContainsKey(Tuple.Create(tense, Genders.Neuter)))
                {
                    results.Append(ParticipleForms[Tuple.Create(tense, Genders.Neuter)]);
                    results.AppendLine();
                }
            }

            return results.ToString();
        }
    }

    public class Declension : GuiWordsFormsCollection
    {
        internal Dictionary<Genders, GenderDeclension> Forms { get; } = new Dictionary<Genders, GenderDeclension>();

        protected override bool AddForm(GuiWordsRow formRow)
        {
            Genders currentGender = (Genders)formRow.GenderId;
            if (!Forms.ContainsKey(currentGender))
            {
                Forms.Add(currentGender, new GenderDeclension() { Gender = currentGender });
            }

            Forms[currentGender].AddForm(formRow);
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<Genders, GenderDeclension> gender in Forms)
            {
                builder.Append(gender.Value.ToString());
            }

            return builder.ToString();
        }
    }

    public class GuiWordsForms : GuiWordsFormsCollection
    {
        public string Form { get; private set; }

        protected override bool AddForm(GuiWordsRow formRow)
        {
            // in this case, there is only one form expected
            Form = formRow.Form;
            return true;
        }

        public override string ToString()
        {
            return Form;
        }
    }
}
