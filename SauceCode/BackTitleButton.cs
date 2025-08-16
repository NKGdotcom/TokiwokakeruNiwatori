using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackTitleButton : MonoBehaviour
{
    [Header("タイトルに戻るボタン")]
    [SerializeField] private Button backTitleButtonUI;
    [Header("タイトルUI")]
    [SerializeField] private GameObject titleButtonObject;
    [Header("ステージ選択")]
    [SerializeField] private GameObject stageSelectPage;
    [Header("遊び方")]
    [SerializeField] private GameObject howToPlayPage;
    // Start is called before the first frame update
    void Start()
    {
        backTitleButtonUI.onClick.AddListener(BackTitle);
    }
    /// <summary>
    /// タイトルに戻る
    /// </summary>
    private void BackTitle()
    {
        SoundManager.Instance.PlaySE(SESource.Cancel);
        titleButtonObject.SetActive(true);
        stageSelectPage.SetActive(false);
        howToPlayPage.SetActive(false);
    }
}
