using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static void SubmitButt()
    {
        Debug.Log("Clicked");
        bool success = true;
        if (Glob.Ctx.totalObjectiveFruits != Glob.Ctx.TotalFruitInBasket)
        { Glob.Ctx.lives -= 1; success = false; }
        else
        {
            for (int i = 0; i < Glob.Ctx.objectiveList.Count; i++)
            {
                int fCnt = Glob.Ctx.objectiveList[i].count;
                string currFruit = Glob.Ctx.spriteList[Glob.Ctx.objectiveList[i].fruitIdx].name;
                for (int j = 0; j < Glob.Ctx.placedInBasket.Count; j++)
                {
                    if (Glob.Ctx.placedInBasket[j] == currFruit)
                    { fCnt--; }
                }
                if (fCnt != 0)
                { Glob.Ctx.lives -= 1; success = false; break; }
            }
        }

        if (success)
        { Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.submittedState); }
        else if (Glob.Ctx.lives < 1)
        { Glob.Ctx.gameManager.SwitchState(Glob.Ctx.gameManager.submittedState); }
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
