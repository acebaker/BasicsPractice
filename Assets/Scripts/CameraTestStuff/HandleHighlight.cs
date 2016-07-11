using UnityEngine;
using System.Collections;

public class HandleHighlight : MonoBehaviour {

	public Material originalMat;
	public Material currentMat;

	void Awake () {
		originalMat = GetComponent<Renderer> ().material;
		currentMat = originalMat;
	}

	public void ChangeMaterial(Material newMaterial)
	{
		currentMat = newMaterial;
		GetComponent<Renderer> ().material = currentMat;
	}
}
