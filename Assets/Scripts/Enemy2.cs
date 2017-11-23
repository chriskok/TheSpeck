using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	private Vector2 currentPos;
	private Vector2 newPos;
	private int turnNum = 1;
	public float speed;
	public float reachDist;

	private int maxZed = 360; 
	private Quaternion rotation;


	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
		currentPos = transform.position;
		newPos = currentPos + new Vector2 (0, -5);
	}

	void Fire ()
	{
		for (int zed = 0; zed < maxZed; zed += 15) {
			rotation = Quaternion.Euler (0, 0, zed);
			//Instantiate (shot, shotSpawn.position, rotation);
		

			for (int i = 0; i < PoolManager.Instance.enemy2BulletList.Count; i++) {
				if (PoolManager.Instance.enemy2BulletList [i].activeInHierarchy == false) {
					//Debug.Log ("Fire: " + i);
					PoolManager.Instance.enemy2BulletList [i].transform.position = shotSpawn.position;
					PoolManager.Instance.enemy2BulletList [i].transform.rotation = rotation;
					PoolManager.Instance.enemy2BulletList [i].SetActive (true);
					break;
				}
			}
		}
	}

	void Update ()
	{

		float dist = Vector2.Distance(newPos, transform.position);

		transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime * speed);

		if (dist <= reachDist) {
			currentPos = transform.position;
			if (turnNum == 1) {
				newPos = currentPos + new Vector2 (-5, 0);
				turnNum = 2;
			} else if (turnNum == 2) {
				newPos = currentPos + new Vector2 (9, 0);
				turnNum = 3;
			}else if (turnNum == 3) {
				newPos = currentPos + new Vector2 (-9, 0);
				turnNum = 2;
			}
		}
	}
}
