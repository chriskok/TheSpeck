using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Storekeeper : MonoBehaviour {

	public static Storekeeper instance = null; 
	public Text coinText;
	public Text speedP;
	public Text shieldP;

	// Update is called once per frame
	void Update () {
		coinText.text = "Coins: " + ScoreManager.coins;
		speedP.text = "Price: " + ScoreManager.speedPrice;
		shieldP.text = "Price: " + ScoreManager.shieldPrice;
	}

	public void BoughtSpeed()
	{
		if (ScoreManager.coins >= ScoreManager.speedPrice) {
			ScoreManager.coins -= ScoreManager.speedPrice;
			ScoreManager.speedPrice++;
		} else {
			return;
		}
	}

	public void BoughtShield()
	{
		if (ScoreManager.coins >= ScoreManager.shieldPrice) {
			ScoreManager.coins -= ScoreManager.shieldPrice;
			ScoreManager.shieldPrice++;
		} else {
			return;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Main");
	}
}
