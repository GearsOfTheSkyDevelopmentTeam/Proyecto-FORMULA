using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIParte : MonoBehaviour{
//
//	List<Color> colors = new List<Color>();
//	Dictionary<Color, string> colorsName = new Dictionary<Color, string>();
//
//	[TextArea(2, 5)]
//	public string info;
//
//	Vector3 infoPanelOffset = new Vector3(0, .5f, 0);
//	int actColor = 0;
//	Renderer rdr;
//	Renderer parentRdr;
//
//	void Start(){
//		parentRdr = transform.parent.GetComponent<Renderer>();
//		InitColorList();
//	}
//
//	void OnMouseOver(){
//		UIController.UpdateInfoPanel(transform.position, info, infoPanelOffset);
//		UIController.SetInfoPanelColor(UIController.blue);
//	}
//
//	void OnMouseExit(){
//		UIController.SetInfoPanelColor(UIController.transparent);
//	}
//		
//	void OnMouseDown(){
//		UIController.CambiarParte(GetComponent<UIParte>());
//	}
//
//	public void ChangeColor(int i){
//		actColor = mod(actColor + i, colors.Count);
//		Mathf.Clamp(actColor, 0, colors.Count - 1);
//		new WaitForSeconds(3f);
//		parentRdr.material.color = colors[actColor];
//	}
//
//	public string GetActualColor(){
//		return colorsName[colors[actColor]];
//	}
//
//	void InitColorList(){
//		if(colors.Count == 0){
//			if(colors.Count == 0){
//				colors.Add(parentRdr.material.color);
//				colors.Add(Color.blue);
//				colors.Add(Color.yellow);
//				colors.Add(Color.red);
//				colorsName.Add(parentRdr.material.color, "Original");
//				colorsName.Add(Color.blue, "Azul");
//				colorsName.Add(Color.yellow, "Amarillo");
//				colorsName.Add(Color.red, "Rojo");
//			}
//		}
//	}
//
//	static int mod(float a, float b){
//		return (int)(a - b * Mathf.Floor(a / b));
//	}
}
