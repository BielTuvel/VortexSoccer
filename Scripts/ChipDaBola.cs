using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipDaBola : MonoBehaviour
{
    public Image imageChances;
   // public Transform portalReceiver;
  //  public Transform bola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chuteValido")
        {
            LevelController.tentativas--;
            imageChances.fillAmount -= 0.2f;
        }
        if (other.tag == "Gol")
        {
            LevelController.pontuacao += 20;
        }
    }

}
