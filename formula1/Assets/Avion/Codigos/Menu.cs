using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button startText2;
	public Button exitText;

	// Use this for initialization
	void Start () {

		//Screen.SetResolution(1024, 768, true);
		Cursor.visible = true;
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		//startText2 = startText2.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		quitMenu.enabled = true;

	}

	public void ExitPress(){

		quitMenu.enabled = true;
		startText.enabled = false;
		//startText2.enabled = false;
		exitText.enabled = false;

	}

	public void NoPress(){

		quitMenu.enabled = false;
		startText.enabled = true;
		//startText2.enabled = true;
		exitText.enabled = true;

	}

	public void StartLevel(){

		Application.LoadLevel (1);
		//Application.LoadLevel (2);
	}

	public void StartLevel2(){
		
		Application.LoadLevel (2);
		//Application.LoadLevel (2);
	}

	public void ExitGame(){

		Application.Quit ();
	}
}
