using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Dice
    {
        public Dice()
            : this(6)
        { }

        public Dice(int sides)
            : this(sides, DiceOptions.None)
        { }

        public Dice(int sides, DiceOptions options)
        {
            DiceSides = sides;
            Options = options;
        }

        public int DiceSides { get; private set; }
        protected DiceOptions Options { get; private set; }

        public int Roll(int dice)
        {
            return Roll(DiceSides, dice, 0);
        }

        public int Roll(int dice, int bonus)
        {
            return Roll(DiceSides, dice, bonus);
        }

        public override string ToString()
        {
            return string.Format("d{0}", DiceSides);
        }

        #region Statics
        protected static Random R = new Random();
        protected static Regex RollRegex = new Regex(@"(?<Sides>\d{1,})([dD])(?<Dice>\d{1,})(?<Bonus>([+-]{1,1})(\d{1,}))?");

        public static int Roll(string roll)
        {
            return Roll(roll, DiceOptions.None);
        }
        public static int Roll(string roll, DiceOptions options)
        {
            int sides, dice, bonus;
            sides = Parse(roll, out bonus, out dice).DiceSides;

            return Roll(sides, dice, bonus, options);
        }
        public static int Roll(int sides, int dice, int bonus)
        {
            return Roll(sides, dice, bonus, DiceOptions.None);
        }
        public static int Roll(int sides, int dice, int bonus, DiceOptions options)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < dice; i++)
            {
                int roll = R.Next(1, sides);
                rolls.Add(roll);
                if ((i + 1 == dice) && roll == sides && options.HasFlag(DiceOptions.ExplodingDice))
                {
                    // recursively reroll exploding dice
                    rolls.Add(Roll(sides, 1, 0, options));
                }
            }

            if (options.HasFlag(DiceOptions.DropLowest))
            {
                rolls.Remove(rolls.Min());
            }

            int result = rolls.Sum();

            result += bonus;

            return result;
        }

        public static Dice Parse(string diceString, out int bonus, out int diceCount)
        {
            int sides = 0;
            diceCount = 0;
            bonus = 0;
            Match isRoll = RollRegex.Match(diceString.Replace(" ", string.Empty));
            if (isRoll.Success)
            {
                if (!string.IsNullOrEmpty(isRoll.Groups["Sides"].Value))
                    sides = int.Parse(isRoll.Groups["Sides"].Value);
                if (!string.IsNullOrEmpty(isRoll.Groups["Dice"].Value))
                    diceCount = int.Parse(isRoll.Groups["Dice"].Value);
                if (!string.IsNullOrEmpty(isRoll.Groups["Bonus"].Value))
                    bonus = int.Parse(isRoll.Groups["Bonus"].Value);

                return new Dice(sides);
            }
            else
                return null;
        }
        #endregion
    }
}
