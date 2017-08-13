using UnityEngine;
using System.Collections;

public class PathFollowing : MonoBehaviour {

	public Transform[] path;
	public float speed;
	public float reachDist = 0.5f;
	public int currentPoint = 0;

	void Start (){

	}

	void Update (){
		float dist = Vector3.Distance(path[currentPoint].position, transform.position);

		transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

		if (dist <= reachDist) {
			currentPoint++;
		}

		if (currentPoint >= path.Length) {
			currentPoint = 0;
		}
	}
}
