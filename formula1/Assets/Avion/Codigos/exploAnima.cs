using UnityEngine;
using System.Collections;

public class exploAnima : MonoBehaviour {
	
	public float tiempo;
	public float tanteo;

	//public float force = 100.0f;
	//public float radius = 5.0f;
	//public float upwardsModifier = 0.0f;
	//public ForceMode forceMode;
	
	// Update is called once per frame
	void Update () {

		tiempo += Time.deltaTime;

		if (tiempo >= tanteo) {

			transform.localScale = new Vector3(3.0F, 3.0F, 3.0F);
			if (tiempo >= 1){

				Destroy (this.gameObject);
			}
		} else {

			transform.localScale += new Vector3(0.8F, 0.8F, 0.8F);
		}
		/*
		if(exploAvion.explosion == true){
			foreach(Collider col in Physics.OverlapSphere(transform.position, radius)){
				
				if(col.rigidbody != null){
					
					
					col.rigidbody.AddExplosionForce(force,transform.position,radius,upwardsModifier,forceMode);
				}
				
			}
			exploAvion.explosion = false;
		}
		*/
	}
}
