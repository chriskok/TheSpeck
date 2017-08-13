using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public int waveCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private int caseVal;
	private int xVal;
	private int yVal;
	private Vector2 spawnPosition;

	public static int score; 
	public Text scoreText;
	public GameObject restartButton;
	public Text gameOverText;
	public static bool gameOver;

	//for upgrade screen
	public GameObject upgradeButton;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		score = 0;
		UpdateScore ();
		gameOver = false;
	}

	void Update () 
	{
		scoreText.text = "Score: " + score;
		if (gameOver)
		{
			gameOverText.text = "GAME OVER";
			restartButton.SetActive (true);
			upgradeButton.SetActive (true);
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (waveWait >= 0)
		{
			for (int i = 0; i < waveCount; i++)
			{
				caseVal = Random.Range (0, hazards.Length);
				Quaternion spawnRotation = Quaternion.identity;
				switch (caseVal)
				{
				case 4:
					print ("Why hello there good sir! Let me teach you about Trigonometry!");
					break;
				case 3:
					print ("Hello and good day!");
					break;
				case 2:
					xVal = -5;
					for (int a = 0; a <= 2; a++) {
						spawnPosition = new Vector2 (xVal, 9);
						Instantiate (hazards [2], spawnPosition, spawnRotation);
						xVal += 3;
					}
					break;
				case 1:
					xVal = -2;
					for (int a = 0; a <= 2; a++) {
						spawnPosition = new Vector2 (xVal, 9);
						Instantiate (hazards [1], spawnPosition, spawnRotation);
						xVal += 2;
					}
					break;
				case 0:
					xVal = 8;
					yVal = 5;
					for (int a = 0; a <= 2; a++){
						spawnPosition = new Vector2 (xVal, yVal);
						Instantiate (hazards[0], spawnPosition, spawnRotation);
						xVal += 1;
						yVal += 1;
					}
					break;
				default:
					print ("Incorrect intelligence level.");
					break;
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			waveWait -= 0.5f;
		}
	}

	public void RestartGame () {
		SceneManager.LoadScene("Main");
	}

	public void UpgradeScreen () {
		SceneManager.LoadScene ("Upgrades");
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "GGWP NOOB";
		gameOver = true;
	}
		
}