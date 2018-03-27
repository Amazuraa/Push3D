using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	// *** Pattern Number ***
	public int PatternNumber;

	// *** Animator ***
	public Animator animator;
	public Animator CameraAnimator;

	// *** Delay ***
	private bool State = false;
	private int count = 0;

	public int DelayLimit;




	void Start () {
	}

	void Update () {
		Delay ();

		if (PatternNumber == 4)
			State = true;
	}

	void OnTriggerEnter (Collider col){
		if (col.tag == "Box") {
			Destroy (col.gameObject);
			CameraAnimator.SetTrigger ("Camera_Next");
		}
	}

	void Delay (){
		if (State == true){
			count += 1;

			if (count == DelayLimit){
				animator.SetTrigger ("Idle");
				State = false;
			}
		} 
		else if (State == false) 
			count = 0;
	}
}
