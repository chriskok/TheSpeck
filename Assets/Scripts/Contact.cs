using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour
{
	public int scoreValue;
	public int coinValue;
	public GameObject death;
	public GameObject playerDeath;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
		{
			return;
		}

		if (other.tag == "Player")
		{
			Destroy (other.gameObject);
			Destroy (gameObject);
			GameController.gameOver = true;
			if (playerDeath != null) {
				Instantiate (playerDeath, other.transform.position, Quaternion.identity);
			}
		}

		if (other.tag == "PlayerBullet") 
		{
			GameController.score += scoreValue;
			ScoreManager.coins += coinValue;
			if (death != null) {
				Instantiate (death, transform.position, Quaternion.identity);
			}
		}

	}
}