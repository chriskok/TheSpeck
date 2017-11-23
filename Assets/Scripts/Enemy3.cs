using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	private Vector2 currentPos;
	private Vector2 newPos;
	private bool right = true;
	public float speed;
	public float reachDist = 0.5f;

	private int maxZed = 300; 
	private Quaternion rotation;


	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
		currentPos = transform.position;
		newPos = currentPos + new Vector2 (5, -5);
	}

	void Fire ()
	{
		for(int zed = 240; zed <= maxZed; zed += 15)
		{
			rotation = Quaternion.Euler(0,0,zed);
			//Instantiate (shot, shotSpawn.position, rotation);

			for (int i = 0; i < PoolManager.Instance.enemy3BulletList.Count; i++) {
				if (PoolManager.Instance.enemy3BulletList [i].activeInHierarchy == false) {
					//Debug.Log ("Fire: " + i);
					PoolManager.Instance.enemy3BulletList [i].transform.position = shotSpawn.position;
					PoolManager.Instance.enemy3BulletList [i].transform.rotation = rotation;
					PoolManager.Instance.enemy3BulletList [i].SetActive (true);
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
			if (right) {
				newPos = currentPos + new Vector2 (-5, -5);
				right = false;
			} else if (!right) {
				newPos = currentPos + new Vector2 (5, -5);
				right = true;
			}
		}
	}

}
