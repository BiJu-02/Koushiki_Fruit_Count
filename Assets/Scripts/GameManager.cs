using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Play playState = new();
    public Submited submittedState = new();

    IGameState CurrState = null;

    void Start()
    {
        CurrState = playState;
        CurrState.StartState(CurrState);
    }


    // Update is called once per frame
    void Update()
    {
        CurrState.UpdateState(CurrState);
    }


}
