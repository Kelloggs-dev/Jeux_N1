using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChargeScene : MonoBehaviour
{
    public string Name_Scene;
    public Animator Transition;
    public float Seconds;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Charge_Scene());
        }
    }

    public IEnumerator Charge_Scene()
    {
        Transition.SetTrigger("TransitionIn");
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(Name_Scene);
    }
}
