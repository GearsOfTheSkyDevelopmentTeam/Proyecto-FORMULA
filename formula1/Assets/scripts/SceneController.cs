using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour{

	public void LoadSceneByName(string name){
		SceneManager.LoadScene(name);
	}

	public void ExitApp(){
		Application.Quit();
	}
}
