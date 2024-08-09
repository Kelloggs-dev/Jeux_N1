using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Vie : MonoBehaviour
{
    public Slider Bar_Vies;

    public Gradient gradient;
    public Image Remplir;
    public void Max_Vie(int P_Vie)
    {
        Bar_Vies.maxValue = P_Vie;
        Bar_Vies.value = P_Vie;

        Remplir.color = gradient.Evaluate(1f);
    }

    public void Vie(int P_Vie)
    {
        Bar_Vies.value = P_Vie;

        Remplir.color = gradient.Evaluate(Bar_Vies.normalizedValue);
    }
}
