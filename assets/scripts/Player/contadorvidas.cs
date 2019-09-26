using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadorvidas : MonoBehaviour
{
    public  int contadorcaf = MuerteCaida.vida;
    public Text cafec;
    static bool taked;
    ParticleSystem cafe;

    // Use this for initialization
    void Start()
    {
        cafe = GameObject.Find("ParticulasCafe").GetComponent<ParticleSystem>();

         if (taked == true)
        {

            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && taked == false)
        {
            taked = true;
            gameObject.SetActive(false);
            MuerteCaida.vida++;
            cafe.transform.position = transform.position;
            cafe.Play();
            cafec.text = MuerteCaida.vida.ToString();

        }
       
    }
}
