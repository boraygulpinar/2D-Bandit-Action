using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public float damping;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, damping) + offSet;
    }
}
