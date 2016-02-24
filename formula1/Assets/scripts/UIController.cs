using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour{

	//Variables UI
	GameObject mainPanel;
	GameObject exitMainPanel;

	GameObject quitZoom;

	public InfoPanel infoPanel;
	public List<string> infoPanelNames = new List<string>();

	GameObject colorPanel;
	Text textoColor;

	GameObject canvasPanel;

	// botones disponibles:
	// exitMainPanel, quitZoom, Zoom
//	Dictionary<string, Boton> botones;

	public ParteCarro parteCarro = null;

	private static UIController _instance;

	//Metodos
	private UIController() {}

	void Start(){
		canvasPanel = GameObject.Find("CanvasPanel");

		quitZoom = GameObject.Find("QuitZoomButton");
		quitZoom.SetActive(false);

		colorPanel = GameObject.Find("ColorPanel");
		textoColor = colorPanel.transform.Find("Color").GetComponent<Text>();
		colorPanel.SetActive(false);

		mainPanel = GameObject.Find("MainPanel");
		exitMainPanel = mainPanel.transform.Find("Exit").gameObject;
		mainPanel.SetActive(false);
	}

	void Update(){
		if(infoPanel != null ){
			infoPanel.UpdatePanelColor(parteCarro.transform.position);
		}
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

	GameObject RandomPanelPrefab(){
		string name = infoPanelNames[Random.Range(0, infoPanelNames.Count)];
		print(name);
		GameObject panel = Instantiate(Resources.Load(name, typeof(GameObject)) as GameObject);
		return panel;
	}

	public class InfoPanel{
		GameObject infoPanel;
		List<Image> imagenesPanel;
		Text textoPanel;
		Color targetColor;
		Vector3 infoPanelOffset;

		public InfoPanel(GameObject panel, Vector3 offset, Color target){
//			if(infoPanel != null){
//				Destroy(infoPanel);
//			}
			panel.transform.SetParent(instance.canvasPanel.transform);
			infoPanel = panel;
			imagenesPanel = new List<Image>();
			imagenesPanel.Add(panel.GetComponent<Image>());
			imagenesPanel.Add(panel.transform.Find("Image").GetComponent<Image>());
			textoPanel = panel.transform.Find("Text").GetComponent<Text>();
			infoPanelOffset = offset;
			targetColor = target;

		}

		public InfoPanel(Vector3 offset, Color target){
//			if(infoPanel != null){
//				Destroy(infoPanel);
//			}
			infoPanel = instance.RandomPanelPrefab();
			infoPanel.transform.SetParent(instance.canvasPanel.transform);
			imagenesPanel = new List<Image>();
			imagenesPanel.Add(infoPanel.GetComponent<Image>());
			imagenesPanel.Add(infoPanel.transform.Find("Image").GetComponent<Image>());
			textoPanel = infoPanel.transform.Find("Text").GetComponent<Text>();
			infoPanelOffset = offset;
			targetColor = target;
		}

		public void SetPanelColor(Color _targetColor, string info, Vector3 position){
			Vector3 screenPos = Camera.main.WorldToScreenPoint(position + infoPanelOffset);
			textoPanel.text = info;
			infoPanel.transform.position = screenPos;
			targetColor = _targetColor;
		}

		public void UpdatePanelColor(Vector3 position){
			if(infoPanel != null){
				Vector3 screenPos = Camera.main.WorldToScreenPoint(position + infoPanelOffset);
				infoPanel.transform.position = screenPos;
				print(imagenesPanel[0].color);
				print(imagenesPanel[1].color);
				if(imagenesPanel[0].color != targetColor){
					Color newColor = Color.Lerp(imagenesPanel[0].color, targetColor, .4f);
					foreach(Image img in imagenesPanel){
						img.color = targetColor;
					}
					textoPanel.color = targetColor;
				}
			}
		}

		public void UnsetInfoPanelColor(){
			targetColor = Color.clear;
			Destroy(infoPanel);
		}
	}

	// estructura auxiliar para el manejo de botones
//	public struct Boton{
//		bool presiono;
//		bool solto;
//
//		public Boton(bool _presiono=false, bool _solto=true){
//			presiono = _presiono;
//			solto = _solto;
//		}
//
//		public void Actualizar(bool _presiono, bool _solto){
//			this = new Boton(_presiono, _solto);
//		}
//
//		bool EstaPresionado(){
//			return presiono && !solto;
//		}
//	}
//
//	public void PresionarBoton(string nombreBoton){
//		botones[nombreBoton].Actualizar(true, false);
//	}
//
//	public void SoltarBoton(string nombreBoton){
//		botones[nombreBoton].Actualizar(false, true);
//	}
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