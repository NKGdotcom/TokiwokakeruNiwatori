using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberOfEnemies : MonoBehaviour
{
    public static NumberOfEnemies Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI enemyNumText;
    private List<GameObject> enemyLists;
    private int nowEnemyNum;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyLists = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        nowEnemyNum = enemyLists.Count;
        EnemyTextUpdate();
    }
    /// <summary>
    /// �G�̐��̃e�L�X�g�𔽉f
    /// </summary>
    private void EnemyTextUpdate()
    {
        enemyNumText.text = "�c��̓G�̐��F" + nowEnemyNum.ToString();
    }
    /// <summary>
    /// �G�𗎂Ƃ����Ƃ�
    /// </summary>
    public void FallEnemy()
    {
        nowEnemyNum--;
        EnemyTextUpdate();
        if (nowEnemyNum <= 0) Result.Instance.SetAssesment(ScoreManager.Instance.FallObjNum);
    }
}
