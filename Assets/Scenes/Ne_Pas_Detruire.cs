using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Ne_Pas_Detruire : MonoBehaviour
{
    public GameObject[] Objects;

    public static Ne_Pas_Detruire instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Ne_Pas_Detruire dans la scene ");
            return;
        }

        instance = this;

        int Taille = Objects.Length;

        for (int Index = 0; Index < Taille; Index++)
        {
            DontDestroyOnLoad(Objects[Index]);
        }
    }

    public void Remove_De_Ne_pas_Detruire()
    {
        int Taille = Objects.Length;

        for (int Index = 0; Index < Taille; Index++)
        {
            SceneManager.MoveGameObjectToScene(Objects[Index], SceneManager.GetActiveScene());
        }
    }
}
