using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public static Result Instance {  get; private set; }
    [Header("ゲームリザルトUI")]
    [SerializeField] private GameObject gameResultUI;
    [Header("評価Sテキスト")]
    [SerializeField] private TextMeshProUGUI resultSText;
    [Header("評価Aテキスト")]
    [SerializeField] private TextMeshProUGUI resultAText;
    [Header("評価Bテキスト")]
    [SerializeField] private TextMeshProUGUI resultBText;
    [Header("評価Cテキスト")]
    [SerializeField] private TextMeshProUGUI resultCText;
    [Header("評価Dテキスト")]
    [SerializeField] private TextMeshProUGUI resultDText;
    [Header("ゲームオーバーUI")]
    [SerializeField] private GameObject gameOverUI;
    [Header("ステージのオブジェクト数")]
    [SerializeField] private int objNum;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    /// <summary>
    /// 評価を設定
    /// </summary>
    public void SetAssesment(int _fallObjNum)
    {
        if (GameState.Instance.IsResult()) return;
        GameState.Instance.SetState(GameState.State.Result);

        gameResultUI.SetActive(true);
        int _harfMaxObjNum = objNum / 2; //半分
        int _firstQuartileNum = _harfMaxObjNum / 2;//第一四分位数
        int _thirdQuartileNum = ((objNum + _harfMaxObjNum) / 2);//第三四分位数

        if (0 == _fallObjNum) ResultText(resultDText, "評価D", _fallObjNum);
        else if(0 < _fallObjNum && _fallObjNum <= _firstQuartileNum) ResultText(resultCText, "評価C", _fallObjNum);
        else if(_firstQuartileNum < _fallObjNum && _fallObjNum <= _harfMaxObjNum) ResultText(resultBText, "評価B", _fallObjNum);
        else if(_harfMaxObjNum < _fallObjNum && _fallObjNum <= _thirdQuartileNum) ResultText(resultAText, "評価A", _fallObjNum);
        else if(_thirdQuartileNum < _fallObjNum) ResultText(resultSText, "評価S", _fallObjNum);

        SoundManager.Instance.PlaySE(SESource.GameResult);
    }
    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {
        if (GameState.Instance.IsResult()) return;
        GameState.Instance.SetState(GameState.State.Result);
        gameOverUI.SetActive(true);
        SoundManager.Instance.PlaySE(SESource.GameOver);
    }
    /// <summary>
    /// 評価をテキストに反映
    /// </summary>
    /// <param name="resultText"></param>
    /// <param name="evalution"></param>
    /// <param name="_fallObjNum"></param>
    private void ResultText(TextMeshProUGUI resultText, string evalution, int _fallObjNum)
    {
        resultText.text = "落とした数：" + _fallObjNum + evalution;
        resultText.enabled = true;
    }
}
