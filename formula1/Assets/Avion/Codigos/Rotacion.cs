using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {
	public Rigidbody rb;
	float tUp, tDown;
	const float t = 0.3f;

	// Use this for initialization
	void Start(){
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
		tUp = tDown = 0;
	}
	
	// Update is called once per frame
	void Update(){
		Rotate(rb);
	}
	
	void Rotate(Rigidbody r){
		float angle;

		angle = 0;
		Debug.Log("tup: " + tUp + "; tdown: " + tDown);
		if(r.velocity.y > 0.1){
			if(tDown > t && tDown < 4*t){
				angle = Mathf.Lerp(-70, 0, r.velocity.y / 15f);
				tDown += Time.deltaTime;
				tUp = 0;
			}else{
				angle = Mathf.Lerp (0, 30, r.velocity.y / 15f);
				tUp += Time.deltaTime;
				tDown = 0;
			}
		}else if(r.velocity.y < -0.1 && r.velocity.y != 0){
			angle = Mathf.Lerp (0, -70, -r.velocity.y / 15f);
			tDown += Time.deltaTime;
			tUp = 0;
		}
		transform.rotation = Quaternion.Euler(0, 0, angle*Time.deltaTime*55);

	}
}
