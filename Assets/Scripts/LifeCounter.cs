using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public static LifeCounter Instance;
    public static List<GameObject> lives = new();

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(Instance); }
        else { Instance = this; }
    }
    public static void InitLife()
    {
        while (lives.Count > 0)
        {
            Destroy(lives[lives.Count - 1]);
            lives.RemoveAt(lives.Count - 1);
        }
        for (int i = 0; i < 3; i++)
        { lives.Add(Instantiate(Glob.Ctx.life, new Vector3(Instance.transform.position.x + i - 0.91f, Instance.transform.position.y, 0f), Quaternion.identity)); }
    }

    public static void DecLife()
    {
        Debug.Log("decLife");
        Glob.Ctx.lives -= 1;
        Destroy(lives[lives.Count - 1]);
        lives.RemoveAt(lives.Count - 1);
    }
}
