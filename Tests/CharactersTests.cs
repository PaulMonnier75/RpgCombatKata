using System;
using RpgCombatKata.Models;
using Shouldly;
using Xunit;

namespace Tests
{
    public class CharactersTests
    {
        [Fact(DisplayName = "When creating character then default values should be setted")]
        public void CharacterCreation()
        {
            var newAliveCharacter = new Character();
            var newDeadCharacter = new Character(false);

            CheckDefaultValue(newAliveCharacter, true);
            CheckDefaultValue(newDeadCharacter, false);
        }

        private void CheckDefaultValue(Character characterUnderTest, bool isAlive)
        {
            characterUnderTest.Health.ShouldBe(1000);
            characterUnderTest.Level.ShouldBe(1);
            characterUnderTest.IsAlive.ShouldBe(isAlive);
        }

        [Fact(DisplayName = "When charcater attacks another character then its life should be decremented")]
        public void CharacterAttack()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attacks(character2, 20);

            character2.Health.ShouldBe(980);
            character2.IsAlive.ShouldBeTrue();
        }

        [Fact(DisplayName = "When charcater attacks another character the it should die if not enough life")]
        public void CharacterAttackAndKill()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attacks(character2, 1001);

            character2.Health.ShouldBe(-1);
            character2.IsAlive.ShouldBeFalse();
        }

        [Fact(DisplayName = "A character can heal another character if he is alive")]
        public void CharacterCanHealAnotherCharacter()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attacks(character2, 900);

            character2.Health.ShouldBe(100);
            character2.IsAlive.ShouldBeTrue();

            character2.Heal();
            character2.Health.ShouldBe(1000);
        }

        [Fact(DisplayName = "A character can't heal another character if he is dead")]
        public void CharacterTriesToHealADeadFriend()
        {
            var character1 = new Character();
            var character2 = new Character();

            character1.Attacks(character2, 1200);

            character2.Health.ShouldBe(-200);
            character2.IsAlive.ShouldBeFalse();

            character2.Heal();

            character2.Health.ShouldBe(-200);
            character2.IsAlive.ShouldBeFalse();
        }

        [Fact(DisplayName = "A character tries to mutilate himself")]
        public void CharacterTriesToMutilateHimself()
        {
            var character1 = new Character();
            
            character1.Attacks(character1, 100);

            CheckDefaultValue(character1, true);
        }

        [Fact(DisplayName = "A character attacks stronger & weaker characters")]
        public void CharacterAttacksAnotherCharacter()
        {
            var character1 = new Character(level:10);
            var character2 = new Character(level:20);
            var character3 = new Character(level:5);

            character1.Attacks(character2, 100);
            character2.IsAlive.ShouldBeTrue();
            character2.Health.ShouldBe(950);

            character1.Attacks(character3, 100);
            character3.IsAlive.ShouldBeTrue();
            character3.Health.ShouldBe(850);
        }

        [Fact(DisplayName = "A character can join a faction")]
        public void CharcaterJoinAFaction()
        {
            var character = new Character();
            var faction = new Faction();

            faction.AddMember(character);

            faction.Members.ShouldContain(character);
            character.FactionIds.ShouldContain(faction.Id);
        }

        [Fact(DisplayName = "A character can leave a faction")]
        public void CharcaterLeaveAFaction()
        {
            var character = new Character();
            var faction = new Faction();

            faction.AddMember(character);
            faction.RemoveMember(character);
            faction.Members.ShouldNotContain(character);
            character.FactionIds.ShouldNotContain(faction.Id);
        }

        [Fact(DisplayName = "Two Characters who joined the same faction can't fight")]
        public void TwoCharacterInTheSameFactionCantFight()
        {
            var faction = new Faction();
            var character1 = new Character();
            var character2 = new Character();

            faction.AddMember(character1);
            faction.AddMember(character2);

            character1.Attacks(character2, 100);
            character2.Health.ShouldBe(1000);
        }

        [Fact(DisplayName = "One character from a faction attacks an unfactioned character")]
        public void TwoCharacterFromDifferentFactionFight()
        {
            var faction = new Faction();
            var character1 = new Character();
            var character2 = new Character();

            faction.AddMember(character1);

            character1.Attacks(character2, 100);
            character2.Health.ShouldBe(900);
        }

        [Fact(DisplayName = "Two charcters from the same faction can Heal themselve")]
        public void TwoCharacyersFromSameFactionCanHealThemeselve()
        {
            var faction = new Faction();
            var character1 = new Character();
            var character2 = new Character();
            var character3 = new Character();

            faction.AddMember(character1);
            faction.AddMember(character2);

            character3.Attacks(character2, 100);
            character3.HealSomeone(character2);
            character2.Health.ShouldBe(900);
            
            character1.HealSomeone(character2);
            character2.Health.ShouldBe(1000);
        }
    }
}
