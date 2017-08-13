using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGM : MonoBehaviour {

	public void StartButton () {
		SceneManager.LoadScene("Main");
	}

	public void QuitButton (){
		Application.Quit();
	}
}
