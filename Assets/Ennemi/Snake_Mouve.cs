using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake_Mouve : MonoBehaviour
{
    public float Speed;
    public Transform[] Waypoint;

    public int Domage_Colision = 20;

    public SpriteRenderer Graphique;
    private Transform target;
    private int despoint;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position) < 0.3f) {
            despoint = (despoint + 1) % Waypoint.Length;
            target = Waypoint[despoint];
            Graphique.flipX = !Graphique.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            Player_Vie player_Vie = collision.transform.GetComponent<Player_Vie>();
            player_Vie.Degat(Domage_Colision);
        }
    }
}
