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

			gameObject.SetActive (false); //Deactivate the bullet game object

			//If the player is dead once this shot hits...
			if (PlayerHealth.playerHealth <= 1) {
				other.GetComponent<PlayerHealth> ().removeHealth (); // remove the last bit of health
				Destroy (other.gameObject); //destroy the player game object

				//spawn the player death particles
				if (playerDeath != null) { 
					Instantiate (playerDeath, other.transform.position, Quaternion.identity);
				}

				GameController.gameOver = true; //Set the game mode to game over

			} else {
				Debug.Log ("HELLO");
				other.GetComponent<PlayerHealth> ().removeHealth ();
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