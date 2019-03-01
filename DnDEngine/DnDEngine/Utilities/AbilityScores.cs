﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    /// <summary>
    /// Holds a set of ability scores.
    /// These can be added and subtracted.
    /// </summary>
    public struct AbilityScores
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Constitution { get; }
        public int Intelligence { get; }
        public int Wisdom { get; }
        public int Charisma { get; }

        // The modifier for a given ability score is the (score - 10) / 2 and rounded down.
        public int StrengthMod => (int)Math.Floor((double)(Strength - 10) / 2);
        public int DexterityMod => (int)Math.Floor((double)(Dexterity - 10) / 2);
        public int ConstitutionMod => (int)Math.Floor((double)(Constitution - 10) / 2);
        public int IntelligenceMod => (int)Math.Floor((double)(Intelligence - 10) / 2);
        public int WisdomMod => (int)Math.Floor((double)(Wisdom - 10) / 2);
        public int CharismaMod => (int)Math.Floor((double)(Charisma - 10) / 2);

        /// <summary>
        /// Constructor that creates an instance of AbilityScores.
        /// </summary>
        public AbilityScores(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        /// <summary>
        /// Adds two ability scores together.
        /// </summary>
        /// <returns>The sum of the two ability scores.</returns>
        public static AbilityScores operator +(AbilityScores a, AbilityScores b)
        {
            return new AbilityScores(
                a.Strength + b.Strength,
                a.Dexterity + b.Dexterity,
                a.Constitution + b.Constitution,
                a.Intelligence + b.Intelligence,
                a.Wisdom + b.Wisdom,
                a.Charisma + b.Charisma
                );
        }

        /// <summary>
        /// Subtracts one ability score from the other.
        /// </summary>
        /// <returns>The result of the subtraction.</returns>
        public static AbilityScores operator -(AbilityScores a, AbilityScores b)
        {
            return new AbilityScores(
                a.Strength - b.Strength,
                a.Dexterity - b.Dexterity,
                a.Constitution - b.Constitution,
                a.Intelligence - b.Intelligence,
                a.Wisdom - b.Wisdom,
                a.Charisma - b.Charisma
                );
        }
    }
}
