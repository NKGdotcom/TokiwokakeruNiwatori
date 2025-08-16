using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ResultCenser"))
        {
            if (isCollision) return;
            isCollision = true;
            NumberOfEnemies.Instance.FallEnemy();
        }
    }
}
