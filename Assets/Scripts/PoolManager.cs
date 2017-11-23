using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

	public static PoolManager _instance;

	public static PoolManager Instance
	{
		get {
			if (_instance == null) {
				GameObject go = new GameObject ("PoolManager");
				go.AddComponent<PoolManager> ();
			}
			return _instance;
		}
	}

	public GameObject playerBullet;
	public int bulletsToSpawn;
	public int enemyBulletsToSpawn = 150;
	public GameObject bulletContainer;
	public List<GameObject> bulletList = new List<GameObject>(); 

	public GameObject enemy1bullet;
	public GameObject enemy2bullet;
	public GameObject enemy3bullet;
	public List<GameObject> enemy1BulletList = new List<GameObject> ();
	public List<GameObject> enemy2BulletList = new List<GameObject> ();
	public List<GameObject> enemy3BulletList = new List<GameObject> ();

	void Awake () {
		if (_instance == null) {
			_instance = this;
		} /*else {
			Destroy (gameObject);
		}*/
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	
	void Start()
	{
		for (int i = 0; i < bulletsToSpawn; i++) {
			GameObject bullet = Instantiate (playerBullet, Vector3.zero, Quaternion.identity) as GameObject;
			bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive (false);
			bulletList.Add (bullet);
		}

		for (int i = 0; i < enemyBulletsToSpawn; i++) {
			GameObject bullet = Instantiate (enemy1bullet, Vector3.zero, Quaternion.identity) as GameObject;
			bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive (false);
			enemy1BulletList.Add (bullet);
		}

		for (int i = 0; i < enemyBulletsToSpawn * 2; i++) {
			GameObject bullet = Instantiate (enemy2bullet, Vector3.zero, Quaternion.identity) as GameObject;
			bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive (false);
			enemy2BulletList.Add (bullet);
		}

		for (int i = 0; i < enemyBulletsToSpawn; i++) {
			GameObject bullet = Instantiate (enemy3bullet, Vector3.zero, Quaternion.identity) as GameObject;
			bullet.transform.parent = bulletContainer.transform;
			bullet.SetActive (false);
			enemy3BulletList.Add (bullet);
		}
	}
}
