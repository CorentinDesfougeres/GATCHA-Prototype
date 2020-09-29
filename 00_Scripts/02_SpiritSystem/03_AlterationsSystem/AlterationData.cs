using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AlterationData : ScriptableObject
{
    public string Name;
    public string Description;
    
    public List<Action> Actions;
    public AlterationLifespan Lifespan;
}