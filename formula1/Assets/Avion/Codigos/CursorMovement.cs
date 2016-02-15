using UnityEngine;
using System.Collections;

public class CursorMovement : MonoBehaviour{

	MatrizDato m = new MatrizDato();
	public GameObject nivelActual;
	LightSwitch codigo;

	// Use this for initialization
	void Start(){
		//Inicializando 
		for(int i=0; i<10; i++){
			for(int j=0; j<10; j++){
				m.modArr(i, j);
			}
		}

		Vector3 v = new Vector3(-20, -0.2f, 9.3f);
		m.modArr(0, 0, v);

		transform.position = v;

		v = new Vector3(0, -0.2f, 9.3f);
		m.modArr(1, 0, v);

		v = new Vector3(0, -0.2f, 30.0f);
		m.modArr(1, 1, v);

		v = new Vector3(20, -0.2f, 9.3f);
		m.modArr(2, 0, v);
	}
	
	// Update is called once per frame
	void Update(){

		if(nivelActual){

			if(!codigo.BN){

				MovObjetoPunto.movNivel = true;
			}else{

				MovObjetoPunto.movNivel = false;
			}
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(m.movDerecha()) transform.position = m.obtV();
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(m.movIzquierda()) transform.position = m.obtV();
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(m.movAbajo()) transform.position = m.obtV();
		}else if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(m.movArriba()) transform.position = m.obtV();
		}
	}

	void OnTriggerEnter(Collider collision) {

		if (collision.tag == "nivel") {

			nivelActual = collision.gameObject;
			codigo = nivelActual.GetComponent<LightSwitch>();
			MovObjetoPunto.Click = true;
		}
	}
}
