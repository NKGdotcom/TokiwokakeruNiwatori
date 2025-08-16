using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int FallObjNum { get => fallObjNum; private set => fallObjNum = value; }

    private int fallObjNum; //落ちていったオブジェクトの数
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    /// <summary>
    /// 飛んで行ったオブジェクトたち
    /// </summary>
    public void FallObjects()
    {
        fallObjNum++;
    }
}
