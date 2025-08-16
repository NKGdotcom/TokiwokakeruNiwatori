using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StageParData
{
    [Header("���̐�")]
    [SerializeField] private int eggNum;
    [Header("���Ԑ���")]
    [SerializeField] private int stageTimer;

    public int EggNum { get => eggNum; }
    public int StageTimer { get => stageTimer; }
}
[CreateAssetMenu(menuName = "ScriptableObjects/Stage/StageParameter",fileName ="StageParameter")]
public class StageParameter : ScriptableObject
{
    public List<StageParData> StageParameterDataList { get => stageParameterDataList; }
    [Header("�X�e�[�W���Ƃ̃p�����[�^")]
    [SerializeField] private List<StageParData> stageParameterDataList;
}



