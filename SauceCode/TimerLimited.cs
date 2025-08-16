using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerLimited : MonoBehaviour
{
    [Header("�X�e�[�W���Ƃ̃p�����[�^")]
    [SerializeField] private StageParameter stageParameter;
    [Header("�^�C�}�[�ɏ�����Ă���e�L�X�g")]
    [SerializeField] private TextMeshProUGUI stageTimerText;
    [Header("�^�C�}�[���~�o�[�Ŏ��o�I�ɂ킩��₷��")]
    [SerializeField] private Image timerImage;
    [Header("���Ԑ������B������̗P�\����")]
    [SerializeField] private float afterTimeLimitTime;
    private float stageTime; //��������
    private float initalStageTime; ///�~�Q�[�W�𔽉f������p
    private float waitTime = 4;   //�X�^�[�g���Ԃ̑҂�����

    // Start is called before the first frame update
    void Start()
    {
        stageTime = stageParameter.StageParameterDataList[StageNumGet.Instance.StageNum - 1].StageTimer;
        initalStageTime = stageTime;
        UpdateTimerText();

        StartCoroutine(StartTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsGameWaitTime())
        {
            waitTime -= Time.unscaledDeltaTime;
            if (waitTime < 0) GameState.Instance.SetState(GameState.State.Normal);
        }
        else if (GameState.Instance.IsNormal() || GameState.Instance.IsTimeStop())
        {
            timerImage.fillAmount = stageTime / initalStageTime;
            stageTime -= Time.unscaledDeltaTime;
            UpdateTimerText();
            if (stageTime <= 0)
            {
                GameState.Instance.SetState(GameState.State.TimeLimit);
            }
        }
        else if (GameState.Instance.IsTimeLimited())
        {
            afterTimeLimitTime -= Time.unscaledDeltaTime;
            if (afterTimeLimitTime <= 0) Result.Instance.GameOver();
        }
    }
    /// <summary>
    /// �^�C�}�[���n�߂鎞��
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTime()
    {
        yield return new WaitForSeconds(waitTime);
        yield break;
    }
    /// <summary>
    /// �^�C�}�[���X�V
    /// </summary>
    private void UpdateTimerText()
    {
        int _minutes = (int)(stageTime / 60);
        int _seconds = (int)(stageTime % 60);
        stageTimerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }
}
