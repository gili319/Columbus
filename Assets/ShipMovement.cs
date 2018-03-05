using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

//	private Locations loc;

	// Use this gggfor initialization
	void Start () {
//		loc = FindObjectOfType<Locations> ();
		//print ("yo im a ship");
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		transform.Translate (vertical * Time.deltaTime * -1 ,0f, 0f);
		transform.Rotate (0f, 0f, horizontal * Time.deltaTime * -90f);
	}
		
}
