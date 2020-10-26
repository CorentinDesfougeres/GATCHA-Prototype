using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitControllerBehaviour : UnitControllerBehaviour
{
    public override void PickAction(UnitBehaviour _unit)
    {
        Debug.Log("PickActionIA");
        int _rand = Random.Range(0 , GameManager.Current.GameParameters.nbMovePerSpirit);
        InvokeOnMovePicked(_unit.Moves[_rand]);
    }

}
