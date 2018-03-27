using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPattern_r : MonoBehaviour {

	// *** Initialization ***
	public string PatternColor;

	// *** Number of Pattern ***
	public int PatternNumber;

	// *** Assign GameObjects ***
	public GameObject TeleporterBlue;
	public GameObject TeleporterRed;
	public GameObject ReceiverBlue;
	public GameObject ReceiverRed;

	// *** Position and Rotation ***
	public Vector3[] TeleporterRot;
	public Vector3[] TeleporterBluePos;
	public Vector3[] TeleporterRedPos;
	public Vector3[] ReceiverBluePos;
	public Vector3[] ReceiverRedPos;

	void Start () {
		
	}

	void Update () {
		if (PatternNumber < 4) {
			MoveAndRotate (PatternNumber);
		}
	}

	void MoveAndRotate (int num){
		// * Teleporter *
		TeleporterBlue.transform.SetPositionAndRotation (TeleporterBluePos[num], Quaternion.Euler(TeleporterRot[num]));
		TeleporterRed.transform.SetPositionAndRotation (TeleporterRedPos[num], Quaternion.Euler(TeleporterRot[num]));

		// * Receiver *
		ReceiverBlue.transform.SetPositionAndRotation (ReceiverBluePos[num], ReceiverBlue.transform.rotation);
		ReceiverRed.transform.SetPositionAndRotation (ReceiverRedPos[num], ReceiverRed.transform.rotation);
	}
}
