using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Play playState = new Play();
    Submited submittedState = new Submited();

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
