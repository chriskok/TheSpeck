using UnityEngine;
using System.Collections;

public class TimedDeath : MonoBehaviour
{
	public float lifetime;

	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
