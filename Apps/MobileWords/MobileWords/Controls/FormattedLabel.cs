using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MobileWords.Controls
{

    public class FormattedLabel : Xamarin.Forms.Label
    {
        public FormattedLabel()
        {
            TextParameters = new List<object>();
        }

        #region Properties

        public static readonly BindableProperty FormatStringProperty = BindableProperty.Create(
        propertyName: "FormatString",
        returnType: typeof(string),
        declaringType: typeof(string),
        defaultValue: string.Empty);

        /// <summary>
        /// Formatted Text
        /// </summary>
        public string FormatString
        {
            get => (string)GetValue(FormatStringProperty);
            set => SetValue(FormatStringProperty, value);
        }

        public static readonly BindableProperty TextParametersProperty = BindableProperty.Create(
        propertyName: "TextParameters",
        returnType: typeof(List<object>),
        declaringType: typeof(List<object>),
        defaultValue: new List<object>());

        /// <summary>
        /// Ordered List of Paramters to be inserted into the formatted text
        /// </summary>
        public List<object> TextParameters
        {
            get => (List<object>)GetValue(TextParametersProperty);
            set => SetValue(TextParametersProperty, value);
        }

        #endregion

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "FormatString")
            {
                object[] parms = new object[TextParameters.Count];
                for (int i = 0; i < TextParameters.Count; i++)
                {
                    parms[i] = TextParameters[i];
                }

                Text = string.Format(FormatString, parms);
            }
        }

        public override string UpdateFormsText(string source, TextTransform textTransform)
        {
            return base.UpdateFormsText(source, textTransform);
        }
    }
}
