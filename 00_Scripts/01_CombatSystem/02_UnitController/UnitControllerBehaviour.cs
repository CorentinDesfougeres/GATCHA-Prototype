using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitControllerBehaviour : MonoBehaviour
{
    public abstract void PickAction(UnitBehaviour _unit);
    public UnitBehaviour ControlledUnit;
    
    public void Start()
    {
        ControlledUnit = GetComponent<UnitBehaviour>();
    }
}