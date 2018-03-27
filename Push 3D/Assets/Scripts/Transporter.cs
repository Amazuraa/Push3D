using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour {

	// *** Initialization Object ***
	public string AssignObject;

	// *** Assign GameObjects ***
	public GameObject Receiver;
	public GameObject BoxPrefab;

	// *** Boolean ***
	public bool IsBoxEntered = false;

	// *** animation ***
	public Animator teleporterAnimator;
	public Animator otherAnimator; //the other teleporter animator
	private Animator receiverAnimator;

	// *** STATE ***
	private bool spawnState = false;
	private int count = 0;

	// *** Delay ***
	public int spawnBox_Delay;
	public int reveal_Delay;
	public int backtoIdle;
	public int changePos_Delay;

	// *** Pattern Number ***
	public int PatternNumber;


	void Start () {
		receiverAnimator = Receiver.GetComponent<Animator>();
		teleporterAnimator.SetTrigger ("Show_T");
	}

	void Update () {
		if (PatternNumber <= 3) {
			Respawn ();
			ShowTransporter ();
		} 
		else if (PatternNumber == 4){
			Reveal ();
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Box") {
			if (PatternNumber <= 3) {
				receiverAnimator.SetTrigger ("Show_R");
				Destroy (col.gameObject);
				spawnState = true;
			} 
			else
				return;
		}
	}

	void Respawn (){
		if (spawnState == true){
			count += 1;
			if (count == spawnBox_Delay) {
				Instantiate (BoxPrefab, Receiver.transform.position, Receiver.transform.rotation);
			} 
			else if (count == reveal_Delay) {
				teleporterAnimator.SetTrigger ("Reveal_T");
				receiverAnimator.SetTrigger ("Reveal_R");
				otherAnimator.SetTrigger ("Reveal_T");
			}
			else if (count == backtoIdle){
				teleporterAnimator.SetTrigger ("Idle_T");
				receiverAnimator.SetTrigger ("Idle_R");
				otherAnimator.SetTrigger ("Idle_T");
			}
			else if (count == changePos_Delay){
				IsBoxEntered = true;
				spawnState = false;
			}
		} 
		else if (spawnState == false){
			count = 0;
		}
	}

	void ShowTransporter(){
		if (IsBoxEntered == true){
			teleporterAnimator.SetTrigger ("Show_T");
			otherAnimator.SetTrigger ("Show_T");
		}
		else if (IsBoxEntered == false){
			return;
		}
	}

	void Reveal (){
		teleporterAnimator.SetTrigger ("Reveal_T");
		otherAnimator.SetTrigger ("Reveal_T");
	}

}
