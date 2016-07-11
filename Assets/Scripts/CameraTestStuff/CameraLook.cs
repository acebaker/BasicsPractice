using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {

	public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.
	public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
	public float m_MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
	//[HideInInspector] public Transform[] m_Targets; // All the targets the camera needs to encompass.


	private Camera m_Camera;                        // Used for referencing the camera.
	private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
	private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
	private Vector3 m_DesiredPosition;              // The position the camera is moving towards.


	public Transform target;


	// Use this for initialization
	void Awake () {
		m_Camera = GetComponent<Camera> ();
		m_Camera.transform.LookAt (target);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//m_Camera.transform.LookAt (target);
		Look();
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

	private void Look ()
	{
		// Smoothly transition to that position.
		//transform.rotation = Vector3.SmoothDamp(transform.rotation, target., ref m_MoveVelocity, m_DampTime);

		var rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, m_DampTime);
	}
		
}