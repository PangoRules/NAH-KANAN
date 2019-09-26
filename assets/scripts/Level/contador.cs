using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contador : MonoBehaviour {
    public static int contadoram=0;
    public Text ambarc;
    ParticleSystem ambar;

	// Use this for initialization
	void Start () {
        ambar = GameObject.Find("ParticulasAmbar").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            gameObject.SetActive(false);
            contadoram++;
            ambar.transform.position = transform.position;
            ambar.Play();
            ambarc.text = contadoram.ToString()+"/5";
          
        }
    }
}
