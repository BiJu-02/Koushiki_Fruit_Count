using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitMessage : IGameMessage
{
    public bool correct;
    public SubmitMessage(bool correct)
    {
        this.correct = correct;
    }
}
