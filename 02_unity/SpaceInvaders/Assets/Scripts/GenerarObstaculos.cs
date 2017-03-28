using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour {

	// Publicamos la variable para conectarla desde el editor
	public Rigidbody2D prefabMuro1;

	// Referencia para guardar una matriz de objetos
	private Rigidbody2D[,] muros;

	// Tamaño de la invasión alienígena
	private const int FILAS = 2;
	private const int COLUMNAS = 5;

	// Enumeración para expresar el sentido del movimiento
	private enum direccion { IZQ, DER };

	// Rumbo que lleva el pack de aliens
	private direccion rumbo = direccion.DER;

	// Posición vertical de la horda (lo iremos restando de la .y de cada alien)
	private float altura = 0.5f;

	// Límites de la pantalla
	private float limiteIzq;
	private float limiteDer;

	// Velocidad a la que se desplazan los aliens (medido en u/s)
	private float velocidad = 5f;


	// Use this for initialization
	void Start () {
		// Rejilla de 2x5 aliens
		generarMuros (FILAS, COLUMNAS, 1.5f, 1.0f);

		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla (añadimos una unidad a cada lado como margen)
		limiteIzq = -1.0f * distanciaHorizontal + 1;
		limiteDer = 1.0f * distanciaHorizontal - 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generarMuros (int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
	{
		/* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

		// Calculamos el punto de origen de la rejilla
		Vector2 origen = new Vector2 (transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

		// Instanciamos el array de referencias
		muros = new Rigidbody2D[filas, columnas];

		// Fabricamos un alien en cada posición del array
		for (int i = 0; i < filas; i++) {
			for (int j = 0; j < columnas; j++) {

				// Posición de cada alien
				Vector2 posicion = new Vector2 (origen.x + (espacioH * j), origen.y + (espacioV * i));

				// Instanciamos el objeto partiendo del prefab
				Rigidbody2D muro = (Rigidbody2D)Instantiate (Pref, posicion, transform.rotation);

				// Guardamos el alien en el array
				muros [i, j] = muro;

				// Escala opcional, por defecto 1.0f (sin escala)
				// Nota: El prefab original ya está escalado a 0.2f
				muro.transform.localScale = new Vector2 (0.2f * escala, 0.2f * escala);
			}
		}

	}

}
