using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuNivel : MonoBehaviour {

	public Canvas MN;
	public Canvas CanModo1;
	public Canvas CanModo2;
	public Button N1;
	public Button N2;
	public float Tiempo = 0.0f;
	bool ActivarTiempo = false;

	void Start () {

		//Cursor.visible = true;
		MN = MN.GetComponent<Canvas>();
		CanModo1 = CanModo1.GetComponent<Canvas>();
		CanModo2 = CanModo2.GetComponent<Canvas>();
		N1 = N1.GetComponent<Button>();
		N2 = N2.GetComponent<Button>();
		MN.enabled = true;
		CanModo1.enabled = false;
		CanModo2.enabled = false;
		
	}

	void Update (){

		if (MovObjetoPunto.Niveles == 1 && Tiempo<= 3) {

			Nivel1 ();
			MovObjetoPunto.BlockMov = true;
		} 

		if (MovObjetoPunto.Niveles == 2 && Tiempo<= 3) {
			
			Nivel2 ();
			MovObjetoPunto.BlockMov = true;
		} 

		if (ActivarTiempo == true && Tiempo<= 3) {
			
			Tiempo += Time.deltaTime;
		} else {
			
			ActivarTiempo = false;
			Tiempo = 0.0f;
		}
	}

	void Nivel1(){

		CanModo1.enabled = true;
		N1.enabled = true;	
	}


	void Nivel2(){
		
		CanModo2.enabled = true;
		N2.enabled = true;	
	}

	public void NoPress(){

		ActivarTiempo = true;
		MovObjetoPunto.BlockMov = false;
		MovObjetoPunto.Niveles = 0;
		CanModo2.enabled = false;
		N2.enabled = false;	
		CanModo1.enabled = false;
		N1.enabled = false;	

	}
	
	public void StartLevel1(){

		MovObjetoPunto.BlockMov = false;
		Application.LoadLevel (2);
	}
	
	public void StartLevel2(){

		MovObjetoPunto.BlockMov = false;
		Application.LoadLevel (3);
	}
	
	public void ExitMenu(){
		
		Application.LoadLevel (0);
	}
}
