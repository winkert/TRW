using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRW.Apps.TrwAppsBase.Controls
{
    public partial class RtfEditor : UserControl
    {
        #region Properties
        public string RichText => this.richTextBox.Rtf;
        public string PlainText => this.richTextBox.Text;
        public float SubSuperScriptSizeRatio { get; set; } = 0.75f;
        #endregion

        private const float SubSuperScriptOffsetRatio = 0.5f;

        public RtfEditor()
        {
            InitializeComponent();
            toolFontSize.SelectedIndex = 3;
        }

        private void SetToolbarButtons(RichTextBox rtfBox)
        {
            FontStyle style = GetStyle(rtfBox.SelectionFont, out bool bold, out bool italics, out bool underlined, out bool striked);
            toolBold.Checked = bold;
            toolItalics.Checked = italics;
            toolUnderline.Checked = underlined;
            toolStrikethrough.Checked = striked;

            toolFontSize.Text = rtfBox.SelectionFont.Size.ToString("#");
        }

        private void SetFormatting(ToolStripButton sender, bool enable)
        {
            FormatStyle style = GetStyle(sender);
            if (enable)
            {
                richTextBox.SelectionFont = AddStyle(richTextBox, richTextBox.SelectionFont, style);
            }
            else
            {
                richTextBox.SelectionFont = RemoveStyle(richTextBox, richTextBox.SelectionFont, style);
            }
            return;

        }

        private void SetFormatting(RichTextBox rtfBox, float fontSize)
        {
            rtfBox.SelectionFont = ChangeFontSize(rtfBox.SelectionFont, fontSize);
        }

        private Font AddStyle(RichTextBox rtfBox, Font baseFont, FormatStyle style)
        {
            FontStyle newStyle = GetStyle(baseFont);
            float fontSize = baseFont.Size;

            switch (style)
            {
                case FormatStyle.Bold:
                    newStyle |= FontStyle.Bold;
                    break;
                case FormatStyle.Italics:
                    newStyle |= FontStyle.Italic;
                    break;
                case FormatStyle.Underline:
                    newStyle |= FontStyle.Underline;
                    break;
                case FormatStyle.Strikethrough:
                    newStyle |= FontStyle.Strikeout;
                    break;
                case FormatStyle.SuperScript:
                    rtfBox.SelectionCharOffset = (int)(fontSize * SubSuperScriptOffsetRatio);
                    fontSize *= SubSuperScriptSizeRatio;
                    break;
                case FormatStyle.SubScript:
                    rtfBox.SelectionCharOffset = -(int)(fontSize * SubSuperScriptOffsetRatio);
                    fontSize *= SubSuperScriptSizeRatio;
                    break;
                default:

                    break;
            }

            return new Font(baseFont.FontFamily, fontSize, newStyle);
        }

        private Font RemoveStyle(RichTextBox rtfBox, Font baseFont, FormatStyle style)
        {
            FontStyle newStyle = GetStyle(baseFont);
            float fontSize = baseFont.Size;

            switch (style)
            {
                case FormatStyle.Bold:
                    newStyle &= ~FontStyle.Bold;
                    break;
                case FormatStyle.Italics:
                    newStyle &= ~FontStyle.Italic;
                    break;
                case FormatStyle.Underline:
                    newStyle &= ~FontStyle.Underline;
                    break;
                case FormatStyle.Strikethrough:
                    newStyle &= ~FontStyle.Strikeout;
                    break;
                case FormatStyle.SuperScript:
                case FormatStyle.SubScript:
                    rtfBox.SelectionCharOffset = 0;
                    fontSize /= SubSuperScriptSizeRatio;
                    break;
                default:

                    break;
            }

            return new Font(baseFont.FontFamily, fontSize, newStyle);
        }

        private FontStyle GetStyle(Font baseFont)
        {
            return GetStyle(baseFont, out _, out _, out _, out _);
        }

        private FontStyle GetStyle(Font baseFont, out bool bold, out bool italics, out bool underlined, out bool striked)
        {
            bold = baseFont.Bold;
            italics = baseFont.Italic;
            underlined = baseFont.Underline;
            striked = baseFont.Strikeout;

            FontStyle newStyle = FontStyle.Regular;
            if (bold) newStyle |= FontStyle.Bold;
            if (italics) newStyle |= FontStyle.Italic;
            if (underlined) newStyle |= FontStyle.Underline;
            if (striked) newStyle |= FontStyle.Strikeout;

            return newStyle;
        }

        private FormatStyle GetStyle(ToolStripButton sender)
        {
            if (sender.Equals(toolBold))
            {
                return FormatStyle.Bold;
            }
            else if (sender.Equals(toolItalics))
            {
                return FormatStyle.Italics;
            }
            else if (sender.Equals(toolUnderline))
            {
                return FormatStyle.Underline;
            }
            else if (sender.Equals(toolStrikethrough))
            {
                return FormatStyle.Strikethrough;
            }
            else if (sender.Equals(toolSuperScript))
            {
                return FormatStyle.SuperScript;
            }
            else if (sender.Equals(toolSubScript))
            {
                return FormatStyle.SubScript;
            }

            return FormatStyle.Unknown;
        }

        private Font ChangeFontSize(Font baseFont, float size)
        {
            return new Font(baseFont.FontFamily, size, baseFont.Style);
        }

        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            SetFormatting(button, button.Checked);
        }

        private void toolFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float newFontSize;
            ToolStripComboBox fontSelector = (ToolStripComboBox)sender;
            if (float.TryParse(fontSelector.Text, out newFontSize))
            {
                SetFormatting(richTextBox, newFontSize);
                richTextBox.Focus();
            }
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            // need to update the toolbar to match selected font details
            SetToolbarButtons(richTextBox);
        }

        #region flags
        [Flags]
        internal enum Formatting : byte
        {
            None = 0,
            Bold = 1,
            Italics = 2,
            Underline = 4,
            Strikethrough = 8,
            SuperScript = 16,
            SubScript = 32
        }

        internal enum FormatStyle
        {
            Unknown,
            Bold,
            Italics,
            Underline,
            Strikethrough,
            SuperScript,
            SubScript
        }
        #endregion

    }
}
