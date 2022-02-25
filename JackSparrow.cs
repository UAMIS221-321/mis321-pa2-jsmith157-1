namespace mis321_pa2_jsmith157_1
{
    public class JackSparrow : Character
    {
        public JackSparrow()
        {
            this.Name = "Jack Sparrow";
            AttackBehavior = new DistractOpponent();
        }
    }
    
}