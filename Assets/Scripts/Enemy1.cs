using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour 
{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public float speed;

	private int zed;
	private Quaternion rotation;
	private float yVal;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
		yVal = transform.position.x;
	}

	void Fire ()
	{
		rotation = Quaternion.Euler(0,0,zed);
		Instantiate (shot, shotSpawn.position, rotation);
		zed += 15;
	}

	void Update ()
	{
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(-200, yVal), Time.deltaTime * speed);
	}
		
}
