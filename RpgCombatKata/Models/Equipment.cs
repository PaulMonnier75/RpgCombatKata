using System;
using System.Collections.Generic;

namespace RpgCombatKata.Models
{
    public class HealthEquipment
    {
        public double LifePoints { get; private set; }
        public bool IsAlive { get; private set; }

        public HealthEquipment(bool isAlive)
        {
            IsAlive = isAlive;
            LifePoints = 1000;
        }

        public void ReceivedDamages(double damages)
        {
            LifePoints -= damages;
            IsAlive = !(LifePoints <= 0);
        }

        public void Heal() => LifePoints = IsAlive ? 1000 : LifePoints;
    }

    public class FightEquipment
    {
        public int AttackRange { get; set; }

        public FightEquipment(int attackRange)
            => AttackRange = attackRange;

        public double ComputeDamageToInflict(int attackantLevel, int victimLevel, double damage)
        {
            var levelDifference = victimLevel - attackantLevel;

            if (levelDifference >= 5)
                return (damage - damage * 0.5);

            if (levelDifference <= -5)
                return (damage + damage * 0.5);

            return damage;
        }
    }

    public class BaseEquipement
    {
        public int Level { get; protected set; }
        public List<Guid> FactionIds { get; protected set; }

        public BaseEquipement(int level)
        {
            Level = level;
            FactionIds = new List<Guid>();
        }

        public void JoinFaction(Guid factionId) => FactionIds.Add(factionId);

        public void LeaveFaction(Guid factionId) => FactionIds.Remove(factionId);
    }
}
