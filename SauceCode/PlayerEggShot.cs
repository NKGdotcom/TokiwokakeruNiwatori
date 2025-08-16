using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEggShot : MonoBehaviour
{
    [Header("ステージごとのパラメータ")]
    [SerializeField] private StageParameter stageParameter;
    [Header("プレイヤーのパラメータ")]
    [SerializeField] private PlayerData playerData;
    [Header("卵の残り数テキスト")]
    [SerializeField] private TextMeshProUGUI nowEggNumText;
    [Header("卵の発射ポイント")]
    [SerializeField] private GameObject firingPoint;
    
    private int eggNum;
    private GameObject eggBullet;
    private Vector3 eggPos;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        eggNum = stageParameter.StageParameterDataList[StageNumGet.Instance.StageNum-1].EggNum;
        EggTextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsTimeStop())
        {
            if (Input.GetMouseButtonDown(0))
            {
                EggShot();
            }
        }
    }
    /// <summary>
    /// 卵ショット
    /// </summary>
    private void EggShot()
    {
        if (eggNum <= 0) return;
        eggNum--;
        EggTextUpdate();
        eggPos = firingPoint.transform.position;
        eggBullet = Instantiate(playerData.EggPrefabs, eggPos, this.gameObject.transform.rotation);
        direction = eggBullet.transform.forward;
        eggBullet.GetComponent<Rigidbody>().AddForce(direction * playerData.EggSpeed);
        SoundManager.Instance.PlaySE(SESource.EggInstallation);
    }
    /// <summary>
    /// 卵のテキスト変更
    /// </summary>
    private void EggTextUpdate()
    {
        nowEggNumText.text = "残りの卵の数：" + eggNum.ToString();
    }
}
