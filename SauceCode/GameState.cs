using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public enum State{GameWaitTime,Normal,TimeStop,TimeLimit,Result}
    public State NowState { get; private set; }
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetState(State.GameWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_state"></param>
    public void SetState(State _changeState)
    {
        NowState = _changeState;
    }
    /// <summary>
    /// �Q�[���X�^�[�g�O�̑҂�����
    /// </summary>
    /// <returns></returns>
    public bool IsGameWaitTime()
    {
        return NowState == State.GameWaitTime;
    }
    /// <summary>
    /// �ʏ���
    /// </summary>
    /// <returns></returns>
    public bool IsNormal()
    {
        return NowState == State.Normal;
    }
    /// <summary>
    /// �����~�߂Ă���
    /// </summary>
    /// <returns></returns>
    public bool IsTimeStop()
    {
        return NowState == State.TimeStop;
    }
    /// <summary>
    /// ���U���g���
    /// </summary>
    /// <returns></returns>
    public bool IsResult()
    {
        return NowState == State.Result;
    }
    /// <summary>
    /// ���Ԑ����������Ƃ�
    /// </summary>
    /// <returns></returns>
    public bool IsTimeLimited()
    {
        return NowState == State.TimeLimit;
    }
}
