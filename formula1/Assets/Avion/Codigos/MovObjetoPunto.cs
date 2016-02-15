using UnityEngine;
using System.Collections;

public class MovObjetoPunto : MonoBehaviour {

	public Rigidbody rb;
	public ParticleSystem particulaRing;
	public GameObject Puntero;
	public GameObject Seguidor;
	public Vector3 direction;
	static public bool Click = false , movNivel = false;
	static public bool NivelCompletado = false;
	public float movementSpeed = 20.0f; //20
	public float DistanciaRay;
	public Vector3 posSeguidor;
	int contador = 1;
	public float Tiempo = 0.0f;
	static public int Niveles;
	static public bool BlockMov = false;
	private bool comienzo = true;
	public GameObject nivelActual;

	//RayCast 
	//int[] niveles = new int[2];

	void Start () {

		Niveles = 3;
		rb = GetComponent<Rigidbody>();
		particulaRing = Puntero.GetComponent<ParticleSystem>();
	}
	//******************************************************
	void Update () {

		RaycastHit hit;
		Ray ForwardRay = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward, Color.yellow);
		posSeguidor = Seguidor.transform.position;

		if(NivelCompletado){

			if(nivelActual){

				LightSwitch.completado[nivelActual.GetComponent<LightSwitch>().nivel] = true;
				NivelCompletado = false;
			}
		}

		if (Physics.Raycast (ForwardRay, out hit, DistanciaRay)) {
			
			if (hit.collider.name.StartsWith("Nivel 1")) {

				comienzo = false;
				Niveles = 3;
			
			}

			if (hit.collider.name.StartsWith("Nivel 2")) {

				comienzo = false;
				Niveles = 2;
			
			}

			if (hit.collider.name.StartsWith("Nivel 3")) {

				comienzo = false;
				Niveles = 1;
			
			}
			print(hit.collider.name);
		} else {

			if(!comienzo){
				Niveles = 0;
			}
		}

		if(Input.GetKey(KeyCode.Space)){

			if(Niveles == 1){

				CambioColor.niveles = 2;
				Application.LoadLevel (4);
			}

			if(Niveles == 2){

				CambioColor.niveles = 3;
				Application.LoadLevel (4);
			}

			if(Niveles == 3){
				
				CambioColor.niveles = 5;
				Application.LoadLevel (4);
			}
		}

		if(BlockMov == false){

			if(Input.GetKey (KeyCode.Escape)){

				Application.LoadLevel (0);
			}

			direction = (posSeguidor - transform.position).normalized;

			if(Click == true){
			
				Tiempo += Time.deltaTime;
				particulaRing.Play ();
				/*
				if(Tiempo >= 0.5f){
					
					ps3.Stop ();
				}
				*/
			}else{

				particulaRing.Stop ();
			}

			if(Click == true && contador == 1){

				//ps3.transform.position = new Vector3 (Seguidor.transform.position.x,Seguidor.transform.position.y,Seguidor.transform.position.z);
				contador = 0;
			}

			if (Click == false) {

				Tiempo = 0.0f;
			} 
	  }
	}
	//******************************************************
	void FixedUpdate() {

		if ((Click == true) && (movNivel)) {

			rb.MovePosition (transform.position + direction * movementSpeed * Time.deltaTime);
		} else {

			rb.velocity = rb.velocity.normalized * 0.0f;
		}
	}

	//******************************************************
	void OnTriggerEnter(Collider collision) {


		if (collision.tag == "Seguidor") {
			
			Click = false;
		}

	}

	void OnTriggerStay(Collider other) {

		if (other.tag == "Seguidor") {

			Click = false;   
		}

		if(other.tag == "nivel"){

			nivelActual = other.gameObject;
		}
	}

}
