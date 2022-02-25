using System;

namespace mis321_pa2_jsmith157_1
{
    public class Character
    {
        public Character()
        {
            Random rand = new Random();

            this.MaxPower = rand.Next(1, 101); 
            this.Health = 100;
            this.Strength = rand.Next(1, MaxPower);
            this.Defense = rand.Next(1, MaxPower);
        }

        public string Name{get; set;}

        public int MaxPower{get; set;}

        public int Health{get; set;}

        public int Strength{get; set;}

        public int Defense{get; set;}

        public int Attack{get; set;}

        public IAttack AttackBehavior{get; set;}
    }

}
