using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	//Public Variables
	public GameObject player;

	//Private Variables
	private Vector2 touchCache;
	public Vector2 playerPos;
	private bool touched = false;

	void Start () 
	{
		playerPos = player.transform.position;
	}

	void Update () 
	{
		//If running game in editor
		#if UNITY_EDITOR
		if(ImTouched.moveable == true && player != null)
		{
			//Cache mouse position
			Vector3 mouseCache = Input.mousePosition;
			Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseCache);
			playerPos = new Vector2(mouseWorld.x, (mouseWorld.y + 1.1f));
			touched = true;
		}
		#endif
		//If a touch is detected
		if (ImTouched.moveableA == true && player != null)
		{
			//For each touch
			foreach (Touch touch in Input.touches)
			{
				//Cache touch position
				touchCache = touch.position;
				Vector3 touchWorld = Camera.main.ScreenToWorldPoint(touchCache);
				playerPos = new Vector2(touchWorld.x, (touchWorld.y + 1.1f));
			}
			touched = true;
		}
	}

	//FixedUpdate is called once per fixed time step
	void FixedUpdate()
	{
		if (touched)
		{
			//Transform rackets
			player.transform.position = playerPos;
			touched = false;
		}
	}
}
