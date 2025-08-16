using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeStopAbility : MonoBehaviour
{
    void Update()
    {
        if (GameState.Instance.IsNormal())
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (GameState.Instance.IsGameWaitTime()) return;
                TimeStop();
            }
        }
        else if (GameState.Instance.IsTimeStop())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TimeStart();
            }
        } 
    }
    /// <summary>
    /// éûÇêiÇﬂÇÈ
    /// </summary>
    private void TimeStart()
    {
        GameState.Instance.SetState(GameState.State.Normal);
        SoundManager.Instance.PlaySE(SESource.MoveTime);
        Time.timeScale = 1;
    }
    /// <summary>
    /// éûÇé~ÇﬂÇÈ
    /// </summary>
    private void TimeStop()
    {
        GameState.Instance.SetState(GameState.State.TimeStop);
        SoundManager.Instance.PlaySE(SESource.StopTime);
        Time.timeScale = 0;
    }
}
