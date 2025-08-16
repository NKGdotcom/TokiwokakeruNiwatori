using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNumGet : MonoBehaviour
{
    public static StageNumGet Instance { get; private set; }

    public int StageNum {  get; private set; }

    private string stageName;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        GetStageNum();
    }
    /// <summary>
    /// ステージの番号を取得
    /// </summary>
    private void GetStageNum()
    {
        stageName = SceneManager.GetActiveScene().name;
        stageName = stageName.Replace("Stage", "");
        StageNum = int.Parse(stageName);
    }
}
