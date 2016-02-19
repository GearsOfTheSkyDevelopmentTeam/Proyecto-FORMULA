using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour{

	//Variables UI
	GameObject mainPanel;
	GameObject exitMainPanel;

	GameObject quitZoom;

	GameObject colorPanel;
	Text textoColor;

	// botones disponibles:
	// exitMainPanel, quitZoom, Zoom
	Dictionary<string, Boton> botones;

	ParteCarro parteCarro = null;

	private static UIController _instance;

	//Metodos
	private UIController() {}

	void Start(){
		botones = new Dictionary<string, Boton>();
		botones.Add("QuitZoom", new Boton());
		botones.Add("ExitMainPanel", new Boton());
		botones.Add("Zoom", new Boton());

		quitZoom = GameObject.Find("QuitZoomButton");
		quitZoom.SetActive(false);

		colorPanel = GameObject.Find("ColorPanel");
		textoColor = colorPanel.transform.Find("Color").GetComponent<Text>();
		colorPanel.SetActive(false);

		mainPanel = GameObject.Find("MainPanel");
		exitMainPanel = mainPanel.transform.Find("Exit").gameObject;
		mainPanel.SetActive(false);
	}

	public void Zoom(ParteCarro _parteCarro){
		parteCarro = _parteCarro;
		quitZoom.SetActive(true);
		ControlCamara.instance.CambiarTarget(parteCarro, true);
	}

	public void Zoom(){
		DesactivarUIParte();
		quitZoom.SetActive(true);
		ControlCamara.instance.CambiarTarget(parteCarro, true);
	}

	public void QuitZoom(){
		quitZoom.SetActive(false);
		ControlCamara.instance.Reset();
		if(parteCarro.esParte){
			ActivarUIParte(parteCarro);
		}
	}
		
	public void ActivarUIParte(ParteCarro _parteCarro){
		colorPanel.SetActive(true);
		mainPanel.SetActive(true);
		parteCarro = _parteCarro;
		textoColor.text = parteCarro.ObtenerColorActual();
		ControlCamara.instance.BlockearCLick();
	}
		
	public void DesactivarUIParte(){
		mainPanel.SetActive(false);
		colorPanel.SetActive(false);
		ControlCamara.instance.DesbloquearClick();
	}

	public void CambiarColor(int i){
		textoColor.text = parteCarro.CambiarColor(i);
	}

	// singleton
	public static UIController instance{
		get{
			if(_instance == null){
				_instance = (UIController) FindObjectOfType(typeof(UIController));
			}
			if(_instance == null){
				_instance = new UIController();
			}
			return _instance;
		}
	}


	// estructura auxiliar para el manejo de botones
	public struct Boton{
		bool presiono;
		bool solto;

		public Boton(bool _presiono=false, bool _solto=true){
			presiono = _presiono;
			solto = _solto;
		}

		public void Actualizar(bool _presiono, bool _solto){
			this = new Boton(_presiono, _solto);
		}

		bool EstaPresionado(){
			return presiono && !solto;
		}
	}

	public void PresionarBoton(string nombreBoton){
		botones[nombreBoton].Actualizar(true, false);
	}

	public void SoltarBoton(string nombreBoton){
		botones[nombreBoton].Actualizar(false, true);
	}
}

//	public static void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ){
//		Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
//		_sprite.transform.position = Camera.main.WorldToScreenPoint(centerPos);
//		Vector3 direction = _finalPosition - _initialPosition;
//		direction = Vector3.Normalize(direction);
//		_sprite.transform.right = direction;
//		if (_mirrorZ) _sprite.transform.right *= -1f;
//		Vector3 scale = new Vector3(1,1,1);
//		scale.x = Vector3.Distance(_initialPosition, _finalPosition);
//		_sprite.transform.localScale = scale;
//	}