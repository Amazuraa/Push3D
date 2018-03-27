using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLight : MonoBehaviour {

	public GameObject thisLight;

	void Awake(){
		DontDestroyOnLoad (thisLight.gameObject);
	}
}
