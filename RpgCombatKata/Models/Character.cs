namespace RpgCombatKata.Models
{
    public abstract class Character
    {
        public readonly Position Position;
        public readonly BaseEquipement BaseEquipement;
        public readonly FightEquipment FightEquipment;
        public readonly HealthEquipment HealthEquipment;

        protected Character(Position position,
            BaseEquipement baseEquipement,
            HealthEquipment healthEquipment,
            FightEquipment fightEquipment)
        {
            Position = position;
            BaseEquipement = baseEquipement;
            HealthEquipment = healthEquipment;
            FightEquipment = fightEquipment;
        }

        public virtual void IsAttacked(double damages) => HealthEquipment.ReceivedDamages(damages);

        public virtual void Attacks(Character targetedCharacter, int damages)
        {
            if (this == targetedCharacter || Faction.IsInTheSameFaction(this, targetedCharacter) ||
                Position.GetDistanceBetween(targetedCharacter.Position) > FightEquipment.AttackRange) 
                return;

            var computedDamages = FightEquipment.ComputeDamageToInflict(
                BaseEquipement.Level, targetedCharacter.BaseEquipement.Level, damages);

            targetedCharacter.IsAttacked(computedDamages);
        }

        public void HealSomeone(Character injuredCharacter)
        {
            if (injuredCharacter.HealthEquipment.IsAlive && Faction.IsInTheSameFaction(this, injuredCharacter))
                injuredCharacter.HealthEquipment.Heal();
        }
    }
}
