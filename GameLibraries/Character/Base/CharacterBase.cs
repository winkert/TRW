using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using TRW.CommonLibraries.Serialization;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public abstract class CharacterBase : GameCore.IGameObject, IBinarySerializable
    {
        #region Fields
        protected string _name;
        protected Dictionary<Attributes, int> _attributes;
        #endregion

        #region Constructors
        public CharacterBase()
        {
            CharacterHitPoints = 0;
            CharacterHealth = HealthStates.FullHealth;
            IsAlive = true;
            _attributes = new Dictionary<Attributes, int>(TotalAttributes);
        }

        #endregion

        #region Properties
        public string Name => _name;
        public abstract int CharacterLevel { get; }
        public virtual int CharacterHitPoints { get; protected set; }
        public virtual HealthStates CharacterHealth { get; protected set; }
        public virtual bool IsAlive { get; protected set; }

        protected virtual int TotalAttributes { get; } = 6;
        protected virtual string AttributeRoll { get; } = "3d6";
        protected virtual GameCore.DiceOptions AttributeDiceRollOptions { get; } = GameCore.DiceOptions.None;
        protected virtual int MinimumAttributeSum { get; } = 60;

        public int Strength => _attributes[Attributes.Strength];
        public int Dexterity => _attributes[Attributes.Dexterity];
        public int Constitution => _attributes[Attributes.Constitution];
        public int Intelligence => _attributes[Attributes.Intelligence];
        public int Wisdom => _attributes[Attributes.Wisdom];
        public int Charisma => _attributes[Attributes.Charisma];

        public string Description => "Game Character";

        public bool IsPlayable => true;
        #endregion

        #region Methods
        public byte[] ToByteArray()
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                WriteTo(writer);
                return ms.ToArray(); // Return serialized data as byte array
            }
        }
        public virtual void WriteTo(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(CharacterHitPoints);
        }
        public virtual void ReadFrom(BinaryReader reader)
        {
            this._name = reader.ReadString();
            this.CharacterHitPoints = reader.ReadInt32();
        }

        public int[] RollAttributes()
        {
            int[] attributes = new int[TotalAttributes];
            for (int i = 0; i < TotalAttributes; i++)
                attributes[i] = RollAttribute();

            // reroll on low rolls.
            if (attributes.Sum() < MinimumAttributeSum)
                attributes = RollAttributes();

            return attributes;
        }

        public int RollAttribute()
        {
            return GameCore.Dice.Roll(AttributeRoll, AttributeDiceRollOptions);
        }
        #region Static
        public static int[] RollAttributes<T>() where T : CharacterBase, new()
        {
            return new T().RollAttributes();
        }
        public Attributes GetAttribute(int val)
        {
            switch (val)
            {
                case 0:
                    return Attributes.Strength;
                case 1:
                    return Attributes.Dexterity;
                case 2:
                    return Attributes.Constitution;
                case 3:
                    return Attributes.Intelligence;
                case 4:
                    return Attributes.Wisdom;
                case 5:
                    return Attributes.Charisma;
                default:
                    return Attributes.Players_Choice;
            }
        }
        #endregion

        public void TakeDamage(int damageTaken)
        {
            ApplyHealthChange(-1 * damageTaken);
        }

        public void BeHealed(int healingApplied)
        {
            ApplyHealthChange(healingApplied);
        }

        protected abstract void ApplyHealthChange(int healthChange);

        public virtual void GameTimerTick()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
