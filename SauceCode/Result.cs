using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public static Result Instance {  get; private set; }
    [Header("�Q�[�����U���gUI")]
    [SerializeField] private GameObject gameResultUI;
    [Header("�]��S�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI resultSText;
    [Header("�]��A�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI resultAText;
    [Header("�]��B�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI resultBText;
    [Header("�]��C�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI resultCText;
    [Header("�]��D�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI resultDText;
    [Header("�Q�[���I�[�o�[UI")]
    [SerializeField] private GameObject gameOverUI;
    [Header("�X�e�[�W�̃I�u�W�F�N�g��")]
    [SerializeField] private int objNum;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    /// <summary>
    /// �]����ݒ�
    /// </summary>
    public void SetAssesment(int _fallObjNum)
    {
        if (GameState.Instance.IsResult()) return;
        GameState.Instance.SetState(GameState.State.Result);

        gameResultUI.SetActive(true);
        int _harfMaxObjNum = objNum / 2; //����
        int _firstQuartileNum = _harfMaxObjNum / 2;//���l���ʐ�
        int _thirdQuartileNum = ((objNum + _harfMaxObjNum) / 2);//��O�l���ʐ�

        if (0 == _fallObjNum) ResultText(resultDText, "�]��D", _fallObjNum);
        else if(0 < _fallObjNum && _fallObjNum <= _firstQuartileNum) ResultText(resultCText, "�]��C", _fallObjNum);
        else if(_firstQuartileNum < _fallObjNum && _fallObjNum <= _harfMaxObjNum) ResultText(resultBText, "�]��B", _fallObjNum);
        else if(_harfMaxObjNum < _fallObjNum && _fallObjNum <= _thirdQuartileNum) ResultText(resultAText, "�]��A", _fallObjNum);
        else if(_thirdQuartileNum < _fallObjNum) ResultText(resultSText, "�]��S", _fallObjNum);

        SoundManager.Instance.PlaySE(SESource.GameResult);
    }
    /// <summary>
    /// �Q�[���I�[�o�[
    /// </summary>
    public void GameOver()
    {
        if (GameState.Instance.IsResult()) return;
        GameState.Instance.SetState(GameState.State.Result);
        gameOverUI.SetActive(true);
        SoundManager.Instance.PlaySE(SESource.GameOver);
    }
    /// <summary>
    /// �]�����e�L�X�g�ɔ��f
    /// </summary>
    /// <param name="resultText"></param>
    /// <param name="evalution"></param>
    /// <param name="_fallObjNum"></param>
    private void ResultText(TextMeshProUGUI resultText, string evalution, int _fallObjNum)
    {
        resultText.text = "���Ƃ������F" + _fallObjNum + evalution;
        resultText.enabled = true;
    }
}
