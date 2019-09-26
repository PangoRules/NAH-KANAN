using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyBehaviour : MonoBehaviour {
    Rigidbody2D enemyRb;
    float timeBeforechange;
    public float delay=.5f;
    public float speed = 1f;
    public Text vidas;
    public SceneChanger cescen;
    public bool left;
	public bool right;
    public bool hit;
    private Animator anim;
    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Right",right);
		anim.SetBool("Left",left);
        anim.SetBool("Hit",hit);

        enemyRb.velocity = Vector2.right * speed;
        if(speed>0){
            right=true;
            left=false;
        }else{
            right=false;
            left=true;
        }

        if (timeBeforechange<Time.time) {

            speed = speed * -1;

            timeBeforechange = Time.time + delay;

        }
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag=="Player") {
            

            if (transform.position.y+10< collision.transform.position.y)
            {
                hit=true;
                
                DisableEnemy();   
             }
            else {

                MuerteCaida.vida--;

                cescen.cambiarEscena("PalenqueLvl1");
                vidas.text = MuerteCaida.vida.ToString();
                contador.contadoram = 0;


            }
        }






    }
    public void DisableEnemy()
    {
        gameObject.SetActive(false);

    }
}


