using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class EtiquetaPrecio : MonoBehaviour{

	public static bool Activado = false;

	private Vector3 OffsetEtiqueta = new Vector3(0,.2f,0); 

	static Dictionary<string, Color> colores;
	static Dictionary<string, float> costos;
//	static Dictionary<string, Texture2D> imagenesCostos;

	private Object thisLock = new Object();

	public string nombreCosto;
	List<Renderer> rdrs;


	void Start(){

		rdrs = new List<Renderer>();
		rdrs.Add(transform.Find("Plane1").GetComponent<Renderer>());
		rdrs.Add(transform.Find("Plane2").GetComponent<Renderer>());


		foreach(Renderer r in rdrs){
			r.material.SetColor("_TintColor", Color.clear);
		}

		InicializarColores();
	}

	void OnMouseEnter(){
		Activado = true;

		foreach(Renderer r in rdrs){
			try{
				r.material.SetColor("_TintColor", colores[nombreCosto]);
			}catch(KeyNotFoundException){
				r.material.SetColor("_TintColor", Color.green - new Color(0, 0, 0, .4f));
			}
		}

		if(UIController.instance.zoom){
			UIController.instance.panelUpdatePosition = transform.position;
			UIController.instance.infoPanel = new UIController.InfoPanel(OffsetEtiqueta, ParteCarro.blue);
			UIController.instance.infoPanel.SetPanelColor(ParteCarro.blue, nombreCosto, transform.position);
	
		}
	}

	void OnMouseExit(){
		Activado = false;

		foreach(Renderer r in rdrs){
			r.material.SetColor("_TintColor", Color.clear);
		}

		UIController.instance.infoPanel.UnsetInfoPanelColor( true );
	}
		
	void OnMouseDown(){


	}

	void InicializarColores(){
		lock(thisLock){
			if(colores == null || costos == null /*|| imagenesCostos == null*/){
				colores = new Dictionary<string, Color>();
				costos = new Dictionary<string, float>();
//				imagenesCostos = new Dictionary<string, Texture2D>();

//				imagenesCostos.Add("transparente", Resources.Load("Logos/clear", typeof(Texture2D)) as Texture2D);
//				imagenesCostos.Add("ups", Resources.Load("Logos/UPS", typeof(Texture2D)) as Texture2D);

				colores.Add ("Diamond", new Color (0, 0, .70f, .60f));
				colores.Add ("Platinum", Color.cyan - new Color (0, 0, 0, .4f));
				colores.Add ("Gold", Color.yellow - new Color (0, 0, 0, .4f));
				colores.Add ("Silver", Color.white - new Color (0, 0, 0, .4f));

				costos.Add ("Diamond", 1800000);
				costos.Add ("Platinum", 950000);
				costos.Add ("Gold", 600000);
				costos.Add ("Silver", 300000);
			}
		}
	}
}

