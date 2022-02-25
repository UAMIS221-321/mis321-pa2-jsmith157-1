namespace mis321_pa2_jsmith157_1
{
    public class Sword : IAttack
    {
        public void Attack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int damage = rand.Next(1, attacker.Strength);
            defender.Health -= damage;

            Console.WriteLine("{0}'s Sword attack did {1} damage to {2}", attacker.Name, damage, defender.Name);
        }
    }
}