using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {


	public Camera camera;
	bool holdingObject = false;
	GameObject heldObject;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("e")) {

			if (holdingObject == false) {
				RaycastHit hit;
				//Ray ray = camera.ScreenPointToRay(Input.mousePosition);

				Vector3 dir = camera.transform.forward;
				if (Physics.Raycast (camera.transform.position, dir, out hit)) {
					Vector3 objectHit = hit.point;

					if (hit.collider.gameObject.CompareTag ("TeleportPoint") == true || hit.collider.gameObject.isStatic == true) {
						return;
					}

					heldObject = hit.collider.gameObject;

					heldObject.transform.SetParent (transform);
					holdingObject = true;

					//thing.transform.position = objectHit;
				}

			} else {
				heldObject.transform.SetParent (null);
				heldObject = null;
				holdingObject = false;
			}


		}
	}
}
