using UnityEngine;
using System.Collections;

public class PlayerBullets : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public float speedStat;

	void Start () {
		speedStat = ScoreManager.speedPrice;
		fireRate = 0.32f - (speedStat/50);
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire()
	{
		Debug.Log ("FIRE");
		for (int i = 0; i < PoolManager.Instance.bulletList.Count; i++) {
			if (PoolManager.Instance.bulletList [i].activeInHierarchy == false) {
				Debug.Log ("Fire: " + i);
				PoolManager.Instance.bulletList [i].transform.position = shotSpawn.position;
				PoolManager.Instance.bulletList [i].transform.rotation = Quaternion.Euler (0f, 0f, 90f);
				PoolManager.Instance.bulletList [i].SetActive (true);
				break;
			}
		}
			
	}
}
