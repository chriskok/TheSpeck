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
		shieldP.text = "Price: " + ScoreManager.healthPrice;
	}

	public void BoughtSpeed()
	{
		if (ScoreManager.coins >= ScoreManager.speedPrice) {
			ScoreManager.coins -= ScoreManager.speedPrice;
			ScoreManager.speedPrice *= 2;
			PlayerBullets.speedStat++;
		} else {
			return;
		}
	}

	public void BoughtShield()
	{
		if (ScoreManager.coins >= ScoreManager.healthPrice) {
			ScoreManager.coins -= ScoreManager.healthPrice;
			ScoreManager.healthPrice *= 5;
			PlayerHealth.playerStaticHealth++;
		} else {
			return;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Main");
	}
}
