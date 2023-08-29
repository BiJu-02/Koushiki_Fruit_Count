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
            int oCnt = UnityEngine.Random.Range(1, Glob.Ctx.maxObjects - totalCount > 5 ? 5 : Glob.Ctx.maxObjects - totalCount);
            totalCount += oCnt;
            int oIdx = UnityEngine.Random.Range(0, Glob.Ctx.sprites[Glob.Ctx.curr_mode_idx].spawnObj.Count);
            while (Glob.Ctx.objectiveList.Exists(x => x.fruitIdx == oIdx))
            { oIdx = UnityEngine.Random.Range(0, Glob.Ctx.sprites[Glob.Ctx.curr_mode_idx].spawnObj.Count); }
            prmpt += oCnt.ToString() + " " + Glob.Ctx.sprites[Glob.Ctx.curr_mode_idx].spawnObj[oIdx].name + "; ";
            Glob.Ctx.objectiveList.Add(new PromptObjective(oIdx, oCnt));
        }
        Glob.Ctx.totalObjectiveObj = totalCount;
        Glob.Ctx.promptText.text = prmpt;
    }
    
}
