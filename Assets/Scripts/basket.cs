using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Glob.Ctx.TotalFruitInBasket += 1;
        Glob.Ctx.TotalFruitInBasketText.text = "Total Fruit Count: " + Glob.Ctx.TotalFruitInBasket.ToString();
        string fruitName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Glob.Ctx.placedInBasket.Add(fruitName);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        Glob.Ctx.TotalFruitInBasket -= 1;
        Glob.Ctx.TotalFruitInBasketText.text = "Total Fruit Count: " + Glob.Ctx.TotalFruitInBasket.ToString();
        string fruitName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Glob.Ctx.placedInBasket.Remove(fruitName);
    }
}
