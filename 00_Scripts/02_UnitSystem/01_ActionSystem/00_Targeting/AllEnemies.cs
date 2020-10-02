using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemies : Targeting
{
    public override UnitBehaviour[] Execute(ActorBehaviour _source)
    {
        List<UnitBehaviour> _temporary = new List<UnitBehaviour>();

        for (int _index = 0; _index < CombatManager.Current.Teams.Count; _index++)
        {
            if (_index != _source.SourceUnit.TeamId )
            {
                foreach (UnitBehaviour _unit in CombatManager.Current.Teams[_index].FieldMembers)
                {
                    _temporary.Add(_unit);
                }
            }
            
        }

        UnitBehaviour[] _targets = new UnitBehaviour[1];
        return _targets;
    }
}
