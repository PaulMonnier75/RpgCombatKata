namespace RpgCombatKata.Models
{
    public class MeleeFighter : Character
    {
        public MeleeFighter(bool isAlive = true, int level = 1)
            : base(
                InitializeBaseEquipment(level),
                InitalizeHealthEquipment(isAlive),
                InitializeFightEquipment())
        { }

        private static HealthEquipment InitalizeHealthEquipment(bool isAlive)
            => new HealthEquipment(isAlive);

        private static FightEquipment InitializeFightEquipment()
            => new FightEquipment(2);

        private static BaseEquipement InitializeBaseEquipment(int level)
            => new BaseEquipement(level);
    }

    public class RangedFighter : Character
    {
        public RangedFighter(bool isAlive = true, int level = 1)
            : base(
                InitializeBaseEquipment(level),
                InitalizeHealthEquipment(isAlive),
                InitializeFightEquipment())
        { }

        private static HealthEquipment InitalizeHealthEquipment(bool isAlive)
            => new HealthEquipment(isAlive);

        private static FightEquipment InitializeFightEquipment()
            => new FightEquipment(20);

        private static BaseEquipement InitializeBaseEquipment(int level)
            => new BaseEquipement(level);
    }
}
