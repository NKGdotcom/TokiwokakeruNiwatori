using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHowToPlay : MonoBehaviour
{
    [Header("遊び方UI")]
    [SerializeField] private GameObject howToPlayUI;
    [Header("タイトルボタン")]
    [SerializeField] private GameObject titleButtonUI;
    [Header("遊び方のボタン")]
    [SerializeField] private Button howToPlayButton;
    [Header("遊び方ページ数")]
    [SerializeField] private GameObject[] howToPlayPage;
    [Header("右矢印")]
    [SerializeField] private Button rightArrow;
    [Header("左矢印")]
    [SerializeField] private Button leftArrow;

    private int nowPageNum = 0;
    private int maxPageNum;
    // Start is called before the first frame update
    void Start()
    {
        maxPageNum = howToPlayPage.Length - 1;

        howToPlayButton.onClick.AddListener(OpenHowToPlayPage);
        rightArrow.onClick.AddListener(NextPage);
        leftArrow.onClick.AddListener(BackPage);
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// 遊び方ページを開く
    /// </summary>
    private void OpenHowToPlayPage()
    {
        titleButtonUI.SetActive(false);
        howToPlayUI.SetActive(true);

        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        howToPlayPage[nowPageNum].SetActive(true);
        if(nowPageNum != 0) leftArrow.gameObject.SetActive(true);
        if(nowPageNum != maxPageNum) rightArrow.gameObject.SetActive(true);
    }
    /// <summary>
    /// ページを開く
    /// </summary>
    private void NextPage()
    {
        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        howToPlayPage[nowPageNum].SetActive(false);
        nowPageNum++;
        howToPlayPage[nowPageNum].SetActive(true);
        leftArrow.gameObject.SetActive(true);
        if(nowPageNum <= maxPageNum ) rightArrow.gameObject.SetActive(false);
    }
    /// <summary>
    /// ページを戻す
    /// </summary>
    private void BackPage()
    {
        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        Debug.Log("OK");
        howToPlayPage[nowPageNum].SetActive(false);
        nowPageNum--;
        howToPlayPage[nowPageNum].SetActive(true);
        rightArrow.gameObject.SetActive(true);
        if (nowPageNum <= 0) leftArrow.gameObject.SetActive(false);
    }
}
