using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour {

	public int tipo = 0;
	public GUISkin customSkin;
	public string levelName;
	public GameObject levelInfoPrefab, Nivel;
	public Canvas canvas;
	public GameObject ruta; 
	public int contadorNiveles = 0;
	public GameObject[] BloqueoNiveles = new GameObject[4];
	public bool BN = true;
	public int nivel = 0, cantidadNiveles = 0;
	static public bool[] completado = new bool[4];
	static private bool OneReset = true;

	int i;
	float offset = 1.5f;
	GameObject levelPanel;
	Light l;

	// Use this for initialization
	void Start(){
		contadorNiveles = contadorNiveles - 1;
		l = GetComponentInChildren<Light>();
		Nivel = this.gameObject;
		nivel -= 1;
		l.enabled = false;
		levelPanel = Instantiate(levelInfoPrefab);
		levelPanel.transform.SetParent(canvas.transform, false);
		levelPanel.transform.position = new Vector3(transform.position.x, transform.position.x, transform.position.z);
		//levelPanel.GetComponentInChildren<Text>().text = Nivel.name;
		levelPanel.GetComponentInChildren<Text>().text = levelName;

		if(ruta){

			ruta.GetComponentsInChildren<LightSwitch>();
		}
		if(OneReset){
			for(i=0;i<cantidadNiveles;i++){

				completado[i] = false;
			}
			OneReset = false;
		}

	}

	void Update(){
	
		if(l){
			if(l.enabled){
				levelPanel.SetActive(true);
				Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
				Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
				levelPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
			}else{
			
				levelPanel.SetActive(false);
			}
		}

		if(contadorNiveles != -1){

			if(completado[nivel]){

				if(contadorNiveles != -1){

					BloqueoNiveles[contadorNiveles].gameObject.GetComponent<LightSwitch>().BN = false;
					contadorNiveles -= 1;
				}
			}
		}
	}

	void OnGUI(){
		/*
		GUI.skin = customSkin;

		//Vector3 screenPos = Camera;

		if(l.enabled){
			GUI.Label(new Rect(20, 20, 80, 80), levelName);
		}
		*/
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			l.enabled = true;
		}
	}

	void OnTriggerExit(Collider c){
		if(c.tag == "Player" && tipo == 0){
			l.enabled = false;
		}
	}
}
