using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackTitleButton : MonoBehaviour
{
    [Header("�^�C�g���ɖ߂�{�^��")]
    [SerializeField] private Button backTitleButtonUI;
    [Header("�^�C�g��UI")]
    [SerializeField] private GameObject titleButtonObject;
    [Header("�X�e�[�W�I��")]
    [SerializeField] private GameObject stageSelectPage;
    [Header("�V�ѕ�")]
    [SerializeField] private GameObject howToPlayPage;
    // Start is called before the first frame update
    void Start()
    {
        backTitleButtonUI.onClick.AddListener(BackTitle);
    }
    /// <summary>
    /// �^�C�g���ɖ߂�
    /// </summary>
    private void BackTitle()
    {
        SoundManager.Instance.PlaySE(SESource.Cancel);
        titleButtonObject.SetActive(true);
        stageSelectPage.SetActive(false);
        howToPlayPage.SetActive(false);
    }
}
