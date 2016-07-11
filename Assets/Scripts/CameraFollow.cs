using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;	// This makes the zoom in / out not work, need to tie the two things together better
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.position + offset;
		//transform.RotateAround (player.position, Vector3.up, 20 * Time.deltaTime);
	}

	void ChangePosition() {
		
	}
}
