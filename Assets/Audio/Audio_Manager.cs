using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour

{
    public AudioClip[] Playlist;
    public AudioSource Audio_Source;

    public AudioMixerGroup Effect;


    private int Music_Index;

    public static Audio_Manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Audio_Manager dans la scene ");
            return;
        }

        instance = this;
    }  

    void Update()
    {
        if (!Audio_Source.isPlaying)
        {
            Charge_Music_InGame();
        }
    }

    void Charge_Music_InGame()
    {

        Music_Index = (Music_Index + 1) % Playlist.Length;
        Audio_Source.clip = Playlist[Music_Index];
        Audio_Source.Play();
    }

    public AudioSource Music_Effect(AudioClip P_Effect , Vector3 pos)
    {
        GameObject temporary_GameObject = new GameObject("temporary");
        temporary_GameObject.transform.position = pos;
        AudioSource audio_source = temporary_GameObject.AddComponent<AudioSource>();
        audio_source.clip = P_Effect;
        audio_source.outputAudioMixerGroup = Effect;
        audio_source.Play();
        Destroy(temporary_GameObject, P_Effect.length);
        return audio_source;
    }
}
