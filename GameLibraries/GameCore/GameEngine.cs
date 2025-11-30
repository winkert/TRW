using System;
using System.Collections.Generic;

namespace TRW.GameLibraries.GameCore
{
    public class GameEngine
    {
        public GameEngine() { }

        internal List<GameFact> Facts = new List<GameFact>();
        internal List<GameRule> Rules = new List<GameRule>();

        internal protected void AddFact(GameFact fact)
        {
            Facts.Add(fact);
        }

        internal protected void AddRule(GameRule rule)
        {
            Rules.Add(rule);
        }

        public void Start()
        {
            foreach (var rule in Rules)
            {
                foreach (var fact in Facts)
                {
                    if (rule.ConditionMet(fact))
                    {
                        rule.ExecuteAction(fact);
                    }
                }
            }
        }

        public abstract class GameFact
        {
            public abstract string FactKey { get; set; }
            public abstract int FactValue { get; set; }
        }

        public abstract class GameRule
        {
            public abstract bool ConditionMet(GameFact fact);
            public abstract void ExecuteAction(GameFact fact);
        }
    }

}
