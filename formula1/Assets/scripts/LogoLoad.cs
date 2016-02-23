using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoLoad : MonoBehaviour {

	public string name;
	private float contador = 0f;
	public float limiteT = 1f;

	void Update () {
	
		Tiempo ();
	}

	void Tiempo() {

		if (contador <= limiteT) {

			contador += Time.deltaTime; 
		} else {

			SceneManager.LoadScene(name);
		}
	}
}
