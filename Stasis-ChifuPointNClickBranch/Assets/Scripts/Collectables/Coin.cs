using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        Player.coins++;
        Destroy(gameObject);
    }
}
