using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRW.AppLibraries.GuiWords
{
    internal class GenderDeclension
    {
        private const int Alignment = -24;
        internal Genders Gender { get; set; }

        Dictionary<Tuple<Cases, Numbers>, HashSet<string>> GenderForms { get; } = new Dictionary<Tuple<Cases, Numbers>, HashSet<string>>();

        internal void AddForm(GuiWordsRow row)
        {
            Tuple<Cases, Numbers> key = Tuple.Create((Cases)row.CaseId, (Numbers)row.NumberId);
            if (!GenderForms.ContainsKey(key))
            {
                GenderForms.Add(key, new HashSet<string>());
            }

            GenderForms[key].Add(row.Form);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Singular {Gender}");
            builder.AppendLine($"Nom: {GenderForms[Tuple.Create(Cases.Nominative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Gen: {GenderForms[Tuple.Create(Cases.Genitive, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Dat: {GenderForms[Tuple.Create(Cases.Dative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Acc: {GenderForms[Tuple.Create(Cases.Accusative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Abl: {GenderForms[Tuple.Create(Cases.Ablative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Loc: {GenderForms[Tuple.Create(Cases.Locative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Voc: {GenderForms[Tuple.Create(Cases.Vocative, Numbers.Singular)].FirstOrDefault(),Alignment}");

            builder.AppendLine($"Plural {Gender}");
            builder.AppendLine($"Nom: {GenderForms[Tuple.Create(Cases.Nominative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Gen: {GenderForms[Tuple.Create(Cases.Genitive, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Dat: {GenderForms[Tuple.Create(Cases.Dative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Acc: {GenderForms[Tuple.Create(Cases.Accusative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Abl: {GenderForms[Tuple.Create(Cases.Ablative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Loc: {GenderForms[Tuple.Create(Cases.Locative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine($"Voc: {GenderForms[Tuple.Create(Cases.Vocative, Numbers.Singular)].FirstOrDefault(),Alignment}");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
