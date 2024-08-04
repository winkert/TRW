using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public abstract class CharacterBase : GameCore.IGameObject, ISerializable
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

        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CharacterBase(SerializationInfo info, StreamingContext context)
            : this()
        {
            this._name = info.GetString("Name");
            this.CharacterHitPoints = info.GetInt32("CharacterHitPoints");
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
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("CharacterHitPoints", CharacterHitPoints);
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
