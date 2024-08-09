using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Game_Over_Manager : MonoBehaviour
{
    public GameObject Game_Over_UI;

    public AudioClip Mort_Effect;

    public static Game_Over_Manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Game_Over_Manager dans la scene ");
            return;
        }

        instance = this;
    }

    public void On_Player_Death()
    {
        if (Scene_Manager.instance.Si_Player_Est_Par_Defaut)
        {
            Ne_Pas_Detruire.instance.Remove_De_Ne_pas_Detruire();
        }
        
        Audio_Manager.instance.Music_Effect(Mort_Effect,transform.position);
        Game_Over_UI.SetActive(true);
    }

    public void Restart_Bouton()
    {
        // recommencer le jeu 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player_Vie.instance.Respawn();
        Game_Over_UI.SetActive(false);
    }

    public void Main_Menu_Bouton()
    {
        //retour menu principal
        Ne_Pas_Detruire.instance.Remove_De_Ne_pas_Detruire();
        SceneManager.LoadScene("Maine_Menu");
    }

    public void Leave_Bouton()
    {
        // fermer le jeu 
        Application.Quit();
    }


}
