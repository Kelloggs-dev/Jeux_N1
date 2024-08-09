using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Snake_Weak_Spot : MonoBehaviour
{
    public GameObject Destroy_GameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Destroy(Destroy_GameObject);
        }
    }
}
