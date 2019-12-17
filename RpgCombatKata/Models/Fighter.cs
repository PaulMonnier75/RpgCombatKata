namespace RpgCombatKata.Models
{
    public class MeleeFighter : Character
    {
        public MeleeFighter(bool isAlive = true, int level = 1, int x = 0, int y = 0)
            : base(
                InitializePosition(x, y),
                InitializeBaseEquipment(level),
                InitalizeHealthEquipment(isAlive),
                InitializeFightEquipment())
        { }

        private static Position InitializePosition(int x, int y)
            => new Position(x, y);

        private static HealthEquipment InitalizeHealthEquipment(bool isAlive)
            => new HealthEquipment(isAlive);

        private static FightEquipment InitializeFightEquipment()
            => new FightEquipment(2);

        private static BaseEquipement InitializeBaseEquipment(int level)
            => new BaseEquipement(level);
    }

    public class RangedFighter : Character
    {
        public RangedFighter(bool isAlive = true, int level = 1, int x = 0, int y = 0)
            : base(
                InitializePosition(x, y),
                InitializeBaseEquipment(level),
                InitalizeHealthEquipment(isAlive),
                InitializeFightEquipment())
        { }

        private static Position InitializePosition(int x, int y)
            => new Position(x, y);

        private static HealthEquipment InitalizeHealthEquipment(bool isAlive)
            => new HealthEquipment(isAlive);

        private static FightEquipment InitializeFightEquipment()
            => new FightEquipment(20);

        private static BaseEquipement InitializeBaseEquipment(int level)
            => new BaseEquipement(level);
    }
}
