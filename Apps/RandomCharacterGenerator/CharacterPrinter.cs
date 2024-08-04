using TRW.GameLibraries.Character.DnD;
using TRW.CommonLibraries.Pdf;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using Font = PdfSharpCore.Drawing.XFont;
using TRW.GameLibraries.Character;

namespace TRW.Apps.RandomCharacterGenerator
{
    public static class CharacterPrinter
    {
        internal readonly static double OneInch = XUnit.FromInch(1);
        internal readonly static double TwoInches = XUnit.FromInch(2);
        internal readonly static double HalfInch = XUnit.FromInch(0.5);
        internal readonly static double QuarterInch = XUnit.FromInch(0.25);

        internal const string _defaultFontName = "Bookman Old Style";
        internal readonly static Font _headerFont = new Font("Old English Text MT", 20, XFontStyle.Bold);
        internal readonly static Font _subHeaderFont = new Font("Old English Text MT", 18);
        internal readonly static Font _attributeFont = new Font("Old English Text MT", 30);
        internal readonly static Font _attributeFontBonus = new Font("Old English Text MT", 10);
        internal readonly static Font _attributeFontName = new Font(_defaultFontName, 11, XFontStyle.Bold | XFontStyle.Underline);
        internal readonly static Font _defaultFont = new Font(_defaultFontName, 12);
        internal readonly static Font _defaultFontBold = new Font(_defaultFontName, 12, XFontStyle.Bold);

        public static void SaveDnDCharactersToPdf(List<DnDCharacter> characters, string file)
        {
            PdfDocument doc = new PdfDocument();

            using (PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                foreach (DnDCharacter character in characters)
                {
                    AddCharacterDetails(helper, character);

                }
            }

            PdfRoutines.FinalizePdf(doc, file);
        }

        public static void SaveDnDCharacterSheetToPdf(DnDCharacter character, string file)
        {
            PdfDocument doc = new PdfDocument();
            using (PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                XRect characterBlock = new XRect(helper.LeftMargin, helper.TopMargin, helper.RightMargin - helper.LeftMargin, OneInch + HalfInch);
                // draw player, name, race, class, background, level, xp
                AddCharacterBasics(helper, character, characterBlock);

                // position statblocks on margin and 2 inches from top
                AddStats(helper, character, helper.LeftMargin, characterBlock.Bottom, OneInch, out XRect[] attributeBoxes);

                // draw hp and ac in middle
                XUnit vitalsLeft = (helper.Page.Width / 2) - HalfInch;
                XRect vitalsArea = new XRect(vitalsLeft, characterBlock.Bottom, OneInch, TwoInches);
                AddCharacterVitals(helper, character, vitalsArea);

                // slip in skills here
                XRect skillBlock = new XRect(attributeBoxes[0].Right, characterBlock.Bottom, vitalsLeft - attributeBoxes[0].Right, attributeBoxes.Sum(x => x.Height));
                helper.Gfx.DrawRoundedRectangle(XPens.Black, skillBlock, new XSize(QuarterInch, QuarterInch));
                AddSkillBlock(helper, skillBlock, attributeBoxes[0], DnDCharacter.AttributeSkills[Attributes.Strength]);
                AddSkillBlock(helper, skillBlock, attributeBoxes[1], DnDCharacter.AttributeSkills[Attributes.Dexterity]);
                AddSkillBlock(helper, skillBlock, attributeBoxes[2], DnDCharacter.AttributeSkills[Attributes.Constitution]);
                AddSkillBlock(helper, skillBlock, attributeBoxes[3], DnDCharacter.AttributeSkills[Attributes.Intelligence]);
                AddSkillBlock(helper, skillBlock, attributeBoxes[4], DnDCharacter.AttributeSkills[Attributes.Wisdom]);
                AddSkillBlock(helper, skillBlock, attributeBoxes[5], DnDCharacter.AttributeSkills[Attributes.Charisma]);

                // draw space for attacks and armor

            }

            PdfRoutines.FinalizePdf(doc, file);
        }

        public static void SaveDnDRaceListToPdf(List<DnDCharacterRace> races, string file)
        {
            PdfDocument doc = new PdfDocument();
            using (PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                foreach (DnDCharacterRace r in races)
                {
                    helper.WriteString(r.Name, new Font(_defaultFontName, 13, XFontStyle.Bold), helper.LeftMargin);
                    AddTitledListItem(helper, "Size", _defaultFontBold, r.Size.ToString(), _defaultFont);
                    AddTitledList(helper, "Attribute Bonuses", _defaultFontBold, r.AttributeBonuses, _defaultFont);
                    AddTitledListItem(helper, "Walking Speed", _defaultFontBold, r.WalkingSpeed.ToString(), _defaultFont);
                    if (r.IsSwimming)
                        AddTitledListItem(helper, "Swimming Speed", _defaultFontBold, r.SwimmingSpeed.ToString(), _defaultFont);
                    if (r.IsClimbing)
                        AddTitledListItem(helper, "Climbing Speed", _defaultFontBold, r.ClimbingSpeed.ToString(), _defaultFont);
                    if (r.IsFlying)
                        AddTitledListItem(helper, "Flying Speed", _defaultFontBold, r.FlyingSpeed.ToString(), _defaultFont);
                    switch (r.VisionType)
                    {
                        case GameLibraries.Character.VisionTypes.Darkvision:
                        case GameLibraries.Character.VisionTypes.SuperiorDarkvision:
                            AddTitledListItem(helper, "Darkvision", _defaultFontBold, CommonLibraries.Core.EnumExtensions.GetDescription(r.VisionType), _defaultFont);
                            break;
                        default:
                            break;
                    }
                    AddTitledListItem(helper, "Sunlight Sensitive", _defaultFontBold, r.IsSunlightSensitive.ToString(), _defaultFont);
                    AddTitledListItem(helper, "Amphibious", _defaultFontBold, r.IsAmphibious.ToString(), _defaultFont);
                    if (r.Languages.Count > 0)
                        AddTitledList(helper, "Languages", _defaultFontBold, r.Languages, _defaultFont);
                    if (r.Proficiencies.Count > 0)
                        AddTitledList(helper, "Proficiencies", _defaultFontBold, r.Proficiencies, _defaultFont);
                    if (r.Features.Count > 0)
                        AddTitledList(helper, "Race Features", _defaultFontBold, r.Features, _defaultFont);

                    helper.NextLine(XUnit.FromPoint(15));
                    helper.DrawLine();
                    helper.NextLine(XUnit.FromPoint(25));
                }
            }

            PdfRoutines.FinalizePdf(doc, file);
        }

        public static void SaveDnDClassListToPdf(List<DnDCharacterClass> classes, string file)
        {

            PdfDocument doc = new PdfDocument();
            using (PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                foreach (DnDCharacterClass c in classes)
                {
                    helper.WriteString(c.Name, new Font(_defaultFontName, 13, XFontStyle.Bold), helper.LeftMargin);

                    AddTitledListItem(helper, "Primary Attribute", _defaultFontBold, c.PrimaryAttribute.ToString(), _defaultFont);
                    AddTitledListItem(helper, "Secondary Attribute", _defaultFontBold, c.SecondaryAttribute.ToString(), _defaultFont);
                    AddTitledListItem(helper, "Hit Dice", _defaultFontBold, c.HitDie.DiceSides.ToString(), _defaultFont);
                    AddTitledListItem(helper, "Spellcasting Ability", _defaultFontBold, c.SpellCastingAbility.ToString(), _defaultFont);

                    AddTitledList(helper, "Saving Throws", _defaultFontBold, c.SavingThrows, _defaultFont);

                    if (c.Languages.Count > 0)
                        AddTitledList(helper, "Languages", _defaultFontBold, c.Languages, _defaultFont);
                    if (c.Skills.Count > 0)
                        AddTitledListItem(helper, "Skills", _defaultFontBold, c.Skills.ToString(), _defaultFont);
                    if (c.Proficiencies.Count > 0)
                        AddTitledList(helper, "Proficiencies", _defaultFontBold, c.Proficiencies, _defaultFont);
                    if (c.Features.Count > 0)
                        AddTitledList(helper, "Class Features", _defaultFontBold, c.Features, _defaultFont);

                    helper.NextLine(XUnit.FromPoint(15));
                    helper.DrawLine();
                    helper.NextLine(XUnit.FromPoint(25));
                }
            }

            PdfRoutines.FinalizePdf(doc, file);
        }

        public static void SaveDnDBackgroundListToPdf(List<DnDCharacterBackground> backgrounds, string file)
        {

            PdfDocument doc = new PdfDocument();
            using (PdfLayoutHelper helper = new PdfLayoutHelper(doc))
            {
                foreach (DnDCharacterBackground b in backgrounds)
                {
                    helper.WriteString(b.Name, new Font(_defaultFontName, 13, XFontStyle.Bold), helper.LeftMargin);

                    if (b.Languages.Count > 0)
                        AddTitledListItem(helper, "Languages", _defaultFontBold, b.Languages.ToString(), _defaultFont);
                    if (b.Skills.Count > 0)
                        AddTitledListItem(helper, "Skills", _defaultFontBold, b.Skills.ToString(), _defaultFont);
                    if (b.Proficiencies.Count > 0)
                        AddTitledListItem(helper, "Proficiencies", _defaultFontBold, b.Proficiencies.ToString(), _defaultFont);

                    if (b.Traits.Count > 0)
                        AddTitledList(helper, "Background Traits", _defaultFontBold, b.Traits, _defaultFont);
                    if (b.Bonds.Count > 0)
                        AddTitledList(helper, "Background Bonds", _defaultFontBold, b.Bonds, _defaultFont);
                    if (b.Ideals.Count > 0)
                        AddTitledList(helper, "Background Ideals", _defaultFontBold, b.Ideals, _defaultFont);
                    if (b.Flaws.Count > 0)
                        AddTitledList(helper, "Background Flaws", _defaultFontBold, b.Flaws, _defaultFont);

                    if (b.Features.Count > 0)
                        AddTitledList(helper, "Background Features", _defaultFontBold, b.Features, _defaultFont);

                    helper.NextLine(XUnit.FromPoint(15));
                    helper.DrawLine();
                    helper.NextLine(XUnit.FromPoint(25));
                }
            }
            //
            PdfRoutines.FinalizePdf(doc, file);
        }

        #region Character Sheets

        private static void AddCharacterBasics(PdfLayoutHelper helper, DnDCharacter character, XRect characterBlock)
        {
            helper.Gfx.DrawRoundedRectangle(XPens.Black, XBrushes.Transparent, characterBlock, new XSize(QuarterInch, QuarterInch));
            XUnit lineHeight = helper.MeasureTextBlock("P", _defaultFont).Height + XUnit.FromPoint(5);
            XUnit xPosition = characterBlock.Left + XUnit.FromPoint(5);
            XUnit yPosition = characterBlock.Top + lineHeight;
            XUnit lineEndPoint = characterBlock.Right - QuarterInch;
            AddTitleWithLine(helper, "Player Name: ", _defaultFontBold, xPosition, yPosition, lineEndPoint);
            yPosition += lineHeight;
            AddTitleWithLine(helper, "Character Name: ", _defaultFontBold, xPosition, yPosition, lineEndPoint);
            yPosition += lineHeight;
            helper.WriteString($"Race: {character.Race}", _defaultFontBold, XBrushes.Black, xPosition, yPosition);
            yPosition += lineHeight;
            helper.WriteString($"Class: {character.Class} (Level {character.CharacterLevel})", _defaultFontBold, XBrushes.Black, xPosition, yPosition);
            yPosition += lineHeight;
            helper.WriteString($"Background: {character.Background}", _defaultFontBold, XBrushes.Black, xPosition, yPosition);
        }

        private static void AddStats(PdfLayoutHelper helper, DnDCharacter character, double left, double top, double height, out XRect[] attributeBoxes)
        {
            double width = helper.MeasureString("Constitution", _attributeFontName) + XUnit.FromCentimeter(1);
            double right = left + width;
            attributeBoxes = new XRect[6]
            {
                new XRect(new XPoint(left, top), new XPoint(right, top + height)),
                new XRect(new XPoint(left, top + height), new XPoint(right, top + height * 2)),
                new XRect(new XPoint(left, top + height * 2), new XPoint(right, top + height * 3)),
                new XRect(new XPoint(left, top + height * 3), new XPoint(right, top + height * 4)),
                new XRect(new XPoint(left, top + height * 4), new XPoint(right, top + height * 5)),
                new XRect(new XPoint(left, top + height * 5), new XPoint(right, top + height * 6))
            };

            AddStatBox(helper, attributeBoxes[0], "Strength", character.Strength, character.StrengthBonus);
            AddStatBox(helper, attributeBoxes[1], "Dexterity", character.Dexterity, character.DexterityBonus);
            AddStatBox(helper, attributeBoxes[2], "Constitution", character.Constitution, character.ConstitutionBonus);
            AddStatBox(helper, attributeBoxes[4], "Intelligence", character.Intelligence, character.IntelligenceBonus);
            AddStatBox(helper, attributeBoxes[3], "Wisdom", character.Wisdom, character.WisdomBonus);
            AddStatBox(helper, attributeBoxes[5], "Charisma", character.Charisma, character.CharismaBonus);

        }

        private static void AddStatBox(PdfLayoutHelper helper, XRect statRect, string statName, int value, int bonus)
        {
            XUnit yPos = statRect.Top - ((statRect.Top - statRect.Bottom) / 2);
            helper.Gfx.DrawRoundedRectangle(XPens.Black, XBrushes.Transparent, statRect, new XSize(QuarterInch, QuarterInch));
            helper.WriteFixedWidthString(statName, statRect.Width, _attributeFontName, XBrushes.Black, statRect.Left, statRect.Top + helper.MeasureTextBlock(statName, _attributeFontName).Height, PdfLayoutHelper.StringAlignments.Center);
            helper.WriteFixedWidthString(value.ToString(), statRect.Width, _attributeFont, XBrushes.Black, statRect.Left, yPos, PdfLayoutHelper.StringAlignments.Center);
            helper.WriteFixedWidthString(bonus.ToString(), statRect.Width, _attributeFontBonus, XBrushes.Black, statRect.Left, statRect.Bottom - helper.MeasureTextBlock(bonus.ToString(), _attributeFontBonus).Height, PdfLayoutHelper.StringAlignments.Center);
        }

        private static void AddSkillBlock(PdfLayoutHelper helper, XRect skillBlock, XRect attributeBox, List<Skills> skillsToList)
        {
            Font skillFont = new Font(_defaultFontName, 9);
            XUnit yHeight = helper.MeasureTextBlock("+1", skillFont).Height;
            XUnit yPos = attributeBox.Top + yHeight;
            foreach(Skills skill in skillsToList)
            {
                // start at the top of this attribute box, but place inside skill block
                helper.WriteString($" [  ] {TRW.CommonLibraries.Core.EnumExtensions.GetDescription(skill)}", skillFont, XBrushes.Black, skillBlock.Left, yPos);
                yPos += yHeight;
            }
        }

        private static void AddCharacterVitals(PdfLayoutHelper helper, DnDCharacter character, XRect vitalsArea)
        {
            helper.Gfx.DrawRoundedRectangle(XPens.Black, XBrushes.Transparent, vitalsArea, new XSize(QuarterInch, QuarterInch));

            // top is AC
            double topY = vitalsArea.Top + QuarterInch;
            double bottomY = vitalsArea.Top + XUnit.FromInch(0.65);
            DrawACShield(helper, character, vitalsArea.Left, vitalsArea.Right, topY, bottomY);

            topY += OneInch;
            bottomY += OneInch;
            DrawHPHeart(helper, character, vitalsArea.Left, vitalsArea.Right, topY, bottomY);
            // bottom is HP

        }

        private static void DrawACShield(PdfLayoutHelper helper, DnDCharacter character, double leftX, double rightX, double topY, double bottomY)
        {
            double width = rightX - leftX;
            XPoint leftTopCorner = new XPoint(leftX + XUnit.FromInch(.175), topY);
            XPoint rightTopCorner = new XPoint(rightX - XUnit.FromInch(.175), topY);
            XPoint leftBottomCorner = new XPoint(leftX + XUnit.FromInch(.175), bottomY);
            XPoint rightBottomCorner = new XPoint(rightX - XUnit.FromInch(.175), bottomY);
            XPoint topMid = new XPoint(leftX + (width / 2), topY);
            XPoint bottomMid = new XPoint(leftX + (width / 2), bottomY + XUnit.FromInch(.175));
            helper.DrawLine(leftBottomCorner, leftTopCorner);
            helper.DrawLine(rightBottomCorner, rightTopCorner);
            helper.DrawCurvedLine(XPens.Black, leftTopCorner, topMid, 5);
            helper.DrawCurvedLine(XPens.Black, topMid, rightTopCorner, 5);
            helper.DrawCurvedLine(XPens.Black, leftBottomCorner, bottomMid, 5.75);
            helper.DrawCurvedLine(XPens.Black, bottomMid, rightBottomCorner, 5.75);

            Font font = new Font("Times New Roman", 9);;
            XUnit textWidth = helper.MeasureString("Armor Class", font);
            helper.WriteString("Armor Class", font, XBrushes.Black, topMid.X - (textWidth / 2), topY - 5);
        }

        private static void DrawHPHeart(PdfLayoutHelper helper, DnDCharacter character, double leftX, double rightX, double topY, double bottomY)
        {
            double width = rightX - leftX;
            XPoint leftTopCorner = new XPoint(leftX + XUnit.FromInch(.175), topY + QuarterInch);
            XPoint rightTopCorner = new XPoint(rightX - XUnit.FromInch(.175), topY + QuarterInch);
            XPoint topMid = new XPoint(leftX + (width / 2), topY + XUnit.FromInch(0.175));
            XPoint bottomMid = new XPoint(leftX + (width / 2), bottomY + XUnit.FromInch(.175));
            helper.DrawLine(bottomMid, leftTopCorner);
            helper.DrawLine(bottomMid, rightTopCorner);
            helper.DrawCurvedLine(XPens.Black, leftTopCorner, topMid, -10);
            helper.DrawCurvedLine(XPens.Black, topMid, rightTopCorner, -10);

            Font font = new Font("Times New Roman", 9); ;
            XUnit textWidth = helper.MeasureString("Hit Points", font);
            helper.WriteString("Hit Points", font, XBrushes.Black, topMid.X - (textWidth / 2), topY - 5);
            textWidth = helper.MeasureString($"Max: {character.CharacterMaxHitPoints}", font);
            helper.WriteString($"Max: {character.CharacterMaxHitPoints}", font, XBrushes.Black, topMid.X - (textWidth / 2), bottomMid.Y + 7.5d);
        }
        #endregion
        #region Character Lists
        private static void AddCharacterDetails(PdfLayoutHelper helper, DnDCharacter character)
        {
            helper.NextLine(XUnit.FromPoint(25));
            helper.WriteString($"{character.Race} : {character.Class} | {character.Background}", new Font(_defaultFontName, 20, XFontStyle.Bold), XBrushes.Black);

            AddTitledListItem(helper, "Level", _defaultFontBold, character.CharacterLevel.ToString(), _defaultFont, ":");
            AddTitledListItem(helper, "Hitpoints", _defaultFontBold, character.CharacterMaxHitPoints.ToString(), _defaultFont, ":");
            AddCharacterAttributeStats(helper, character);

            helper.NextLine(XUnit.FromPoint(20));

            AddTitledListItem(helper, "Attribute Bonuses", _defaultFontBold, character.AttributeBonuses, _defaultFont);
            AddTitledList(helper, "Saving Throws", _defaultFontBold, character.SavingThrows, _defaultFont);
            AddTitledListItem(helper, "Languages", _defaultFontBold, character.GetLanguagesString(), _defaultFont);
            AddTitledListItem(helper, "Proficiencies", _defaultFontBold, character.GetProficienciesString(), _defaultFont);
            AddTitledListItem(helper, "Skills", _defaultFontBold, character.GetSkillsString(), _defaultFont);
            AddTitledListItem(helper, "Features", _defaultFontBold, character.GetFeaturesString(), _defaultFont);

            helper.NextLine(XUnit.FromPoint(20));
            helper.DrawLine();
        }
        private static void AddCharacterAttributeStats(PdfLayoutHelper helper, DnDCharacter character)
        {
            Font statHeader = PdfRoutines.GetBodyFont(XFontStyle.Bold);
            helper.NextLine(statHeader);
            XUnit left = helper.LeftMargin + XUnit.FromInch(.25);
            XUnit tab = helper.MeasureString("MMMMMM", statHeader);

            left = helper.WriteFixedWidthString("STR", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString("DEX", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString("CON", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString("INT", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString("WIS", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString("CHA", tab, statHeader, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);

            helper.NextLine(statHeader);
            left = helper.LeftMargin + XUnit.FromInch(.25);

            tab = helper.MeasureString("MMMMMM", _defaultFont);
            left = helper.WriteFixedWidthString($"{character.Strength}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString($"{character.Dexterity}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString($"{character.Constitution}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString($"{character.Intelligence}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString($"{character.Wisdom}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);
            left = helper.WriteFixedWidthString($"{character.Charisma}", tab, _defaultFont, XBrushes.Black, left, PdfLayoutHelper.StringAlignments.Center);

        }
        #endregion
        #region Formatting
        private static void AddTitledListItem(PdfLayoutHelper helper, string title, Font titleFont, string item, Font itemFont)
        {
            AddTitledListItem(helper, title, titleFont, item, itemFont, ":");
        }

        private static void AddTitledListItem(PdfLayoutHelper helper, string title, Font titleFont, string item, Font itemFont, string separator)
        {
            helper.NextLine(titleFont);
            string titleText = $"{title} {separator}";
            XUnit left = helper.WriteString(titleText, titleFont, helper.LeftMargin);

            helper.WriteString(item, itemFont, left);
            return;
        }

        private static void AddTitledList<T>(PdfLayoutHelper helper, string title, Font titleFont, IEnumerable<T> items, Font itemFont)
        {
            helper.NextLine(itemFont);
            helper.WriteString(title, titleFont, XBrushes.Black, helper.LeftMargin);
            helper.NextLine(itemFont);

            foreach (T item in items)
            {
                helper.WriteString(item.ToString(), itemFont, XBrushes.Black, helper.LeftMargin);
                helper.NextLine(itemFont);
            }
        }

        private static void AddTitleWithLine(PdfLayoutHelper helper, string text, Font font, XUnit xPosition, XUnit yPosition, XUnit endPoint)
        {
            XUnit xStartForLine = xPosition + helper.MeasureString(text, font);
            helper.WriteString(text, font, XBrushes.Black, xPosition, yPosition);
            helper.DrawLine(xStartForLine, yPosition, endPoint, yPosition);
        }
        #endregion
    }
}