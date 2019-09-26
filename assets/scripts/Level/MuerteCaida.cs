using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuerteCaida : MonoBehaviour {
    public static  int vida=5;
    public Text vidas;
    public  SceneChanger cescen;

    private void Start()
    {
        vidas.text = vida.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="Player") {

            vida--;
           
            cescen.cambiarEscena("PalenqueLvl1");
            vidas.text = vida.ToString();
            contador.contadoram = 0;


       

        }



    }


}
