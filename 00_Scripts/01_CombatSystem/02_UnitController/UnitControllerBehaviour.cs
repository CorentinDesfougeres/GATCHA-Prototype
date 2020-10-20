using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitControllerBehaviour : MonoBehaviour
{
    public abstract void PickAction(UnitBehaviour _unit);

    public delegate void MovePickedHandler();
    public event MovePickedHandler OnMovePicked;
    public void InvokeOnMovePicked()
    {
        OnMovePicked?.Invoke();
    }
}