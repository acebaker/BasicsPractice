using UnityEngine;
using System.Collections;

public class RaycastTargetCheck : MonoBehaviour {

	public CharacterSelectManager charSelectManager;

	private Camera m_Camera;
	private GameObject lastHitObject;

	void Awake()
	{
		m_Camera = GetComponent<Camera> ();
	}

	void FixedUpdate()
	{
		RaycastShit ();
	}

	void RaycastShit()
	{
		RaycastHit hit;

		Ray sptRay = m_Camera.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (sptRay, out hit)) {
			HandleRaycast (hit);
		} else if (lastHitObject != null && lastHitObject != charSelectManager.currentTarget) {		// Reset object if no longer raycasthit
			charSelectManager.ResetItemMaterial(lastHitObject);
		}
	}

	void HandleRaycast(RaycastHit hit)
	{
		// If something else was hit by the raycast before this, change its material back to its default
		if (lastHitObject != null && lastHitObject != hit.collider.gameObject && lastHitObject != charSelectManager.currentTarget) {
			charSelectManager.ResetItemMaterial(lastHitObject);
		}

		lastHitObject = hit.collider.gameObject;	// Set the currently hit object as the last hit

		// If the currently hit object isn't the current target, show the hover state
		if (hit.collider.gameObject != charSelectManager.currentTarget) {
			charSelectManager.ShowHoverState (lastHitObject);
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			charSelectManager.SelectItem (lastHitObject);
		}

	}

}



// 		if (Input.GetButtonDown ("Fire1")) 
//		{
//			charSelectManager.SelectItem (lastHitObject);
//
//			if (charSelectManager.currentTarget != null && charSelectManager.currentTarget != hit.collider.gameObject) {
//				charSelectManager.ResetItemMaterial (charSelectManager.currentTarget);
//			}
//			charSelectManager.previousTarget = charSelectManager.currentTarget; // not sure i need this for anything
//			charSelectManager.currentTarget = hit.collider.gameObject;
//
//			//Transform newTarget = hit.collider.gameObject.transform;
//			GetComponent<CameraLook> ().SetTarget (charSelectManager.currentTarget.transform);
//			HandleHighlight hh3 = charSelectManager.currentTarget.GetComponent<HandleHighlight> ();
//			if (hh3 != null) {
//				hh3.ChangeMaterial (charSelectManager.selectedMat);
//			}
//		}
