using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float MoveSpeed = 10f;
	public float InputVertical;
	public float InputHorizontal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputVertical = Input.GetAxis ("Vertical");
		InputHorizontal = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate () {
		Vector3 direction = new Vector3 (InputHorizontal, 0, InputVertical);

		rb.MovePosition (rb.position + direction * MoveSpeed * Time.fixedDeltaTime);
	}
}
