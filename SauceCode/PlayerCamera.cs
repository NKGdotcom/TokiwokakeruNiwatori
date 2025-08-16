using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = playerCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.transform.position = transform.position + cameraOffset;
    }
}
