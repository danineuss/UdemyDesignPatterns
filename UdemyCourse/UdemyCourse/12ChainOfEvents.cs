using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public abstract class Creature
    {
        private int attack, defense;
        protected Game game;

        public int Attack
        {
            get
            {
                var q = new Query(this.GetType().Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(this.GetType().Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public Creature(Game game, int attack, int defense)
        {
            this.game = game;
            this.attack = attack;
            this.defense = defense;
        }

    }

    public class Goblin : Creature
    {
        public Goblin(Game game) : base(game, 1, 1)
        {
        }

        protected Goblin(Game game, int baseAttack, int baseDefense) : 
            base(game, baseAttack, baseDefense)
        {
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game, 3, 3)
        {            
        }

        protected GoblinKing(Game game, int baseAttack, int baseDefense) :
            base(game, baseAttack, baseDefense)
        {
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
        public event EventHandler<Query> Queries;
        public void PerformQuery(Object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }

        public override string ToString()
        {
            string output = "";
            output = $"Game contains {Creatures.Count} creatures \n";
            foreach (var creature in Creatures)
            {
                output += $"{creature.GetType().Name} \n";
            }
            return output;
        }
    }

    public class Query
    {
        public string CreatureName;
        public enum Argument
        {
            Attack, Defense
        }
        public Argument argument;
        public int Value;

        public Query(string creatureName, Argument argument, int value)
        {
            CreatureName = creatureName;
            this.argument = argument;
            Value = value;
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;

        public CreatureModifier(Game game, Creature creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;
        }

        protected abstract void Handle(Object sender, Query q);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class AttackModifier : CreatureModifier
    {
        public AttackModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == creature.GetType().Name && q.argument == Query.Argument.Attack)
            {
                q.Value += 1;
            }
        }
    }

    public class GoblinHordeBonus : CreatureModifier
    {
        public GoblinHordeBonus(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            int goblinCount = 0;
            foreach (var creature in game.Creatures)
               if (creature.GetType().Name == "Goblin" || creature.GetType().Name == "GoblinKing") goblinCount++;

            if (goblinCount > 2)
            {
                foreach (var creature in game.Creatures)
                {
                    
                }
            }
        }
    }

    public class GoblinKingBonus : CreatureModifier
    {
        public GoblinKingBonus(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            throw new NotImplementedException();
        }
    }

    public class Demo
    {
        public static void Main()
        {
            Game game = new Game();
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new GoblinKing(game));
            Console.WriteLine(game);
        }
    }
}
