using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMessage : IGameMessage
{
    public int mIdx;
    public PlayMessage(int mIdx) { this.mIdx = mIdx; }
}
