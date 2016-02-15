using UnityEngine;
using System.Collections;

public class IApartida : MonoBehaviour {

	public float auxFuerza,auxFuerzaHorizontal,auxLimite,auxLimiteVelocidad;
	public int cantidad = 1,auxGravedad = 1;
	private int cantidadAux = 0;
	public float Salida = 0.0f;
	public Transform PrefabIA;
	public Transform auxPrefabIA;
	//public GameObject ObjectIA;
	public float contador;
	public Vector3 vectorAux;
	private IAMov script;
	public bool Activar = false;

	void Update () {
		vectorAux = transform.position;
		contador += Time.deltaTime; 

		if((cantidadAux < cantidad)&&(contador >= Salida) && (Activar)){

			auxPrefabIA = PrefabIA.transform.Find ("PunteroIA");
			script = auxPrefabIA.GetComponent<IAMov>();
			script.FuerzaHorizontal = auxFuerzaHorizontal;
			script.Fuerza = auxFuerza;
			script.gravedad = auxGravedad;
			script.LimiteVelocidad = auxLimiteVelocidad;
			script.Limite = auxLimite;
			Instantiate(PrefabIA,transform.position,Quaternion.Euler (0,-180,0));
			cantidadAux += 1;
			contador = 0.0f;
		}
	}

	void OnTriggerEnter(Collider Col){

		if(Col.name == "MOVavion"){

			Activar = true;
		}
	}
}
