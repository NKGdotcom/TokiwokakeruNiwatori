using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleStart : ButtonTransition
{
    [Header("ステージ選択画面")]
    [SerializeField] private GameObject stageSelectUI;
    [Header("タイトルボタン")]
    [SerializeField] private GameObject titleButtonUI;
    [Header("スタートボタン")]
    [SerializeField] private Button startButton;
    [Header("ステージボタン")]
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
    /// ステージ選択画面を開く
    /// </summary>
    private void OpenStageSelect()
    {
        titleButtonUI.SetActive(false);
        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        stageSelectUI.SetActive(true);
    }
    /// <summary>
    /// ステージ移動
    /// </summary>
    /// <param name="_stageNum"></param>
    private void GoToStage(int _stageNum)
    {
        _stageNum++;
        string _stageName = $"Stage{_stageNum}";
        SceneChange(_stageName);
    }
}
