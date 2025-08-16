using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerLimited : MonoBehaviour
{
    [Header("ステージごとのパラメータ")]
    [SerializeField] private StageParameter stageParameter;
    [Header("タイマーに書かれているテキスト")]
    [SerializeField] private TextMeshProUGUI stageTimerText;
    [Header("タイマーを円バーで視覚的にわかりやすく")]
    [SerializeField] private Image timerImage;
    [Header("時間制限到達した後の猶予時間")]
    [SerializeField] private float afterTimeLimitTime;
    private float stageTime; //制限時間
    private float initalStageTime; ///円ゲージを反映させる用
    private float waitTime = 4;   //スタート時間の待ち時間

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
    /// タイマーを始める時間
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTime()
    {
        yield return new WaitForSeconds(waitTime);
        yield break;
    }
    /// <summary>
    /// タイマーを更新
    /// </summary>
    private void UpdateTimerText()
    {
        int _minutes = (int)(stageTime / 60);
        int _seconds = (int)(stageTime % 60);
        stageTimerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }
}
