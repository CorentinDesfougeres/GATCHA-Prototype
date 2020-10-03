using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitControllerBehaviour : UnitControllerBehaviour
{
    public override void PickAction()
    {
        int _rand = Random.Range(0 , GameManager.Current.GameParameters.nbMovePerSpirit);
        ControlledUnit.WaitingList[0] = ControlledUnit.Moves[_rand];
    }

}
