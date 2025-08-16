using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCenser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StageObject"))
        {
            ScoreManager.Instance.FallObjects();
        }
    }
}
