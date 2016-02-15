using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	public GameObject Avion;
	public float DistanciaRay;
	public Transform avionPrefab;
	//public GameObject avionCompleto;
	public float x,y,z,Tiempo=0f;
	static public bool DetectCollision = false;
	static public bool DetectCollisionEnemigo = false;
	public Transform ExploEsfera;
	public Transform ParticulaExplo,ParticulaExplo2,ParticulaExplo3,MyTransform;
	private ParticleEmitter Particula;
	static public bool Choco;

	public RayCast(){

		Choco = false;
	}

	void start (){
		//GameObject player_go = GameObject.FindGameObjectWithTag("Player");
	
		Avion = GameObject.FindGameObjectWithTag ("AvionRota");
	}

	void Update() {

		if (!Particula) {
			Particula = GetComponentInChildren<ParticleEmitter>();
		} 

		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		//RaycastHit hit;

		Ray RigthRay = new Ray(new Vector3(x + 0.57f,y,z) , transform.right);
		Ray DownRay = new Ray(new Vector3(x + 0.57f ,y,z) ,transform.up * -1);
		Ray DownRay2 = new Ray(new Vector3(x - 0.57f ,y,z) ,transform.up * -1);
		Ray UpRay = new Ray(new Vector3(x + 0.57f ,y,z) ,transform.up);
		Ray UpRay2 = new Ray(new Vector3(x - 0.57f ,y,z) ,transform.up);
		Ray DiaRay = new Ray(new Vector3(x,y,z) ,new Vector3(1.7f,-1,0));
		Ray DiaRay2 = new Ray(new Vector3(x,y,z) ,new Vector3(1.7f,1,0));

		// rayos
		Debug.DrawRay(new Vector3(x + 0.57f,y,z) ,transform.right , Color.yellow);
		Debug.DrawRay(new Vector3(x,y,z) ,new Vector3(1.7f,-1,0), Color.blue);
		Debug.DrawRay(new Vector3(x,y,z) ,new Vector3(1.7f,1,0), Color.blue);
		Debug.DrawRay(new Vector3(x + 0.57f ,y,z) ,transform.up * -1, Color.yellow);
		Debug.DrawRay(new Vector3(x + 0.57f ,y,z) ,transform.up, Color.yellow);
		Debug.DrawRay(new Vector3(x - 0.57f ,y,z) ,transform.up * -1, Color.yellow);
		Debug.DrawRay(new Vector3(x - 0.57f ,y,z) ,transform.up, Color.yellow);

		if(Choco){

			Particula.emit = true;
			Tiempo += Time.deltaTime;
		}

		if(Tiempo >= 1f){

			DetectCollision = true;
			Tiempo = 0f;
		}
		/*
		if (Physics.Raycast (RigthRay, out hit, DistanciaRay) || Physics.Raycast (DownRay, out hit, DistanciaRay) || Physics.Raycast (DownRay2, out hit, DistanciaRay) || Physics.Raycast (UpRay, out hit, DistanciaRay) || Physics.Raycast (UpRay2, out hit, DistanciaRay) || Physics.Raycast (DiaRay, out hit, DistanciaRay) || Physics.Raycast (DiaRay2, out hit, DistanciaRay)) {

			//DetectCollision = true;
		} 
		*/
		if (DetectCollision == true) {
				/*
				if ((hit.collider.tag == "plataforma")) {

					Explosion (hit);
				}
				*/
				if (Choco){
					
					Explosion (transform.position);
				}
			DetectCollision = false;
		}

		if (DetectCollisionEnemigo == true) {
		
			DetectCollisionEnemigo = false;
			ExplosionConEnemigo ();
		}
	}

	void Explosion(Vector3 hit){

		Instantiate(avionPrefab, transform.position, transform.rotation);
		Instantiate (ExploEsfera, hit , Quaternion.identity);
		Instantiate (ParticulaExplo3, transform.position , Quaternion.identity);
		CollisionEnemigo.Explo (ParticulaExplo, ParticulaExplo2	,ParticulaExplo3 ,MyTransform);
		movAvion.ActivarMov = false;
		exploAvion.Activar = true;
		Destroy(Avion);
	}

	public void ExplosionTrampa(){
		Instantiate(avionPrefab, transform.position, transform.rotation);
//		Instantiate (ExploEsfera, transform.position, Quaternion.identity);
		Instantiate (ParticulaExplo3, transform.position , Quaternion.identity);
		movAvion.ActivarMov = false;
		exploAvion.Activar = true;
		Destroy(Avion);
	}

	void ExplosionConEnemigo (){

		Instantiate(avionPrefab, transform.position, transform.rotation);
		Instantiate (ExploEsfera, transform.position , Quaternion.identity);
		Instantiate (ParticulaExplo3, transform.position , Quaternion.identity);
		//CollisionEnemigo.Explo (ParticulaExplo, ParticulaExplo2	,ParticulaExplo3 ,MyTransform);
		movAvion.ActivarMov = false;
		exploAvion.Activar = true;
		Destroy(Avion);
	}

	void OnTriggerEnter(Collider col){

		if(col.name == "Enemigo"){

			DetectCollisionEnemigo = true;
		}

		if(col.tag == "plataforma"){

			Choco = true;
		}
	}
}
