using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public string Load_Scene;

    public GameObject Settings_Menu;

    
    public void Start_Game_Bouton()
    {
        SceneManager.LoadScene(Load_Scene);
    }
    public void Settings_Bouton()
    {
        Settings_Menu.SetActive(true);
    }

    public void Credit_Bouton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Leave_Settings_Bouton()
    {
        Settings_Menu.SetActive(!Settings_Menu.activeSelf);
    }
    public void Leave_Game_Bouton()
    {
        Application.Quit();
    }
}
