using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bola : MonoBehaviour
{
    float velocidade = 1.5f;
    public bool EsperouAnimacao = false;
    Rigidbody rotacao;
    public Image borda;
    public Image altura;
    public static bool podeChutar = false;

    public Animator animacaoPlayer;

    public Transform portalReceiver;
    
    void Start()
    {
        rotacao = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (LevelController.tentativas >= 1)
        {
           // if (podeChutar == true)
           // {
                if (EsperouAnimacao)
                {
                    EsperouAnimacao = false;
                    rotacao.MoveRotation(MovAndKick.rotacaoSeta);                  
                    GetComponent<Rigidbody>().AddRelativeForce(0, altura.fillAmount * 350, borda.fillAmount * -600);
                    StartCoroutine(VoltarAoSpawn());
                    AtualizarBorda.repeat = true;
                    BarraDeAltura.repeat = true;
                    BarraDeAltura.liberar = false;
                }
           // }
        }
    }

     IEnumerator VoltarAoSpawn()
    {
        animacaoPlayer.SetBool("kick", false);
        podeChutar = false;
        yield return new WaitForSeconds(3);
        transform.position = Marca.posicaoMarca;
        GetComponent<Rigidbody>().Sleep();
    }

     void OnTriggerEnter(Collider outro)
    {
        if (outro.tag == "Dedao")
        {
            EsperouAnimacao = true;
        }
    }

    private void OnCollisionEnter(Collision outro)
    {
        if (outro.collider.tag == "Portal")
        {
            transform.position = new Vector3(portalReceiver.position.x, portalReceiver.position.y, portalReceiver.position.z);
            LevelController.pontuacao += 50;
        }
    }

}
