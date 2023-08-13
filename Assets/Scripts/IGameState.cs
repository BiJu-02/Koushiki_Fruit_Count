using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IGameState
    {
        public void StartState(IGameState gameState);
        public void UpdateState(IGameState gameState);
        public void StopState(IGameState gameState);
    }
}
