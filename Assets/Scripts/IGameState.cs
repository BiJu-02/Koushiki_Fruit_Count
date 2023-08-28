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
        public void StartState(GameManager ctx, IGameMessage msg);
        public void UpdateState(GameManager ctx);
        public void StopState(GameManager ctx, IGameMessage msg);
    }
}
