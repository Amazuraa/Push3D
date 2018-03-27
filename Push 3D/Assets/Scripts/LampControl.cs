using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampControl : MonoBehaviour {

	public int AssignNumber;
	public Animator animator;
	public int PatternNumber;

	public string Status = "None";

	void Start (){
	}

	void Update (){
		if (AssignNumber == PatternNumber)
			Status = "Exact";
		else if (0 == PatternNumber)
			Status = "Decrease";

		LampState ();
	}

	void LampState (){
		if (Status == "Exact")
			animator.SetTrigger ("Lamp_True");
		else if (Status == "Decrease")
			animator.SetTrigger ("Lamp_False");
	}
}
