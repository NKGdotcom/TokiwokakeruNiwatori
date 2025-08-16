using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleStart : ButtonTransition
{
    [Header("�X�e�[�W�I�����")]
    [SerializeField] private GameObject stageSelectUI;
    [Header("�^�C�g���{�^��")]
    [SerializeField] private GameObject titleButtonUI;
    [Header("�X�^�[�g�{�^��")]
    [SerializeField] private Button startButton;
    [Header("�X�e�[�W�{�^��")]
    [SerializeField] private Button[] stageButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OpenStageSelect);

        for (int i =0;i < stageButton.Length; i++)
        {
            int _index = i;
            stageButton[i].onClick.AddListener(() => GoToStage(_index));
        }
    }
    /// <summary>
    /// �X�e�[�W�I����ʂ��J��
    /// </summary>
    private void OpenStageSelect()
    {
        titleButtonUI.SetActive(false);
        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        stageSelectUI.SetActive(true);
    }
    /// <summary>
    /// �X�e�[�W�ړ�
    /// </summary>
    /// <param name="_stageNum"></param>
    private void GoToStage(int _stageNum)
    {
        _stageNum++;
        string _stageName = $"Stage{_stageNum}";
        SceneChange(_stageName);
    }
}
