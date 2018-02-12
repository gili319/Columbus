using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	// Use this gggfor initialization
	void Start () {
		print ("yo im a ship");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Vertical")*Time.deltaTime, 0f);
		//transform.Translate = new vector3(mathf.clamp(Time.time, 1.0F, 3.0F), 0, 0);
	}
}
