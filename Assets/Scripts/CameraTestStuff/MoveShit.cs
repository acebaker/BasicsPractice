using UnityEngine;
using System.Collections;

public class MoveShit: MonoBehaviour {

	public bool shouldMove = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldMove) {
			transform.position += new Vector3 (0, 0, -1 * Time.deltaTime);
		}
	}
}
