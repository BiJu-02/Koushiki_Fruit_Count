using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public static void Spawn()
    {
        int n = Glob.Ctx.objectiveList.Count;
        int totalSpawned = 0;
        for (int i = 0; i < n; i++)
        {
            int m = Glob.Ctx.objectiveList[i].count;
            m += UnityEngine.Random.Range(0, Glob.Ctx.maxSpawned - totalSpawned > 6 - m ? 6 - m : Glob.Ctx.maxSpawned - totalSpawned);
            for (int j = 0; j < m; j++)
            {
                GameObject newFruit = Instantiate(Glob.Ctx.fruit, new Vector3(UnityEngine.Random.Range(-3.0f, -1.0f), -2.5f, 0), Quaternion.identity);
                newFruit.GetComponent<SpriteRenderer>().sprite = Glob.Ctx.spriteList[Glob.Ctx.objectiveList[i].fruitIdx];
                Glob.Ctx.spawnedFruitObj.Add(newFruit);
                Debug.Log(newFruit.GetComponent<SpriteRenderer>().sprite.name);
                totalSpawned++;
            }
        }
        while (totalSpawned < Glob.Ctx.maxSpawned)
        {
            GameObject newFruit = Instantiate(Glob.Ctx.fruit, new Vector3(UnityEngine.Random.Range(-3.0f, -1.0f), -2.5f, 0), Quaternion.identity);
            newFruit.GetComponent<SpriteRenderer>().sprite = Glob.Ctx.spriteList[UnityEngine.Random.Range(0, Glob.Ctx.spriteList.Count)];
            Glob.Ctx.spawnedFruitObj.Add(newFruit);
            totalSpawned++;
        }
    }
}
