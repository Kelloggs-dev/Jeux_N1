using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recup_Vie : MonoBehaviour
{
    public int Vie;

    public AudioClip Vie_Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Player_Vie.instance.Vie_Ingame < Player_Vie.instance.Vie_Max)
            {
                Audio_Manager.instance.Music_Effect(Vie_Effect, transform.position);
                Player_Vie.instance.Recup_Vie(Vie);
                Destroy(gameObject);
            }
            
        }
    }
}
