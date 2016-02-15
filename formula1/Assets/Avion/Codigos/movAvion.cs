using UnityEngine;
using System.Collections;

public class movAvion : MonoBehaviour {
	public static float Velocidad = 30.0f;
	public static bool ActivarMov = true, BloqueoUp = false;
	public static float magnitudVelocidad;
	public static bool Activar = true;
	public static bool ActivarRota = false;
	static public int contador;
	public Rigidbody rb;
	public float VeloUp,VeloDown,VeloParada,FuerzaRebote= 5f,aux,tiempo;
	public float LimiteVelocidad;
	public static float TCU = 0.0f;
	public float TCD = 0.0f;
	public bool auxActivar = false,Rebote = false;
	public GameObject HumoParadaObject, DashObject;
	public ParticleEmitter DashParticula;
	public ParticleSystem particulaParada;
	public bool band = true;

	void Start () {
		BloqueoUp = false;
		VeloUp = 200;
		VeloDown = 30;
		contador = 0;
		Activar = false;
		band = true;

		if(DashObject){

			DashParticula = DashObject.GetComponent<ParticleEmitter>();
		}

		if(HumoParadaObject){
			particulaParada = HumoParadaObject.GetComponent<ParticleSystem>();
		}
		rb = GetComponent<Rigidbody>();

	}


	void FixedUpdate() {

		if(RayCast.Choco){

			if(!Rebote){

				rb.AddForce(transform.up * FuerzaRebote );

				Rebote = true;
			}
		}

		if (BloqueoUp) {

			VeloDown = VeloParada;

			if(LimiteVelocidad >= 10){

				LimiteVelocidad -= 0.2f;
			}
			//LimiteVelocidad = 10;
		} else {

			VeloDown = 30f;
			LimiteVelocidad = 30f;
		}
		
		if(contador == 1){
			rb.AddForce (transform.right * aux);
		}
		if (Activar == false && contador == 1) {

			rb.AddForce (transform.up * (VeloDown * -1));
		} else if( contador==1 ){

			rb.AddForce (transform.up * VeloUp );
		}

		if(rb.velocity.magnitude >= LimiteVelocidad)
		{
			rb.velocity = GetComponent<Rigidbody>().velocity.normalized * LimiteVelocidad;
		}

		magnitudVelocidad = rb.velocity.magnitude;
	}


	void Update () {
	
		auxActivar = ActivarMov;

		if (contador == 0) {

			rb.useGravity = false;
			rb.velocity = new Vector3(Velocidad,0,0);
		} else {

			rb.useGravity = true;
		}

		if (Input.GetKey (KeyCode.A)) {

	
			BloqueoUp = true;
		} else {

			BloqueoUp = false;
		}

		///////PARTICULA PARADA CONTROL

		if(particulaParada){
			//0-20
			if(BloqueoUp){

				if(particulaParada.emissionRate <= 50){

					particulaParada.emissionRate += 0.5f;
				}
			}else{

				particulaParada.emissionRate = 0;
			}
		}

		////////PARTICULA DASH CONTROL

		if (DashParticula) {

			if (BloqueoUp) {

				if((DashParticula.minSize >= 0) && (DashParticula.maxSize >= 0)){

					DashParticula.minSize -= 0.01f;
					DashParticula.maxSize -= 0.01f;
				}
			} else{

				if((DashParticula.minSize <= 0.6f) && (DashParticula.maxSize <= 0.6f)){
					
					DashParticula.minSize += 0.01f;
					DashParticula.maxSize += 0.01f;
				}
			}

		}
	
		if (Input.GetKey (KeyCode.Space) && (ActivarMov) && (!BloqueoUp)) {

			//Velocidad = 15.0f;
			contador = 1;
			TCU += Time.deltaTime;
			TCD = 0.0f;
			Activar = true;
				if(TCU >= 0.4f ){

					VeloUp = 80;
					//VeloDown = 30;
				}
				else{
					
					VeloUp = 75;
					VeloDown = 10;
				}
		} else if (contador == 1) {

			Activar = false;
			TCD += Time.deltaTime;
				if(TCD >= 0.6f ){
					
					VeloDown = 30;
					if(Velocidad <= 20.0f){
						
						Velocidad += Time.deltaTime * 5;
					}
				}
			TCU = 0.0f;
		}
	}

	void OnGUI() {
		
		GUI.color = Color.white;
		
		if(!ActivarMov){
			
			//GUI.Box (new Rect ((Screen.width-200)/2, (Screen.height-100)/2, 140, 24), "Salir(esc) Reinicio(r)");
		}
		
	}

	void SalirJuego(){

		CambioColor.niveles = 1;
		Application.LoadLevel (1);
	}
}
