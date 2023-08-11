using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawn(UnityEngine.Random.Range(0, 10));
        }
    }
    public static GameObject Spawn(int spawnableIdx)
    {
        GameObject newFruit = Instantiate(Glob.Ctx.fruit, new Vector3(UnityEngine.Random.Range(-3.0f, -1.0f), -2.5f, 0), Quaternion.identity);
        newFruit.GetComponent<SpriteRenderer>().sprite = Glob.Ctx.spriteList[spawnableIdx];
        return newFruit;
    }
}
