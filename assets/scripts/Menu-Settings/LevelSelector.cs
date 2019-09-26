using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
	private GameObject[] levelList;

	private int index = 0;

	private void Start()
	{
		//Arreglo de objetos aka los niveles
		levelList = new GameObject[transform.childCount];

		

		//Iteramos el arreglo para obtener los niveles existentes
		for (int i = 0; i < transform.childCount; i++)
		{
			levelList[i] = transform.GetChild(i).gameObject;
		}

		//Los desactivamos para que no hagan overlapping
		foreach (GameObject go in levelList)
		{
			go.SetActive(false);
		}

		if (levelList[0])
		{
			levelList[0].SetActive(true);
		}
	}

	public void back()
	{
		//Desactivar el nivel actual
		levelList[index].SetActive(false);

		index--;
		if(index < 0)
		{
			index = levelList.Length - 1;
		}

		//Activar el nuevo nivel
		levelList[index].SetActive(true);
	}

	public void next()
	{
		//Desactivar el nivel actual
		levelList[index].SetActive(false);

		index++;
		if(index == levelList.Length)
		{
			index = 0;
		}

		//Activar el nuevo nivel
		levelList[index].SetActive(true);
	}
}
