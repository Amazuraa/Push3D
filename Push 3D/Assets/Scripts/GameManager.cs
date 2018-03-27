using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	void MainScene(){
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
		//Application.LoadLevel ("Main");
	}

	void MainMenu(){
		SceneManager.LoadScene ("End", LoadSceneMode.Single);
	}

	void Exit(){
		Application.Quit ();
	}
		
}
