using UnityEngine;
using System.Collections;

public class PartesCarro : MonoBehaviour {
	
	public Renderer rend;
	public Vector3 LocalDesplazamiento = new Vector3(0,0,0);

	void Start () {

		rend = GetComponent<Renderer>();
		rend.material.SetFloat("_Outline",0);
	}

	void Update () {

		if(ControlCamara.Seleccion) rend.material.SetFloat ("_Outline", 0);
	}

	void OnMouseEnter() {

		if(!ControlCamara.Seleccion){

			rend.enabled = true;
			rend.material.SetFloat("_Outline",0.0041f);
		}
	}

	void OnMouseOver() {
		/*
		if(rend.material.color.b <= 40){

			rend.material.color -= new Color(0, 0.1f, 0.1f) * 10 * Time.deltaTime;
		}
		*/
	}

	void OnMouseExit() {

		if (!ControlCamara.Seleccion) {

			rend.enabled = false;
			rend.material.SetFloat ("_Outline", 0);
		}
	}

	void OnMouseDown() {

		ControlCamara.desplazamiento = LocalDesplazamiento;
		ControlCamara.Seleccion = true;
		ControlCamara.Target = this.gameObject;
	}

}
