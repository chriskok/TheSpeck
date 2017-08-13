using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

	private static PoolManager _instance;

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
	public GameObject bulletContainer;
	public List<GameObject> bulletList = new List<GameObject>(); 

	void Awake () {
		_instance = this;
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
	}
}
