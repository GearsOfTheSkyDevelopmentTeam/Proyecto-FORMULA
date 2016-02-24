using UnityEngine;
using System.Collections;

public class CursorNew : MonoBehaviour {


	public Texture2D CursorTexture;
	public int cursorSizeX = 16;
	public int cursorSizeY = 16;

	void Start(){

		Cursor.visible = false;
	}

	void OnGUI(){

		GUI.DrawTexture (new Rect(Event.current.mousePosition.x - cursorSizeX/2,Event.current.mousePosition.y - cursorSizeY/2, cursorSizeX, cursorSizeY),CursorTexture);
	}

}
