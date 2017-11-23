using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImTouched : MonoBehaviour {
	
	public static bool moveable;
	public static bool moveableA;
	public GameObject pauseScreen;
	public GameObject touchMe;
	public Text pauseText;
	public Text pauseMessage;

	void Update ()
	{
		#if UNITY_EDITOR 
		//If mouse button 0 is down
		if(Input.GetMouseButton(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider.tag == "PlayerMover") {
				moveable = true;
				Time.timeScale = 1;
				pauseScreen.SetActive(false);
				touchMe.SetActive(false);
				pauseText.text = " ";
				pauseMessage.text = " ";
			} else {
				moveable = false;
				return;
			}
		}else{
			Time.timeScale = 0;
			pauseScreen.SetActive(true);
			touchMe.SetActive(true);
			pauseText.text = "PAUSED";
			pauseMessage.text = " hold the green\n box to start";
			moveable = false;
		}
		#endif

		#if UNITY_ANDROID && !UNITY_EDITOR
		if (Input.touchCount >= 1)
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

			if (hit.collider.tag == "PlayerMover") {
				moveableA = true;
				Time.timeScale = 1;
				pauseScreen.SetActive(false);
				touchMe.SetActive(false);
				pauseText.text = " ";
				pauseMessage.text = " ";
			} else {
				moveableA = false;
				return;
			}
		}else{
			Time.timeScale = 0;
			pauseScreen.SetActive(true);
			touchMe.SetActive(true);
			moveableA = false;
			pauseText.text = "PAUSED";
			pauseMessage.text = " hold the green\n box to start";
		}
		#endif
	}

}
