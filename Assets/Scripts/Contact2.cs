using UnityEngine;
using System.Collections;

public class Contact2 : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Boundary") || other.CompareTag ("Player"))
		{
			return;
		}

		if (other.tag == "Enemy")
		{
			Destroy (other.gameObject);
			gameObject.SetActive (false);
		}
	}

	void OnDisable ()
	{
		transform.position = Vector3.zero;
	}
}