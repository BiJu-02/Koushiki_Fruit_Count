using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class SelectMode : IGameState
    {
        public void StartState(GameManager ctx, IGameMessage msg = null)
        {
            Glob.Ctx.ModePanel.SetActive(true);

            ctx.enabled = false;
        }

        public void StopState(GameManager ctx, IGameMessage msg = null)
        {
            Glob.Ctx.ModePanel.SetActive(false);
            ctx.enabled = true;
        }

        public void UpdateState(GameManager ctx)
        {
            
        }
    }
}
