using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform Gun;

    [SerializeField]
    private GameObject Bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(Bullet, Gun.position, Gun.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Gun.up * 10f;
    }
}
