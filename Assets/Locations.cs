using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.UI;

public class Locations : MonoBehaviour {

	public GameObject dBox;
	public Text dText;
	public bool dialogActive;
	List<string[]> rowsInRange;

	// Use this for initialization
	void Start () {
		dBox.SetActive (false);
		rowsInRange = new List<string[]> ();
		List<string[]> rows = new List<string[]> ();
		using (var reader = new StreamReader (@"locations-csvSep.csv")) {
			
			while (!reader.EndOfStream) {
				var line = reader.ReadLine();
				var cells = line.Split (',');
				cells[1] = cells [1].Replace ('$', ',');
				cells[4] = cells [4].Replace ('$', ',');
				rows.Add(cells);
			}
		}


		string lat = "lat " + rows [2][3];
		string lng = "lng " + rows [2][2];



		//collect relevant coordinates
		for (int x = 1; x < rows.Count; x++) {
			double latNumDouble = Convert.ToDouble(rows[x][3]);
			double lngNumDouble = Convert.ToDouble(rows[x][2]);
			if (latNumDouble <= 52.072133 && latNumDouble >= -0.553451 && lngNumDouble >= -117.428982 && lngNumDouble <= 8.051392)
				rowsInRange.Add (rows [x]);
		}	



		print (rowsInRange.Count);

		GameObject[] cube = new GameObject[9];
		GameObject[] go = new GameObject[9];

		//Sprite locImage;
		//locImage = Resources.Load<Sprite> ("locIcon.png");

		for (int i = 0; i < 9; i++) {
			cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube[i].AddComponent<Rigidbody>();
			cube[i].GetComponent<Rigidbody>().useGravity = false;
			cube[i].transform.localScale = new Vector3 (0.05f, 0.05f, 0.01f); //size
			go[i] = new GameObject("go_" + i);
			go[i].transform.localScale = new Vector3 (0.05f, 0.05f, 0.01f);
			go[i].AddComponent<BoxCollider2D>();
			go[i].GetComponent <BoxCollider2D>().isTrigger = true;
		}


		for (int x = 1; x < rowsInRange.Count; x++) {

			switch (rowsInRange [x] [0]) {
				case "Hill":
					go [0].name = "go_" + x;
					break;
				case "Azores":
					go [1].name = "go_" + x;
					break;
				case "Valladolid":
					go [2].name = "go_" + x;
					break;
				case "Dominica":
					go [3].name = "go_" + x;
					break;
				case "Thomas":
					go [4].name = "go_" + x;
					break;
				case "Caribbean":
					go [5].name = "go_" + x;
					break;
				case "France":
					go [6].name = "go_" + x;
					break;
				case "Southampton":
					go [7].name = "go_" + x;
					break;
				case "Portugal":
					go [8].name = "go_" + x;
					break;
			}

		}

		//Hill
		go[0].transform.position = new Vector3(2f, 0f, 0);
		cube[0].transform.position = new Vector3(2f, 0f, 0); 

		//Azores
		go[1].transform.position = new Vector3(5f, -0.5f, 0);
		cube[1].transform.position = new Vector3(5f, -0.5f, 0); 

		//Valladolid
		go[2].transform.position = new Vector3(8f, 1.1f, 0);
		cube[2].transform.position = new Vector3(8f, 1.1f, 0); 

		//Dominica
		go[3].transform.position = new Vector3(3f, -2f, 0);
		cube[3].transform.position = new Vector3(3f, -2f, 0); 

		//Thomas
		go[4].transform.position = new Vector3(1.6f, -0.9f, 0);
		cube[4].transform.position = new Vector3(1.6f, -0.9f, 0); 

		//Caribbean
		go[5].transform.position = new Vector3(2f, -1.8f, 0);
		cube[5].transform.position = new Vector3(2f, -1.8f, 0); 

		//France
		go[6].transform.position = new Vector3(8.5f, 1.3f, 0);
		cube[6].transform.position = new Vector3(8.5f, 1.3f, 0); 

		//Southampton
		go[7].transform.position = new Vector3(7.8f, 1.8f, 0);
		cube[7].transform.position = new Vector3(7.8f, 1.8f, 0); 

		//Portugal
		go[8].transform.position = new Vector3(8f, 0.25f, 0);
		cube[8].transform.position = new Vector3(8f, 0.25f, 0);
	}





//
//	private void copyScene(){
//		FileUtil.CopyFileOrDirectory (".\\Assets\\Scene\\Circle.png", ".\\Assets\\Scene\\Circle2.png");
//	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown (KeyCode.Space)) {
			dBox.SetActive (false);
			dialogActive = false;
		}
	}

	public void ShowBox(string dialog){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialog;
	}

	public void HideBox(){
		dBox.SetActive (false);
	}

	public string getParagraph(int row){
		return rowsInRange [row] [4];
	}
		
}