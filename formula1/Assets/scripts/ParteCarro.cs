using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParteCarro : MonoBehaviour {
	
	Renderer rend;
	Renderer rendPadre;
	public Vector3 desplazamientoLocal;

	public static Color blue = new Color(1f, .76f, 0f, .80f);

	[TextArea(2, 10)]
	public string informacion;
	public bool drawGizmos = false;

	public int ModoCamara {get; private set;}
	public bool esParte {get; private set;}

	public Color colorOriginal;
	Color targetColor;
	int colorActual;
	static List<Color> colores;
	static Dictionary<Color, string> nombreColores;

	List<GameObject> etiquetas;

	public Renderer Rend{
		get{
			return rendPadre;
		}
	}

	public Vector3 DesplazamientoLocal{
		get{
			return transform.position - desplazamientoLocal;
		}
	}

	void Start(){
		etiquetas = new List<GameObject>();
		foreach(Transform t in GetComponentsInChildren<Transform>()){
			if(t.parent != null && t.parent == transform){
				etiquetas.Add(t.gameObject);
			}
		}
		SetEtiquetas(false);

		esParte = gameObject.tag == "Parte";
		ModoCamara = esParte ? ControlCamara.Restringido : ControlCamara.NoRestringido;
		rend = GetComponent<Renderer>();
		if(rend) rend.material.SetFloat("_Outline",0);

		if(esParte){
			rendPadre = transform.parent.GetComponent<Renderer>();
			InicializarColores ();
		}
	}

	void Update(){
		if(ControlCamara.instance.clickBlockeado){
			if(rend){
				rend.material.SetFloat("_Outline", 0);
			}
			if(!esParte && UIController.instance.infoPanel != null){
				UIController.instance.infoPanel.UnsetInfoPanelColor(true);
			}
		}
			
		if(esParte && rendPadre && rendPadre.material.color != targetColor){
			rendPadre.material.color = Color.Lerp(rendPadre.material.color, targetColor, .2f);
		}
	}

	// cambia el target color y retorna el nombre del color como una cadena
	public string CambiarColor(int i){
		colorActual = mod(colorActual + i, colores.Count + 1);
		if(colorActual == colores.Count){
			targetColor = colorOriginal;
			return "Original";
		}else{
			targetColor = colores[colorActual];
			return nombreColores[targetColor];
		}

	}

	public string ObtenerColorActual(){
		return colorActual == colores.Count ? "Original" : nombreColores[targetColor];
	}

	void InicializarColores(){
		if(colores == null){
			if(colores == null){
				colores = new List<Color>();
				nombreColores = new Dictionary<Color, string>();

				colores.Add(Color.blue);
				colores.Add(Color.yellow);
				colores.Add(Color.red);
				colores.Add(Color.magenta);

				nombreColores.Add(Color.blue, "Azul");
				nombreColores.Add(Color.yellow, "Amarillo");
				nombreColores.Add(Color.red, "Rojo");
				nombreColores.Add(Color.magenta, "Magenta");
			}
		}

		colorOriginal = rendPadre.material.color;
		targetColor = colorOriginal;
		colorActual = colores.Count;
	}


	void OnMouseEnter() {
		if(!ControlCamara.instance.clickBlockeado || UIController.instance.zoom){
			if(rend){
				rend.enabled = true;
				rend.material.SetFloat("_Outline", 2f);
			}

			UIController.instance.parteCarro = this;

			if(!esParte){
				
				string name = "UIConductor";
				GameObject panel = Instantiate(Resources.Load(name) as GameObject);
				UIController.instance.infoPanel = new UIController.InfoPanel(panel, new Vector3(0, 0f, -.8f), blue);
				UIController.instance.infoPanel.SetPanelColor(blue, informacion, transform.position);
				UIController.instance.panelUpdatePosition = transform.position;
			}
		}
	}		


	void OnMouseExit(){
		if(!ControlCamara.instance.clickBlockeado){
			if(rend){
				rend.enabled = false;
				rend.material.SetFloat("_Outline", 0);
			}
			if(!esParte) UIController.instance.infoPanel.UnsetInfoPanelColor( true );
		}
	}

	void OnMouseDown(){
		if(!ControlCamara.instance.clickBlockeado){
			UIController.instance.Zoom(this);
		}
	}

	// para observar el desplazamiento local
	void OnDrawGizmos(){
		if(drawGizmos){
			Gizmos.color = Color.black;
			Gizmos.DrawWireSphere(DesplazamientoLocal, .2f);
		}
	}

	public void SetEtiquetas(bool value){
		foreach(GameObject g in etiquetas){
			g.SetActive(value);
		}
	}

	static int mod(float a, float b){
		return (int)(a - b * Mathf.Floor(a / b));
	}
}
