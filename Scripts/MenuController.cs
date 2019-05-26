using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public void AlterarCena(string cena)
    {
        Application.LoadLevel(cena);
    }

    public void FecharAplicativo()
    {
        Application.Quit();
    }

}
