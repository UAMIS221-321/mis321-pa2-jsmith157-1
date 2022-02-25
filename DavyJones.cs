namespace mis321_pa2_jsmith157_1
{
    public class DavyJones : Character
    {
        public DavyJones()
        {
            this.Name = "Davy Jones";
            AttackBehavior = new CannonFire();
        }
    }
}