using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    float min = 0;
    float max = 0;
    public Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - target.position;
    }

    void Update()
    {
        if (target != null)
        {
            this.transform.position = offset + target.position;

            transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min, max),
            transform.position.y, transform.position.z);
        }
    }
}
