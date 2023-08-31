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

[System.Serializable]
public class SpriteNames
{
    public List<Sprite> spawnObj; // list of spawnable objects sprite
    public Sprite bg;       // background sprite
    public Sprite container;       // container sprite
}


public enum Clips
{
    start,
    win,
    fail,
    lost,
    touch
}


public class Glob : MonoBehaviour
{
    public static Glob Ctx;     // global context

    public GameManager gameManager;

    public Func<Vector2, Vector2> worldPoint = (pos) => Glob.Ctx.cam.ScreenToWorldPoint(pos);
    public List<SpriteNames> sprites;
    public GameObject objPref;
    public Camera cam;

    public List<AudioClip> clipList;

    public GameObject ModePanel;
    public List<Button> modeButtonList = new();
    public int curr_mode_idx;
    public GameObject BackGround;
    public GameObject Container;

    public int maxSpawned;      // actually spawned
    public int maxObjects;      // for prompt

    public GameObject GamePlayUI;

    public string currPrompt;
    public List<PromptObjective> objectiveList = new();
    public TMP_Text promptText;
    public int totalObjectiveObj;
    public List<GameObject> spawnedObj;

    public List<string> placedInContainer = new();
    public int TotalObjInContainer = 0;
    public TMP_Text TotalObjectInConatinerText;

    public Button Submit;
    public int lives;
    public GameObject life;

    public GameObject gameEndPanel;
    public TMP_Text SuccessText;
    public Button PlayAgain;
    public Button Exit;


    private void Awake()
    {
        if (Ctx != null && Ctx != this) { Destroy(Ctx); }
        else { Ctx = this; }
    }


}
