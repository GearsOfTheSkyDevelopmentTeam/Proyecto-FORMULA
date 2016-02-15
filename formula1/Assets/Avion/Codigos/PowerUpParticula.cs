using UnityEngine;
using System.Collections;

public class PowerUpParticula : MonoBehaviour {

	public ParticleEmitter emisor;
	public float contador = 0.0f;

	// Use this for initialization
	void Start () {
	
		emisor = GetComponent<ParticleEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (movAvion.ActivarMov) {
			if (PowerUpCollision.PCollision) {

				if (emisor.minEmission <= 1000) {

					emisor.minEmission += Time.deltaTime * contador;
					emisor.maxEmission += Time.deltaTime * contador;
				}
			} else {

				if (emisor.minEmission > 0) {
					emisor.minEmission -= Time.deltaTime * contador;
					emisor.maxEmission -= Time.deltaTime * contador;
				}
			}
		} else {

			PowerUpCollision.PCollision = false;
			emisor.minEmission = 0;
			emisor.maxEmission = 0;
		}
	}
}
