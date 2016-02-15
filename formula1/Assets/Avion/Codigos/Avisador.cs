using UnityEngine;
using System.Collections;

public class Avisador : MonoBehaviour {

	public bool Instanciar = false;
	private GameObject Hijo;
	//public string TipoAux;
	private AvisadoresLife script;

	// Update is called once per frame
	void Start(){

		script = GetComponentInChildren<AvisadoresLife>();
		if(script){

			//Debug.Log("Encontro el script");
		}
	}


	void Update () {
	
		if (Instanciar && script) {

			//AvisadoresLife.Tipo = TipoAux;
			script.Aparecer = true;//AQUI!!
			Instanciar = false;
		} else if (!script) {

			Debug.Log("ERROR! no se ha encontrado el codigo AvisadoresLife");
		}
	}

	void OnTriggerEnter(Collider colisionador){

		if(colisionador.tag == "Avisador"){

			Instanciar = true;
		}
	}
}
