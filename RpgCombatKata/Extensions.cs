using System;
using RpgCombatKata.Models;

namespace RpgCombatKata
{
    public static class Extensions
    {
        public static int GetDistanceBetween(this Position p1, Position p2)
            => (int) Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
    }
}