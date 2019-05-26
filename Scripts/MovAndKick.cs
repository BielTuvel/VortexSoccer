using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAndKick : MonoBehaviour
{
    float velocidade = 3.5f;
    public Vector3 posicaoInicial;
    Vector3 movimento;
    public static Quaternion rotacaoSeta;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Zera força de movimento
        movimento = new Vector3(0, 0, 0);

        //ROTAÇÃO COM MOUSE
        transform.Rotate(0, Input.GetAxis("Mouse X") * 180 * Time.deltaTime, 0);
        rotacaoSeta = transform.rotation;

        if (transform.rotation.y <= -45.0f)
        {
            transform.eulerAngles = new Vector3(0, -45, 0);
        }

        //APLICAR MOVIMENTO VIA TRANSLATE
        transform.Translate(movimento);

    }

}
