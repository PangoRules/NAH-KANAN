using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	public void cambiarEscena(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
