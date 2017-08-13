using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerBullet") {
			other.gameObject.SetActive (false);
			return;
		} else {
			Destroy (other.gameObject);
		}
	}
}