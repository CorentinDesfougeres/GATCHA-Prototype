using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatModifier
{
    public int Value;

    public StatModifierType Type;

    public object Source;

    public StatModifier(float value, StatModifierType type, object source)
    {
        Value = value;
        Type = type;
        Source = source;
    }    
}