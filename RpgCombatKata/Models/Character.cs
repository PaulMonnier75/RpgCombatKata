using System;

namespace RpgCombatKata.Models
{
    public class Character
    {
        public double Health { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; }

        public Character(bool isAlive = true, int level = 1)
        {
            Health = 1000;
            Level = level;
            IsAlive = isAlive;
        }

        private void ReceivedDamages(double damages)
        {
            Health -= damages;

            if (Health < 0) IsAlive = false;
        }

        private double ComputeDemageToInflict(int victimLevel, double damage)
        {
            var levelDifference = victimLevel - Level;

            if (levelDifference >= 5)
                return (damage - damage * 0.5);

            if (levelDifference <= -5)
                return (damage + damage * 0.5);

            return damage;
        }

        public void Attacks(Character targetedCharacter, int damages)
        {
            if (this == targetedCharacter) return;
            
            var computedDamages = ComputeDemageToInflict(targetedCharacter.Level, damages);
            targetedCharacter.ReceivedDamages(computedDamages);
        }

        public void Heal()
        {
            if (IsAlive) Health = 1000;
        }
    }
}
