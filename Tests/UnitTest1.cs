using System;
using RpgCombatKata.Models;
using Shouldly;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "When creating character then default values should be setted")]
        public void CharacterCreation()
        {
            var newAliveCharacter = new Character();
            var newDeadCharacter = new Character(false);

            CheckDefaultValue(newAliveCharacter, true);
            CheckDefaultValue(newDeadCharacter, false);
        }

        private static void CheckDefaultValue(Character characterUnderTest, bool isAlive)
        {
            characterUnderTest.Health.ShouldBe(1000);
            characterUnderTest.Level.ShouldBe(1);
            characterUnderTest.IsAlive.ShouldBe(isAlive);
        }
    }
}
