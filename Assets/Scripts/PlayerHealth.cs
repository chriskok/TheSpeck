using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public static int playerStaticHealth = 3;
	public static int playerHealth;

	public float invincibleTime = 3f;
	public GameObject player;
	private Collider2D playerCol;

	public Renderer graphicRenderer;
	public List<Image> HeartImageList = new List<Image> ();

	// Use this for initialization
	void Start () {
		playerHealth = playerStaticHealth;
		for (int i = 0; i < HeartImageList.Count; i++) {
			if (i < playerStaticHealth) {
				HeartImageList [i].enabled = true;
			} else {
				HeartImageList [i].enabled = false;
			}
		}

		playerCol = player.GetComponent<BoxCollider2D> ();
	}
	
	public void removeHealth(){
		playerHealth--;
		HeartImageList [playerHealth].enabled = false;

		//StartCoroutine(setInvincible ());
	}
		
	IEnumerator setInvincible(){
		graphicRenderer.material.color = new Color (1f, 1f, 1f, 0.5f);


		yield return new WaitForSeconds (invincibleTime);

		graphicRenderer.material.color = new Color (1f, 1f, 1f, 1f);
		playerCol.enabled = true;
	}
}
