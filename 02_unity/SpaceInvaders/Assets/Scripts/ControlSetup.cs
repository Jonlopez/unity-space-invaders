using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSetup : MonoBehaviour {

	bool multiPlayer = true;

	// Use this for initialization
	void Start () {

		if(!this.multiPlayer)
			Destroy (GameObject.FindWithTag("nave2"));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BotonSalir(){
		Application.Quit();
	}

	public void BotonJugar(){
		
		Application.LoadLevel("Nivel1");
	}

	public void Multijugador (){
		if (!this.multiPlayer)
			this.multiPlayer = true;
		else
			this.multiPlayer = false;
	}
		
}
