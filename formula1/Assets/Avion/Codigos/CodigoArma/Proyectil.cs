using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {

	public int speed;
	public float destroyTime = 2.5f;
	private float timeAcc = 0;
	// Use this for initialization
	void Start(){
		GetComponent<Rigidbody>().velocity = -transform.up * speed;
	}
	
	// Update is called once per frame
	void Update(){

		if (PowerUpCollision.PCollision) {
	
			speed = 130;
			GetComponent<Rigidbody>().velocity = -transform.up * speed;
		} else {

			speed = 100;
			GetComponent<Rigidbody>().velocity = -transform.up * speed;
		}

		timeAcc += Time.deltaTime;
		if(timeAcc >= destroyTime){
			Destroy(this.gameObject);
		}
	}
}
