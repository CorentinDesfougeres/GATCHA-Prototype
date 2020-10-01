using System.Collections;
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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        //CombatManager.Current.OnCombatStart += LaunchCombatUI();      // ça marche paaaaas !
    }

    public void LaunchCombatUI(object _obj , EventArgs _args)
    {
        return;
    }

}
