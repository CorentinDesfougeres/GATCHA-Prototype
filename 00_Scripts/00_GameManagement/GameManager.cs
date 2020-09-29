using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public GameParameters GameParameters;

    public GameState GameState;
    
}