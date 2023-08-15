using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Play playState = new();
    public Submited submittedState = new();

    public IGameState CurrState = null;

    void Start()
    {
        // add eventlisteners to all buttons here
        Glob.Ctx.Submit.onClick.AddListener(UIManager.SubmitButt);
        Glob.Ctx.PlayAgain.onClick.AddListener(UIManager.PlayAgainButt);
        Glob.Ctx.Exit.onClick.AddListener(UIManager.ExitButt);

        CurrState = playState;
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

    public static void DestroyObj(GameObject obj)
    { Destroy(obj); }

}
