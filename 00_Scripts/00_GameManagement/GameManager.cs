using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Current;
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

    public GameParameters GameParameters;

    public GameStateId GameState;
    
}