using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Problem : MonoBehaviour
{
    public static void Generate()
    {
        Glob.Ctx.objectiveList.Clear();
        int objCount = UnityEngine.Random.Range(1, 4);
        int totalCount = 0;
        string prmpt = "";
        for (int i = 0; i < objCount; i++)
        {
            int fCnt = UnityEngine.Random.Range(1, Glob.Ctx.maxFruits - totalCount > 5 ? 5 : Glob.Ctx.maxFruits - totalCount);
            totalCount += fCnt;
            int fIdx = UnityEngine.Random.Range(0, Glob.Ctx.spriteList.Count);
            while (Glob.Ctx.objectiveList.Exists(x => x.fruitIdx == fIdx))
            { fIdx = UnityEngine.Random.Range(0, Glob.Ctx.spriteList.Count); }
            prmpt += fCnt.ToString() + " " + Glob.Ctx.spriteList[fIdx].name + "; ";
            Glob.Ctx.objectiveList.Add(new PromptObjective(fIdx, fCnt));
        }
        Glob.Ctx.totalObjectiveFruits = totalCount;
        Glob.Ctx.promptText.text = prmpt;
    }
    
}
