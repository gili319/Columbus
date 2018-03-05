using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogHolder : MonoBehaviour {

	private Locations loc;

	void Start () {
		loc = FindObjectOfType<Locations> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		string[] names = other.gameObject.name.Split('_');
		loc.ShowBox(loc.getParagraph(Convert.ToInt32(names[1])));
	}

	void OnTriggerExit2D(Collider2D other){
		loc.HideBox();
	}
}
