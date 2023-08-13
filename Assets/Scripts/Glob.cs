using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct PromptObjective
{
    public int fruitIdx;
    public int count;      
    public PromptObjective(int fIdx, int fCnt)
    {
        fruitIdx = fIdx;
        count = fCnt;
    }
}

public class Glob : MonoBehaviour
{
    public static Glob Ctx;     // global context

    public Func<Vector2, Vector2> worldPoint = (pos) => Glob.Ctx.cam.ScreenToWorldPoint(pos);
    public List<string> placedInBasket = new();
    public List<Sprite> spriteList;
    public GameObject fruit;
    public Camera cam;

    public int maxSpawned;
    public int maxFruits;
    public string currPrompt;
    public List<PromptObjective> objectiveList = new();
    public TMP_Text promptText;

    public int TotalFruitInBasket = 0;
    public TMP_Text TotalFruitInBasketText;

    public Button Submit;


    private void Awake()
    {
        if (Ctx != null && Ctx != this) { Destroy(Ctx); }
        else { Ctx = this; }
    }


}
