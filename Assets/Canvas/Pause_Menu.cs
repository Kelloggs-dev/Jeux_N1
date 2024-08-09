using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool Game_En_Pause;

    public GameObject Menu_Pause;

    public GameObject Settings_Pause;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(Game_En_Pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        
        Menu_Pause.SetActive(false);
        Time.timeScale = 1;
        Game_En_Pause = false;

    }

    public void Pause()
    {
        
        Menu_Pause.SetActive(true);
        Time.timeScale = 0;
        Game_En_Pause = true;
    }

    public void Charge_Maine_Menu()
    {
        Ne_Pas_Detruire.instance.Remove_De_Ne_pas_Detruire();
        Resume();
        SceneManager.LoadScene("Main_Menu");
    }

    public void Settings_Menu_Pause_Load()
    {
       
        Settings_Pause.SetActive(true);
    }

    public void Settings_Menu_Pause_Leave()
    {
        Settings_Pause.SetActive(!Settings_Pause.activeSelf);
    }
}
