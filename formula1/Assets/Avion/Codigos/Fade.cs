using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public static bool NivelTerminado = false;
	public float Reduccion = 1.0f,aux;
	public Color color;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		color.a = 255;
		NivelTerminado = false;
	}
	
	// Update is called once per frame
	void Update () {
		aux = color.a;
		//Debug.Log(rend.material.color.a);
		color = rend.material.color;
		if(!NivelTerminado){
			if (color.a > 0.0f) {

				color.a -= Time.deltaTime * Reduccion;
			} else {

				this.gameObject.SetActive (false);
			}
		}

		rend.material.color = color;
	}
}
