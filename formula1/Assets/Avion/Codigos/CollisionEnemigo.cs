using UnityEngine;
using System.Collections;
//1500
public class CollisionEnemigo : MonoBehaviour {
	public Transform ExplosionP,ExplosionG,ExplosionM,MyTransform;
	public Transform Chispas;
	public GameObject Padre;
	public float limite = 0.5f,tiempo = 0.0f;
	public bool Misil = false, rebote = false;
	private bool band = true;

	void Update(){

		if(rebote){
			//Debug.Log("Explosion");
			tiempo += 0.005f;
			if(tiempo >= limite){
				//Debug.Log("Explosion");
				Explo (ExplosionG, ExplosionP, ExplosionM, MyTransform);
				Destroy (Padre);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (!Misil) {
			if (col.name == ("bala(Clone)")) {

				if (band) {

					Score.puntaje += 10;
					band = false;
				}
				Explo (ExplosionG, ExplosionP, ExplosionM, MyTransform);
				Destroy (col.gameObject);
				Destroy (Padre);
			}

			if (col.name == "MOVavion") {
				//Debug.Log("MovAvion");
				Explo (ExplosionG, ExplosionP, ExplosionM, MyTransform);
				//Destroy(col.gameObject);
				Destroy (Padre);
			}

			if (col.GetComponent<Collider> ().tag == "plataforma") {

				//Debug.Log("plataforma");
				Explo (ExplosionG, ExplosionP, ExplosionM, MyTransform);
				//Destroy(col.gameObject);
				Destroy (Padre);
			}
		} else {

			if (col.name == "AvionRota") {

				//Debug.Log("AvionRota");
				Explo (ExplosionG, ExplosionP, ExplosionM, MyTransform);
				//Destroy(col.gameObject);
				Destroy (Padre);
			}
		}
	}

	void OnCollisionEnter (Collision collision) {

		ContactPoint contact;
		Debug.Log (collision.collider.name);
		if (collision.collider.name == ("disparo")) {
			//Debug.Log (collision.collider.name);
			contact = collision.contacts [0];
			Vector3 pos = contact.point;
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
			Instantiate (Chispas, pos, rot);
			Destroy (collision.gameObject);
		} 

		if(collision.collider.name== ("ExploEsfera(Clone)") ){

			rebote = true;
		}
	}
	

	static public void Explo(Transform ExplosionG, Transform ExplosionP,Transform ExplosionM, Transform MyTransform){

		int nmro = Random.Range (1, 10);

		if((nmro == 1)||(nmro == 2)||(nmro == 3)||(nmro == 4)){

			Instantiate(ExplosionP,MyTransform.position,MyTransform.rotation);
		}

		if((nmro == 5)||(nmro == 6)||(nmro == 7)){
			
			Instantiate(ExplosionM,MyTransform.position,MyTransform.rotation);
		}

		if((nmro == 8)||(nmro == 9)){
			
			Instantiate(ExplosionG,MyTransform.position,MyTransform.rotation);
		}
	}
}
