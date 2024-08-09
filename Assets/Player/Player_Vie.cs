using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Vie : MonoBehaviour
{

    public int Vie_Max = 100;
    public int Vie_Ingame;

    public float Invinssible_Flash_Delait = 0.2f;
    public float Invinssible_Flash_Time = 3f;

    public bool Invinssible = false;
    public SpriteRenderer graphic;

    public Bar_Vie bar_Vie;

    public static Player_Vie instance;

    public AudioClip Damage_Effect;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Player_Vie dans la scene ");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vie_Ingame = Vie_Max;
        bar_Vie.Max_Vie(Vie_Max);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Degat(80);
        }
    }

    public void Recup_Vie(int P_Vie)
    {
        if((Vie_Ingame + P_Vie) > Vie_Max)
        {
            Vie_Ingame = Vie_Max;
        }
        else
        {
            Vie_Ingame += P_Vie;
        }
        
        bar_Vie.Vie(Vie_Ingame);
    }

    public void Degat(int P_Degat)
    {
        if (Invinssible == false) {

            Audio_Manager.instance.Music_Effect(Damage_Effect, transform.position);
            Vie_Ingame -= P_Degat;
            bar_Vie.Vie(Vie_Ingame);

            if(Vie_Ingame <= 0)
            {
                Death();
                return;
            }

            
            Invinssible = true;
            StartCoroutine(Invinssible_Flash());
            StartCoroutine(Invinssible_Delait());
            
            
        }
        
    }

    public void Death()
    {
        Debug.Log("Le joueur est mort");
        //bloque le joueur
        Player_Movement.instance.enabled = false;
        //Joue l'annimation 
        Player_Movement.instance.Animator.SetTrigger("Death");
        // Empecher les interaction 
        Player_Movement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Player_Movement.instance.rb.velocity = Vector3.zero;
        Player_Movement.instance.Colision_Player.enabled = false;
        //ouvre le menu game over
        Game_Over_Manager.instance.On_Player_Death();

    }

    public void Respawn()
    {
        Debug.Log("Le joueur a respawn");
        Player_Movement.instance.enabled = true;
        Player_Movement.instance.Animator.SetTrigger("Respawn");
        Player_Movement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        Player_Movement.instance.Colision_Player.enabled = true;
        Vie_Ingame = Vie_Max;
        bar_Vie.Max_Vie(Vie_Max);

    }

    public IEnumerator Invinssible_Flash()
    {
        while(Invinssible == true) {
            graphic.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(Invinssible_Flash_Delait);
            graphic.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(Invinssible_Flash_Delait);
        }
    }
    public IEnumerator Invinssible_Delait()
    {
        yield return new WaitForSeconds(Invinssible_Flash_Time);
        Invinssible = false;
    }
}
