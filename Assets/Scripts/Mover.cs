using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	//public Vector3 Velocity;

	//void Start()
	//{
	//	rb.AddForce (transform.right *speed);
	//}

	void OnEnable ()
	{
		rb.AddForce (transform.right *speed);
	}

	//void Update()
	//{
	//	transform.Translate(Velocity * Time.deltaTime * speed);    
	//}


}
