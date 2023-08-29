using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    public static void Init()
    {
        Glob.Ctx.Submit.onClick.AddListener(UIManager.SubmitButt);
        Glob.Ctx.PlayAgain.onClick.AddListener(UIManager.PlayAgainButt);
        Glob.Ctx.Exit.onClick.AddListener(UIManager.ExitButt);
        for (int i = 0; i < Glob.Ctx.modeButtonList.Count; i++)
        {
            var x = i;
            Glob.Ctx.modeButtonList[x].onClick.AddListener(() => { UIManager.ModeButt(x); });
        }
    }

    public static void ModeButt(int m_idx)
    { Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.playState, new PlayMessage(m_idx)); }

    public static void SubmitButt()
    {
        Debug.Log("Clicked");
        bool success = true;
        if (Glob.Ctx.totalObjectiveObj != Glob.Ctx.TotalObjInContainer)
        { LifeCounter.DecLife(); success = false; }
        else
        {
            for (int i = 0; i < Glob.Ctx.objectiveList.Count; i++)
            {
                int fCnt = Glob.Ctx.objectiveList[i].count;
                string currFruit = Glob.Ctx.sprites[Glob.Ctx.curr_mode_idx].spawnObj[Glob.Ctx.objectiveList[i].fruitIdx].name;
                for (int j = 0; j < Glob.Ctx.placedInContainer.Count; j++)
                {
                    if (Glob.Ctx.placedInContainer[j] == currFruit)
                    { fCnt--; }
                }
                if (fCnt != 0)
                { LifeCounter.DecLife(); success = false; break; }
            }
        }

        if (success)
        { Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.submittedState, new SubmitMessage(true)); }
        else if (Glob.Ctx.lives < 1)
        { Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.submittedState, new SubmitMessage(false)); }
        else
        { Debug.Log("life gone"); }
    }


    public static void PlayAgainButt()
    {
        Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.playState);
    }

    public static void ExitButt()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    
}
