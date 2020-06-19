using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float speedValue = 5f;
    private void FixedUpdate()
    {
        if (GameManager.singleton.GameStarted)
        {
            transform.position = transform.position + Vector3.forward * speedValue * Time.fixedDeltaTime;
        }
           
    }
}
