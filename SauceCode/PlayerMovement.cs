using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("プレイヤーデータ")]
    [SerializeField] private PlayerData playerData;
    private Vector3 rayPosition = new Vector3(0f, 2.9f, 0f);

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void PlayerMove()
    {
        float _moveX = Input.GetAxisRaw("Horizontal");
        float _moveZ = Input.GetAxisRaw("Vertical");
        Vector3 _moveDirection = new Vector3(_moveX, 0, _moveZ).normalized;

        if(_moveDirection != Vector3.zero)
        {
            transform.forward = _moveDirection;

            Ray _ray = new Ray(transform.position + rayPosition, transform.forward);
            RaycastHit _hit;

            if (!Physics.Raycast(_ray, out _hit, playerData.RayDistance))
            {
                transform.position += transform.forward * playerData.PlayerMoveSpeed * Time.unscaledDeltaTime;
            }
            else Debug.Log("衝突");
        }
    }
}
