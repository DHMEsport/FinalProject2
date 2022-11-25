using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFllow : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;
    [Range(0.01f, 1.0f)] [SerializeField] float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
        
    private void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        if (LookAtPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
