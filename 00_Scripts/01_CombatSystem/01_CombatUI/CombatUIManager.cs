﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatUIManager : MonoBehaviour
{
    public static CombatUIManager Current;
    public void Awake()
    {
        if (Current == null)
        {
            Current = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnEnable()
    {
        CombatManager.Current.OnCombatStart += LaunchCombatUI;
    }

    public void LaunchCombatUI()
    {

        return ;
    }

    public void OnDisable()
    {
        CombatManager.Current.OnCombatStart -= LaunchCombatUI;
    }

}
