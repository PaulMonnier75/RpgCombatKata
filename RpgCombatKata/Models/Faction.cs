using System;
using System.Collections.Generic;

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
            newMember.JoinFaction(Id);
        }

        public void RemoveMember(Character oldMember)
        {
            Members.Remove(oldMember);
            oldMember.LeaveFaction(Id);
        }

        public bool CanAttack(Character attacker, Character victim) 
            => !Members.Contains(attacker) || !Members.Contains(victim);
    }
}
