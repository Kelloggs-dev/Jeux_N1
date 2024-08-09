using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    public bool Si_Player_Est_Par_Defaut = false;

    public static Scene_Manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Scene_Manager dans la scene ");
            return;
        }

        instance = this;
    }
}
