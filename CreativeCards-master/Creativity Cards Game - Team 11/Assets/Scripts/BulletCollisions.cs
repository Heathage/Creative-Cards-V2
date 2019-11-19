using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    [SerializeField]
    private int bouncesLeft = 4;
    private int currentBounces;

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        bouncesLeft--;
        currentBounces++;

        if (col.gameObject.CompareTag("Enemy"))
        {

            //score += (10 * bouncesLeft);
            GameController.Instance.score += currentBounces * 10;

            //Destroys enemy
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

        if (bouncesLeft <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
