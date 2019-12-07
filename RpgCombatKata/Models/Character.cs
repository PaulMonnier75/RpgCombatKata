using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgCombatKata.Models
{
    public class Character
    {
        public List<Guid> FactionIds { get; protected set; }
        public double Health { get; protected set; }
        public int Level { get; protected set; }
        public bool IsAlive { get; protected set; }

        public Character(bool isAlive = true, int level = 1)
        {
            Health = 1000;
            Level = level;
            IsAlive = isAlive;
            FactionIds = new List<Guid>();
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
            if (this == targetedCharacter || IsInTheSameFaction(targetedCharacter)) return;

            var computedDamages = ComputeDemageToInflict(targetedCharacter.Level, damages);
            targetedCharacter.ReceivedDamages(computedDamages);
        }

        private bool IsInTheSameFaction(Character otherCharacter) 
            => otherCharacter.FactionIds.Intersect(FactionIds).Any();

        public void Heal()
        {
            if (IsAlive ) Health = 1000;
        }

        public void HealSomeone(Character injuredCharacter)
        {
            if (injuredCharacter.IsAlive && IsInTheSameFaction(injuredCharacter))
                injuredCharacter.Health = 1000;
        }

        public void JoinFaction(Guid factionId) => FactionIds.Add(factionId);
        
        public void LeaveFaction(Guid factionId) => FactionIds.Remove(factionId);
    }
}
