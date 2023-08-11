using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Play : IGameState
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

        public void StartState(IGameState gameState)
        {
            selectedObj = null;
            Problem.Generate();
        }

        public void StopState(IGameState gameState)
        { }

        public void UpdateState(IGameState gameState)
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
