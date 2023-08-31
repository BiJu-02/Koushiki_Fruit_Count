using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Glob.Ctx.GamePlayUI.GetComponent<AudioSource>().clip = Glob.Ctx.clipList[(int)Clips.touch];
        Glob.Ctx.GamePlayUI.GetComponent<AudioSource>().Play();
        Glob.Ctx.TotalObjInContainer += 1;
        Glob.Ctx.TotalObjectInConatinerText.text = "Total Fruit Count: " + Glob.Ctx.TotalObjInContainer.ToString();
        string fruitName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Glob.Ctx.placedInContainer.Add(fruitName);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        Glob.Ctx.TotalObjInContainer -= 1;
        Glob.Ctx.TotalObjectInConatinerText.text = "Total Fruit Count: " + Glob.Ctx.TotalObjInContainer.ToString();
        string fruitName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Glob.Ctx.placedInContainer.Remove(fruitName);
    }
}
