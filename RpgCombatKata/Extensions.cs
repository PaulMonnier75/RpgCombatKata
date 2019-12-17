using RpgCombatKata.Models;

namespace RpgCombatKata
{
    public static class Extensions
    {
        public static int GetDistance(this Position p1, Position p2)
            => ((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
    }
}