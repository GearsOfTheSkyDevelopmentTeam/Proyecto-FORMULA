using UnityEngine;
using System.Collections;

public class Movimiento2 : MonoBehaviour {

	public bool bandU = true,bandD = true;
	private float mov;
	public float verSpeed=900, horSpeed=400,tiempoD = 0f,tiempoU = 0f,limite,velo;
	public int contadorU,contadorD;
	public static float vSpeed;
	public static float hSpeed;

	// Use this for initialization
	void Start () {
		mov = 0f;
		vSpeed = verSpeed;
		hSpeed = horSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(bandD && bandU){
			Mover(mov, vSpeed, hSpeed);
		}

		if(Input.GetKeyDown (KeyCode.Escape)){

			movAvion.ActivarMov = true;
			SalirJuego();
		}

		if(Input.GetKeyDown (KeyCode.UpArrow)){

			contadorU += 1;
		}

		if(Input.GetKeyDown (KeyCode.DownArrow)){
			
			contadorD += 1;
		}

		MovArriba();
		MovAbajo();
	}

	void MovArriba(){

		if((contadorU == 2) && tiempoU <= limite && bandU){
			bandU = false;
			GetComponent<Rigidbody>().AddForce(transform.up * velo);
		}
		
		if(tiempoU > limite){
			
			bandU = true;
			contadorU = 0;
			tiempoU = 0f;
		}
		
		if(contadorU >= 1){
			
			tiempoU += 0.01f;
		}
	}

	void MovAbajo(){
		
		if((contadorD == 2) && tiempoD <= limite && bandD){
			bandD = false;
			GetComponent<Rigidbody>().AddForce(transform.up * velo *-1);
		}
		
		if(tiempoD > limite){
			
			bandD = true;
			contadorD = 0;
			tiempoD = 0f;
		}
		
		if(contadorD >= 1){
			
			tiempoD += 0.01f;
		}
	}

	//Metodos personalizados

	//Metodo para moverse.
	void Mover(float m, float sp, float hp){
		m = Input.GetAxis("Vertical") * sp * Time.deltaTime;
		hp *= Time.deltaTime;
		GetComponent<Rigidbody>().velocity = new Vector3(hp, m, 0);
	}

	void SalirJuego(){

		CambioColor.niveles = 1;
		Application.LoadLevel (4);
	}
}
