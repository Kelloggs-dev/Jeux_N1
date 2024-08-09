using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Zone_Mort : MonoBehaviour
{
    private Transform Player_Spawn;
    private Animator Transition;

    public float Seconds;

    private void Awake()
    {
        Player_Spawn = GameObject.FindGameObjectWithTag("Player_Spawn").transform;
        Transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(Replace_Player(collision));

        }
    }

    private IEnumerator Replace_Player(Collider2D collision)
    {
        Transition.SetTrigger("TransitionIn");
        yield return new WaitForSeconds(Seconds);
        collision.transform.position = Player_Spawn.position;
    }
}
