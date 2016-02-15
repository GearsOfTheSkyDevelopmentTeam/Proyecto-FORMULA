using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {
	public float tiempoDisparo = 0.1f;
	private float proxDisparo = 0;
	public GameObject balaObjeto;
	//public GameObject Humo;
	private Transform shotInfo;
	public float rotShot = 3.5f;
	float x;
	float y;
	float z;

	// Use this for initialization
	void Start(){
		shotInfo = transform;
		shotInfo.rotation = Quaternion.Euler(0, 0, 90);
	}
	
	// Update is called once per frame
	void Update () {

		x = shotInfo.position.x;
		y = shotInfo.position.y;
		z = shotInfo.position.z;

		Shoot();
	}

	void Shoot(){

		if (PowerUpCollision.PCollision) {

			tiempoDisparo = 0.10f;
			rotShot = 2.7f;
		} else {

			rotShot = 0.5f;
			tiempoDisparo = 0.25f;
		}

		//shotInfo.rotation = Quaternion.Euler(0, 0, Random.Range(rotShot, -rotShot) + 90f);
		if(Time.time > proxDisparo && Input.GetKey(KeyCode.Space)){
			proxDisparo = Time.time + tiempoDisparo;
			Instantiate(balaObjeto, shotInfo.position, Quaternion.Euler(0, 0, Random.Range(rotShot, -rotShot) + 90f));
			//Instantiate(Humo, shotInfo.position, Humo.transform.rotation);
		}
	}
}
