using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StageParData
{
    [Header("卵の数")]
    [SerializeField] private int eggNum;
    [Header("時間制限")]
    [SerializeField] private int stageTimer;

    public int EggNum { get => eggNum; }
    public int StageTimer { get => stageTimer; }
}
[CreateAssetMenu(menuName = "ScriptableObjects/Stage/StageParameter",fileName ="StageParameter")]
public class StageParameter : ScriptableObject
{
    public List<StageParData> StageParameterDataList { get => stageParameterDataList; }
    [Header("ステージごとのパラメータ")]
    [SerializeField] private List<StageParData> stageParameterDataList;
}



