using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * script activity : - accessing another script 
 * - checking which gate that box entered
 * - change value of teleport pattern script
 */

public class TeleportManager : MonoBehaviour {

	// *** Assign GameObjects ***
	public GameObject GateBlue;
	public GameObject GateRed;
	public GameObject LightOne;
	public GameObject LightTwo;
	public GameObject LightThree;
	public GameObject LightFour;
	public GameObject GateFinish;

	// *** Number of Pattern ***
	public int PatternNumber;

	// *** Accessing another scripts ***
	private Transporter transporterScriptB;
	private Transporter transporterScriptR;
	private TeleportPattern teleportPatternScript;
	private TeleportPattern_r teleportPattern_rScript;
	private TeleportPattern_back teleportPattern_backScript;

	// *** State ***
	private string RouteState = "None";

	// *** to Retrieve boolean status *** 
	private bool blue_Entered;
	private bool red_Entered;

	// *** STATE ***
	private bool NoneRoute_state = false;
	private int count = 0;

	// *** Animator ***
	public Animator Hint;


	void Awake () {
		transporterScriptB = GateBlue.GetComponent<Transporter>();
		transporterScriptR = GateRed.GetComponent<Transporter>();
		teleportPatternScript = GetComponent<TeleportPattern>();
		teleportPattern_rScript = GetComponent<TeleportPattern_r>();

		teleportPattern_backScript = GetComponent<TeleportPattern_back>();
		teleportPattern_backScript.enabled = false;
	}

	void Start () {
		//Debug.Log (teleportPatternScript.PatternNumber);
	}

	void Update () {

		if (PatternNumber == 1)
			Hint.SetTrigger ("Reverse");

		// Assign pattern number to Finish Script
		GateFinish.GetComponent<Finish>().PatternNumber = PatternNumber;

		// Assign pattern number to Light Script
		LightOne.GetComponent<LampControl>().PatternNumber = PatternNumber;
		LightTwo.GetComponent<LampControl>().PatternNumber = PatternNumber;
		LightThree.GetComponent<LampControl>().PatternNumber = PatternNumber;
		LightFour.GetComponent<LampControl>().PatternNumber = PatternNumber;

		// Assign pattern number to transporter Script
		transporterScriptB.PatternNumber = PatternNumber;
		transporterScriptR.PatternNumber = PatternNumber;

		// Assign transporter gate 
		blue_Entered = transporterScriptB.IsBoxEntered;
		red_Entered = transporterScriptR.IsBoxEntered;

		// ** Statement **
		if (RouteState == "None")
			NoneRoute ();
		else if (RouteState == "Blue")
			BlueRoute ();
		else if (RouteState == "Red")
			RedRoute ();
		else if (RouteState == "Restart")
			RestartRoute ();

		// ** Delay **
		NoneRoute_delay();
	}

	/*
	 * ================================= ROUTE =================================
	 */

	// -----------------------------------------------------------------------------
	void NoneRoute (){

		teleportPattern_backScript.enabled = false;

		if (blue_Entered == true) {
			PatternNumber = 1;
			teleportPatternScript.enabled = true;
			teleportPatternScript.PatternNumber = PatternNumber;
			transporterScriptB.IsBoxEntered = false;
			RouteState = "Blue";
		}
		else if (red_Entered == true) {
			PatternNumber = 1;
			teleportPattern_rScript.enabled = true;
			teleportPattern_rScript.PatternNumber = PatternNumber;
			transporterScriptR.IsBoxEntered = false;
			RouteState = "Red";
		}
	}

	void NoneRoute_delay (){
		if (NoneRoute_state == true){
			count += 1;
			if (count == 5){
				PatternNumber = 1;
				NoneRoute_state = false;
			}
		}
		else if (NoneRoute_state == false){
			count = 0;
		}
	}
	// -----------------------------------------------------------------------------

	void BlueRoute (){
		teleportPattern_rScript.enabled = false;
		switch (PatternNumber) 
		{
			case 0:
			teleportPatternScript.PatternNumber = PatternNumber;
			break;
		
			case 1:
			BlueorRed ("Blue");
			RestartColor ("Red");
			teleportPatternScript.PatternNumber = PatternNumber;
			break;

			case 2:
			BlueorRed ("Red");
			RestartColor ("Blue");
			teleportPatternScript.PatternNumber = PatternNumber;
			break;

			case 3:
			BlueorRed ("Red");
			teleportPatternScript.PatternNumber = PatternNumber;
			break;

			case 4:
			break;
		}
	}
		
	void RedRoute (){
		teleportPatternScript.enabled = false;
		switch (PatternNumber) 
		{
			case 0:
			teleportPattern_rScript.PatternNumber = PatternNumber;
			break;

			case 1:
			BlueorRed ("Blue");
			RestartColor ("Red");
			teleportPattern_rScript.PatternNumber = PatternNumber;
			break;
		
			case 2:
			BlueorRed ("Blue");
			RestartColor ("Red");
			teleportPattern_rScript.PatternNumber = PatternNumber;
			break;

			case 3:
			BlueorRed ("Red");
			teleportPattern_rScript.PatternNumber = PatternNumber;
			break;

			case 4:
			break;
		}
	}

	void RestartRoute (){
		teleportPattern_backScript.enabled = true;

		teleportPatternScript.enabled = false;
		teleportPattern_rScript.enabled = false;

		switch (PatternNumber) 
		{
			case 1:
			Restart ("Blue");
			teleportPattern_backScript.PatternNumber = PatternNumber;
			break;

			case 2:
			Restart ("Red");
			teleportPattern_backScript.PatternNumber = PatternNumber;
			break;
		}
	}

	/*
	 * ================================= DECISION =================================
	 */

	void BlueorRed (string color){
		// ** Blue **
		if (color == "Blue"){
			if (blue_Entered == true) {
				PatternNumber += 1;
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			} 
		} 
		// ** Red **
		else if (color == "Red"){
			if (red_Entered == true){
				PatternNumber += 1;
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			} 	
		}
	}

	void RestartColor (string color){
		// ** Blue **
		if (color == "Blue"){
			if (blue_Entered == true) {
				RouteState = "Restart";
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			} 
		} 
		// ** Red **
		else if (color == "Red"){
			if (red_Entered == true){
				RouteState = "Restart";
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			} 	
		}
	}

	void Restart (string color){
		// ** BLue **
		if (color == "Blue") {
			if (blue_Entered == true) {
				PatternNumber = 0;
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
				RouteState = "None";
			} else {
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			}
		}
		// ** Red **
		else if (color == "Red") {
			if (red_Entered == true) {
				PatternNumber = 0;
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
				RouteState = "None";
			} else {
				transporterScriptB.IsBoxEntered = false;
				transporterScriptR.IsBoxEntered = false;
			}
		}
	}

}
