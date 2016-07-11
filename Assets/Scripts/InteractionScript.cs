using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

	public GameObject cameraNull;
	public Camera camera;
	public GameObject currentObject;
	public float cameraSensitivity = 0.5f;
	public bool invertY = true;

	public bool firstPerson = true;

	InventoryManager inv;
	Vector3 previousMousePosition;
	int invertMultiplier = 1;



	void Awake() 
	{
		inv = GetComponent<InventoryManager> ();
		previousMousePosition = Input.mousePosition;
		if (invertY) {
			invertMultiplier = -1;
		}
	}
		
	void FixedUpdate()
	{
		RaycastShit ();


		if (!firstPerson)
		{
			Vector3 mouseMoveDelta = Input.mousePosition - previousMousePosition;

			//cameraNull.transform.Rotate (0, mouseMoveDelta.x*cameraSensitivity, 0);		//mouseMoveDelta.y*cameraSensitivity*invertMultiplier
			cameraNull.transform.RotateAround(transform.position, Vector3.up, mouseMoveDelta.x*cameraSensitivity);
			cameraNull.transform.RotateAround(transform.position, Vector3.right, mouseMoveDelta.y*cameraSensitivity);
			//
			//		if (Input.mousePosition.x > previousMousePosition.x) {
			//			cameraNull.transform.Rotate (0, 0, 1*cameraSensitivity);
			//		} else if (Input.mousePosition.x < previousMousePosition.x) {
			//			cameraNull.transform.Rotate (0, 0, -1*cameraSensitivity);
			//		}

			if (Input.mouseScrollDelta != null) {
				print ("scrollesd");
				camera.transform.Translate (Vector3.forward * Time.deltaTime * Input.mouseScrollDelta.y*5);
			}


			previousMousePosition = Input.mousePosition;
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("TeleportPoint") == true || other.gameObject.isStatic == true) 
		{
			return;
		}

		if (other.CompareTag ("Pickup") == true) 
		{
			//inv.PickupItem (other.gameObject);
		}

		//thing = other.gameObject;
	}

	void RaycastShit()
	{
		RaycastHit hit;

		if (firstPerson == true) 
		{
			Vector3 dir = camera.transform.forward;

			if (Physics.Raycast (camera.transform.position, dir, out hit)) 
			{
				//CheckTeleportPointSelection (hit);
				HandleRaycast (hit);
			}
		} 
		else  // Not first person mode
		{
			Ray sptRay = camera.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (sptRay, out hit)) 
			{
				HandleRaycast (hit);
			}
		}
	}

	void HandleRaycast(RaycastHit hit)
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			InstantiateCurrentObjectAtHitPoint (hit);
		}

		if (Input.GetButtonDown ("Fire2")) 
		{
			RemoveObjectAtHitPoint (hit);
		}

		if (Input.GetButton ("Fire1")) 
		{
			
			//hit.transform.Rotate(0,Input.mousePosition.x/100,0);

			if (hit.rigidbody) 
			{
				hit.rigidbody.AddTorque (new Vector3 (0,100, 0));
			}
		}
	}
		
	void InstantiateCurrentObjectAtHitPoint(RaycastHit hit)
	{
		if (currentObject != null) {
			Vector3 objectHit = hit.point;
			Instantiate (currentObject, objectHit, currentObject.transform.rotation);
		}
	}

	void RemoveObjectAtHitPoint(RaycastHit hit)
	{
		if (hit.collider.gameObject.CompareTag ("TeleportPoint") == true || hit.collider.gameObject.isStatic == true) 
		{
			return;
		}

		Destroy (hit.collider.gameObject);
	}

	void CheckTeleportPointSelection(RaycastHit hit)
	{
		if (hit.collider.gameObject.CompareTag ("TeleportPoint") == true) 
		{
			transform.position = hit.transform.position;
			return;
		}
	}



}



/* How do I get rays to pass through the invisible trigger colliders?
 * 
 * 
 * 
 * 
 * 
 * 
 * What are the requirements for a basic surface hit test?
 * 
 * 		Static?
 * 		Mesh Renderer is active
 * 		Not 
 * 
 * 
 * 
 * 
 * Requirements for Deletion
 * 
 * 		Not Static
 * 		Mesh Renderer is Active
 * 		Not the player
 * 		Not an enemy or other important object?
 * 
 * 
 * 
 */







//		if (Input.GetButtonDown ("Fire1")) 
//		{
//			var mousePos = Input.mousePosition;
//			mousePos.z = 2.0f;       // we want 2m away from the camera position
//			var objectPos = camera.ScreenToWorldPoint(mousePos);
//			thing.transform.position = objectPos;
//			//Instantiate(yourObject, objectPos, Quaternion.identity);
//		}
