using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance = null; 

	void Awake () {
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
}
