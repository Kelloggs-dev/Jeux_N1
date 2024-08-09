using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class Settings_Menu : MonoBehaviour
{
    public AudioMixer Audio_Mixer;

    Resolution[] Resolution;

    public Dropdown Resolution_Dropdown;

    public Slider Music_Slider;
    public Slider Effect_Slider;

    public void Start()
    {
        Audio_Mixer.GetFloat("Music", out float Valeur_Slider_Music);
        Music_Slider.value = Valeur_Slider_Music;

        Audio_Mixer.GetFloat("Effet", out float Valeur_Slider_Effect);
        Effect_Slider.value = Valeur_Slider_Effect;



        Resolution = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();
        Resolution_Dropdown.ClearOptions();

        List<string> Option = new List<string>();

        int Taille = Resolution.Length;
        int Resolution_Actuel_Index = 0;

        for (int Index = 0; Index < Taille; Index++)
        {
            string P_Option = Resolution[Index].width + " x " + Resolution[Index].height;
            Option.Add(P_Option);

            if (Resolution[Index].width == Screen.width && Resolution[Index].height == Screen.height)
            {
                Resolution_Actuel_Index = Index;
            }
        }

        Resolution_Dropdown.AddOptions(Option);
        Resolution_Dropdown.value = Resolution_Actuel_Index;
        Resolution_Dropdown.RefreshShownValue();
    }
    public void Set_Volume (float P_Volume)
    {
        Audio_Mixer.SetFloat("Volume", P_Volume);
    }
    public void Set_Music(float P_Music)
    {
        Audio_Mixer.SetFloat("Music", P_Music);
    }
    public void Set_Effet(float P_Effet)
    {
        Audio_Mixer.SetFloat("Effet", P_Effet);
    }

    public void Set_FullScreen(bool P_FullScreen)
    {
        Screen.fullScreen = P_FullScreen;
    }

    public void Set_Resolution(int P_Resolution_Index)
    {
        Resolution resolution = Resolution[P_Resolution_Index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
