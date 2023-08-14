using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class Submited : IGameState
    {
        public void StartState(GameManager Ctx)
        {
            Glob.Ctx.gameEndPanel.SetActive(true);
            Ctx.enabled = false;
        }

        public void StopState(GameManager Ctx)
        {
            Glob.Ctx.gameEndPanel.SetActive(false);
            Ctx.enabled = true;
        }

        public void UpdateState(GameManager Ctx)
        {
            Debug.Log("This function is not called...If you are seeing this in console...RUN!!!");
        }
    }
}
