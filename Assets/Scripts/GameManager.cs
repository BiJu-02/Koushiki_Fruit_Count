using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SelectMode selectModeState = new();
    public Play playState = new();
    public Submited submittedState = new();

    public IGameState CurrState = null;

    void Start()
    {
        UIManager.Init();

        CurrState = selectModeState;
        CurrState.StartState(this, null);
    }


    // Update is called once per frame
    void Update()
    {
        CurrState.UpdateState(this);
    }

    public void SwitchState(IGameState newState, IGameMessage msg = null)
    {
        CurrState.StopState(this, msg);
        CurrState = newState;
        CurrState.StartState(this, msg);
    }
}
