using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class Play : IGameState
    {
        // extra var for this state here
        Fruit selectedObj;
        Vector3 MovPosOff;
        Vector3 WorldPos;
        Func<Vector3, Vector3> worldPoint = (pos) => Camera.main.ScreenToWorldPoint(pos);

        private void CheckHit()
        {
            WorldPos = worldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(WorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                selectedObj = hit.transform.gameObject.GetComponent<Fruit>();
                MovPosOff = hit.collider.transform.position - WorldPos;
            }
        }

        public void StartState(GameManager Ctx, IGameMessage msg = null)
        {
            selectedObj = null;
            Glob.Ctx.placedInBasket.Clear();
            Problem.Generate();
            FruitSpawn.Spawn();
            LifeCounter.InitLife();
        }

        public void StopState(GameManager Ctx, IGameMessage msg = null)
        {
            foreach (var x in Glob.Ctx.spawnedFruitObj)
            { GameManager.DestroyObj(x); }
            Glob.Ctx.spawnedFruitObj.Clear();
            Glob.Ctx.objectiveList.Clear();
            Glob.Ctx.placedInBasket.Clear();
            Glob.Ctx.currPrompt = "";
            Glob.Ctx.promptText.text = "";
            Glob.Ctx.TotalFruitInBasket = 0;
            Glob.Ctx.TotalFruitInBasketText.text = "";
            Glob.Ctx.totalObjectiveFruits = 0;
            Glob.Ctx.lives = 3;
        }

        public void UpdateState(GameManager Ctx)
        {
            // input and stuff here for drag and drop
            if (Input.GetMouseButtonDown(0))
            { CheckHit(); }
            else if (Input.GetMouseButton(0) && selectedObj != null)
            { selectedObj.gameObject.transform.position = worldPoint(Input.mousePosition) + MovPosOff; }
            else if (Input.GetMouseButtonUp(0))
            { selectedObj = null; }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                { CheckHit(); }
                else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && selectedObj != null)
                { selectedObj.gameObject.transform.position = worldPoint(touch.position) + MovPosOff; }
                else
                { selectedObj = null; }
            }
            else { return; }
        }
        
    }
}
