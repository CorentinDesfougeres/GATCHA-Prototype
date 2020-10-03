using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitControllerBehaviour : UnitControllerBehaviour
{
    public delegate MoveBehaviour MoveSelectionHandler(UnitBehaviour unit);
    public event MoveSelectionHandler OnMoveSelectionStarted;
    public override void PickAction()
    {
        OnMoveSelectionStarted.Invoke(ControlledUnit);
        CombatUIManager.Current.OnMoveSelected += ProcessChoice;
    }

    public void ProcessChoice(MoveBehaviour _move)
    {
        ControlledUnit.WaitingList[0] = _move;

        CombatUIManager.Current.OnMoveSelected -= ProcessChoice;
    }


}