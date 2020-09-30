using UnityEngine;
using System.Collections.Generic;

public class Team
{
    public List<UnitBehaviour> FieldMembers;
    public List<UnitBehaviour> ReserveMembers;

    public Team(int _id , List<UnitBehaviour> _fieldMembers , List<UnitBehaviour> _reserveMembers)
    {
        FieldMembers = _fieldMembers;
        foreach (UnitBehaviour _unit in FieldMembers)
        {
            _unit.TeamId = _id;
        }

        ReserveMembers = _reserveMembers;
        foreach (UnitBehaviour _unit in ReserveMembers)
        {
            _unit.TeamId = _id;
        }
    }
}