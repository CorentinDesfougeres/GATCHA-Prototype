using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitControllerBehaviour : UnitControllerBehaviour
{
    public override void PickAction(UnitBehaviour _unit)
    {
        int _rand = Random.Range(0 , GameManager.Current.GameParameters.nbMovePerSpirit);
        _unit.WaitingList[0] = _unit.Moves[_rand];
    }

}
