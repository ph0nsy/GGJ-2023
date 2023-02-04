using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2dfollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtTarget )
        {
            transform.LookAt(targetObject);
        }
    }
}