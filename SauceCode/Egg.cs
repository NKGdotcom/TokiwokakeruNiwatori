using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float eggPower;
    private Rigidbody colRb;
    private bool isSound;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StageObject") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Click"))
        {
            colRb = collision.gameObject.GetComponent<Rigidbody>();
            colRb.AddForce(transform.forward * eggPower, ForceMode.VelocityChange);
            if (isSound) return;
            isSound = true;
            SoundManager.Instance.PlaySE(SESource.ColliderObj);
        }
    }
}
