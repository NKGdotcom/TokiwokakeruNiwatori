using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHowToPlay : MonoBehaviour
{
    [Header("�V�ѕ�UI")]
    [SerializeField] private GameObject howToPlayUI;
    [Header("�^�C�g���{�^��")]
    [SerializeField] private GameObject titleButtonUI;
    [Header("�V�ѕ��̃{�^��")]
    [SerializeField] private Button howToPlayButton;
    [Header("�V�ѕ��y�[�W��")]
    [SerializeField] private GameObject[] howToPlayPage;
    [Header("�E���")]
    [SerializeField] private Button rightArrow;
    [Header("�����")]
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
    /// �V�ѕ��y�[�W���J��
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
    /// �y�[�W���J��
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
    /// �y�[�W��߂�
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
