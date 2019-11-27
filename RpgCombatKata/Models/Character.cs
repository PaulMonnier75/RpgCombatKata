namespace RpgCombatKata.Models
{
    public class Character
    {
        public int Health { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; }

        public Character(bool isAlive = true)
        {
            Health = 1000;
            Level = 1;
            IsAlive = isAlive;
        }
    }
}
