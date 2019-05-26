using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static int tentativas = 5;
    public static int pontuacao;
    public int meta = 100;
    public static bool desaparecerPlayer = false;
    public Image vitoria, derrota;
    public Button forca, altura;
    public Image imagem1, imagem2, imagem3;

    public bool desativarUI;

    public Text score;
    void Start()
    {
        meta = 100;
        tentativas = 5;
        vitoria.gameObject.SetActive(false);
        derrota.gameObject.SetActive(false);
        forca.gameObject.SetActive(true);
        altura.gameObject.SetActive(true);
        imagem1.gameObject.SetActive(true);
        imagem2.gameObject.SetActive(true);
        imagem3.gameObject.SetActive(true);
    }

    void Update()
    {
        score.text = "Score: " + pontuacao;   

        if (tentativas <= 0)
        {
            StartCoroutine(Tempinho());
            StartCoroutine(EsperarResultado());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
            pontuacao = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    IEnumerator EsperarResultado()
    {
        yield return new WaitForSeconds(6);
        pontuacao = 0;
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator Tempinho()
    {
        yield return new WaitForSeconds(3);
        forca.gameObject.SetActive(false);
        altura.gameObject.SetActive(false);

        imagem1.gameObject.SetActive(false);
        imagem2.gameObject.SetActive(false);
        imagem3.gameObject.SetActive(false);
        if (pontuacao >= meta)
        {
            //CARREGAR NOVA FASE!
            vitoria.gameObject.SetActive(true);
        }
        else
        {
            derrota.gameObject.SetActive(true);
            //CARREGAR A MESMA FASE
        }
    }
}
