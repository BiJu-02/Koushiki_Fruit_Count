using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class Submited : IGameState
    {
        public void StartState(GameManager Ctx, IGameMessage msg)
        {
            Glob.Ctx.gameEndPanel.SetActive(true);
            SubmitMessage sMsg = (SubmitMessage)msg;
            Glob.Ctx.SuccessText.text = sMsg.correct ? "Correct!" : "You lost all lives";
            Ctx.enabled = false;
        }

        public void StopState(GameManager Ctx, IGameMessage msg = null)
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
