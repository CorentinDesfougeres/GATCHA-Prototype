using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitControllerBehaviour : UnitControllerBehaviour
{
    public delegate void MoveSelectionHandler(UnitBehaviour unit);
    public event MoveSelectionHandler OnMoveSelectionStarted;
    public override void PickAction()
    {
        OnMoveSelectionStarted.Invoke(ControlledUnit);
    }

    public void ProcessChoice(MoveBehaviour _move)
    {
        ControlledUnit.WaitingList[0] = _move;
    }


}