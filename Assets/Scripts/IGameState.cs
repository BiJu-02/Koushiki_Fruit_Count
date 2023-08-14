using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IGameState
    {
        public void StartState(GameManager Ctx);
        public void UpdateState(GameManager Ctx);
        public void StopState(GameManager Ctx);
    }
}
