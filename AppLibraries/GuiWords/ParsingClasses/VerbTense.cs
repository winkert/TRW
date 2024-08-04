using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRW.AppLibraries.GuiWords
{
    internal class VerbTense
    {
        private const int Alignment = -24;
        internal Tenses Tense { get; set; }
        internal Dictionary<Tuple<Persons, Numbers>, HashSet<string>> IndicativeForms { get; } = new Dictionary<Tuple<Persons, Numbers>, HashSet<string>>();
        internal Dictionary<Tuple<Persons, Numbers>, HashSet<string>> SubjunctiveForms { get; } = new Dictionary<Tuple<Persons, Numbers>, HashSet<string>>();
        internal Dictionary<Tuple<Persons, Numbers>, HashSet<string>> ImperativeForms { get; } = new Dictionary<Tuple<Persons, Numbers>, HashSet<string>>();
        internal HashSet<string> Infinitives { get; } = new HashSet<string>();

        internal void AddForm(GuiWordsRow row)
        {
            Tuple<Persons, Numbers> key = Tuple.Create((Persons)row.PersonId, (Numbers)row.NumberId);
            switch ((Moods)row.MoodId)
            {
                case Moods.Indicative:
                    if (!IndicativeForms.ContainsKey(key))
                    {
                        IndicativeForms.Add(key, new HashSet<string>());
                    }

                    IndicativeForms[key].Add(row.Form);
                    break;
                case Moods.Subjunctive:
                    if (!SubjunctiveForms.ContainsKey(key))
                    {
                        SubjunctiveForms.Add(key, new HashSet<string>());
                    }

                    SubjunctiveForms[key].Add(row.Form);
                    break;
                case Moods.Imperative:
                    if (!ImperativeForms.ContainsKey(key))
                    {
                        ImperativeForms.Add(key, new HashSet<string>());
                    }

                    ImperativeForms[key].Add(row.Form);
                    break;
                case Moods.Infinitive:
                    Infinitives.Add(row.Form);
                    break;
            }

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Tense} Singular Indicative");
            stringBuilder.AppendLine($"1st: {IndicativeForms[Tuple.Create(Persons.FirstPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"2nd: {IndicativeForms[Tuple.Create(Persons.SecondPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {IndicativeForms[Tuple.Create(Persons.ThirdPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine($"{Tense} Plural Indicative");
            stringBuilder.AppendLine($"1st: {IndicativeForms[Tuple.Create(Persons.FirstPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"2nd: {IndicativeForms[Tuple.Create(Persons.SecondPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {IndicativeForms[Tuple.Create(Persons.ThirdPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine("--------------------");

            stringBuilder.AppendLine($"{Tense} Singular Imperative");
            stringBuilder.AppendLine($"2nd: {ImperativeForms[Tuple.Create(Persons.SecondPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {ImperativeForms[Tuple.Create(Persons.ThirdPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine($"{Tense} Plural Imperative");
            stringBuilder.AppendLine($"2nd: {ImperativeForms[Tuple.Create(Persons.SecondPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {ImperativeForms[Tuple.Create(Persons.ThirdPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine("--------------------");

            stringBuilder.AppendLine($"{Tense} Infinitive: {Infinitives.FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine("--------------------");

            stringBuilder.AppendLine($"{Tense} Singular Subjunctive");
            stringBuilder.AppendLine($"1st: {SubjunctiveForms[Tuple.Create(Persons.FirstPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"2nd: {SubjunctiveForms[Tuple.Create(Persons.SecondPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {SubjunctiveForms[Tuple.Create(Persons.ThirdPerson, Numbers.Singular)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine($"{Tense} Plural Subjunctive");
            stringBuilder.AppendLine($"1st: {SubjunctiveForms[Tuple.Create(Persons.FirstPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"2nd: {SubjunctiveForms[Tuple.Create(Persons.SecondPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");
            stringBuilder.AppendLine($"3rd: {SubjunctiveForms[Tuple.Create(Persons.ThirdPerson, Numbers.Plural)].FirstOrDefault(),Alignment}");

            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
