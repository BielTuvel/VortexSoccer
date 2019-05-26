using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bola.podeChutar && Input.GetMouseButtonDown(0))
        {
            anime.SetBool("kick", true);
        }

        if (LevelController.desaparecerPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
