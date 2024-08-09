using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform Player_Spawn;

    public AudioClip Checkpoint_Effect;

    private void Awake()
    {
        Player_Spawn = GameObject.FindGameObjectWithTag("Player_Spawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Spawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Audio_Manager.instance.Music_Effect(Checkpoint_Effect, transform.position);

        }
    }
}
