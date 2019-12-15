using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgCombatKata.Models
{
    public class Faction
    {
        public Guid Id { get; }
        public List<Character> Members { get; protected set; }

        public Faction()
        {
            Id = Guid.NewGuid();
            Members = new List<Character>();
        }

        public void AddMember(Character newMember)
        {
            Members.Add(newMember);
            newMember.BaseEquipement.JoinFaction(Id);
        }

        public void RemoveMember(Character oldMember)
        {
            Members.Remove(oldMember);
            oldMember.BaseEquipement.LeaveFaction(Id);
        }

        public static bool IsInTheSameFaction(Character character1, Character character2)
            => character1.BaseEquipement.FactionIds.Intersect(character2.BaseEquipement.FactionIds).Any();
    }
}
