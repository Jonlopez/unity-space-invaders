using UnityEngine;
using System.Collections;

public class ControlDisparo : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Eliminamos el objeto si se sale de la pantalla
		if (transform.position.y > 10) {
			Destroy (gameObject);
		}	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "nave") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();		

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (gameObject);

		
			//Destroy (gameObject);

		} 
	}
}
