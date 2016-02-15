using UnityEngine;
using System.Collections;

public class controlLLamas : MonoBehaviour {

	public ParticleEmitter particula;
	private float Tiempo=0.0f;
	public float aumento = 0.3f;

	// Use this for initialization
	void Start () {
	
		particula = GetComponent<ParticleEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
	

		if(CambioColor.ApagarLlamas == true){
			Debug.Log("Aqui");
			Tiempo += Time.deltaTime * aumento;
			if(particula.minEmission>=0){
				Debug.Log("Aqui");
				particula.minEmission -= Tiempo;
				particula.maxEmission -= Tiempo;
			}
		}

	}
}
