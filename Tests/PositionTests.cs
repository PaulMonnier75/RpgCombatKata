using RpgCombatKata;
using RpgCombatKata.Models;
using Shouldly;
using Xunit;

namespace Tests
{
    public class PositionTests
    {
        [Fact]
        public void GetDistanceBetweenTwoPositions()
        {
            var position1 = new Position(0, 0);
            var position2 = new Position(10, 0);
            var position3 = new Position(15, 5);

            var distance = position1.GetDistanceBetween(position2);
            distance.ShouldBe(10);

            distance = position1.GetDistanceBetween(position3);
            distance.ShouldBe(15);
        }
    }
}
