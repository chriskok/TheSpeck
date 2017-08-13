using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour 
{

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector2 startPosition;

	void Start () 
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + new Vector2(0,-1) * newPosition;
	}
}
