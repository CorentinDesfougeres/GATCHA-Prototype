using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitControllerBehaviour : MonoBehaviour
{
    public abstract void PickAction(UnitBehaviour _unit);

    public delegate void MovePickedHandler(MoveBehaviour _move);
    public event MovePickedHandler OnMovePicked;
    public void InvokeOnMovePicked(MoveBehaviour _move)
    {
        OnMovePicked?.Invoke(_move);
    }
}