using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEggShot : MonoBehaviour
{
    [Header("�X�e�[�W���Ƃ̃p�����[�^")]
    [SerializeField] private StageParameter stageParameter;
    [Header("�v���C���[�̃p�����[�^")]
    [SerializeField] private PlayerData playerData;
    [Header("���̎c�萔�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI nowEggNumText;
    [Header("���̔��˃|�C���g")]
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
    /// ���V���b�g
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
    /// ���̃e�L�X�g�ύX
    /// </summary>
    private void EggTextUpdate()
    {
        nowEggNumText.text = "�c��̗��̐��F" + eggNum.ToString();
    }
}
