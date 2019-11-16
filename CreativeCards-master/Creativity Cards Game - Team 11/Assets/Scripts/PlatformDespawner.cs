using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawner : MonoBehaviour
{
    //Make sure that this number is equal to the platform layermask number
    private LayerMask platformMask = 8;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == platformMask.value)
        {
            PlatformSpawner.Instance.spawnedPlatforms.Remove(col.gameObject);
            Destroy(col.gameObject, 1.5f);
        }
    }
}
