using UnityEngine;
using System.Collections;

public class BGCameraFollow : MonoBehaviour {

	public Transform mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = mainCamera.transform.rotation;
	}
}
