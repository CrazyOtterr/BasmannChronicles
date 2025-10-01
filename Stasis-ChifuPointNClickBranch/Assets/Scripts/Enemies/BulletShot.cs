using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("isRight"))
        {
            Player.receivedDamage = damage;
            Player.isHitRight = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("isLeft"))
        {
            Player.receivedDamage = damage;
            Player.isHitLeft = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("isFront"))
        {
            Player.receivedDamage = damage;
            Player.isHitFront = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("isBack"))
        {
            Player.receivedDamage = damage;
            Player.isHitBack = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground") || other.CompareTag("Wall") || other.CompareTag("Ladder"))
        {
            Destroy(gameObject);
        }
    }
}
