using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BotState
{
    public void OnEnter();
    public void OnExcute();
    public void OnExit();
}