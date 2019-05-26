using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeAltura : MonoBehaviour
{
    public static bool liberar = false;
    public Image minhaImagem;
    public float speed = 2.0f;
    public float TempoDeEspera = 5.0f;
    public static bool repeat = true;
    public float guardarValor;

    public IEnumerator Start()
    {
        if (liberar)
        {
            while (repeat)
            {
                yield return ChangeFill(0.0f, 1.0f, TempoDeEspera);
                yield return ChangeFill(1.0f, 0.0f, TempoDeEspera);
            }
            if (!repeat)
            {
                yield return ChangeFill(guardarValor, guardarValor, TempoDeEspera);
            }
        }
    }
    
    void Update()
    {
        if (!bola.podeChutar)
        {
            StartCoroutine(Start());
        }
    }

    public IEnumerator ChangeFill(float start, float end, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            minhaImagem.fillAmount = Mathf.Lerp(start, end, i);
            yield return null;
        }
    }

    public void PararBorda()
    {
        guardarValor = minhaImagem.fillAmount;
        repeat = false;
        bola.podeChutar = true;
    }

}
