using UnityEngine;
using System.Collections;

public class CharacterSelectManager : MonoBehaviour {

	public Transform charactersNull;
	public GameObject currentTarget;
	public GameObject previousTarget;
	public Material highlightMat;
	public Material selectedMat;

	public Camera cam;

	private Transform[] characters;

	void Awake () {
		characters = new Transform[charactersNull.childCount];

		for (int i = 0; i < characters.Length; ++i) {
			print ("For loop: " + charactersNull.GetChild (i));
			characters.SetValue (charactersNull.GetChild (i), i);
		}
	}

	public void ResetItemMaterial(GameObject itemToReset)		// Could add the material as a field as well
	{
		HandleHighlight hh = itemToReset.GetComponent<HandleHighlight> ();
		if (hh != null) {
			hh.ChangeMaterial (hh.originalMat);
		}
	}

	public void SetItemMaterial(GameObject itemToSet, Material newMaterial)
	{
		HandleHighlight hh = itemToSet.GetComponent<HandleHighlight> ();
		if (hh != null) {
			hh.ChangeMaterial (newMaterial);
		}
	}

	public void SelectItem(GameObject itemToSelect)
	{
		DeselectItem (currentTarget);
		previousTarget = currentTarget;
		currentTarget = itemToSelect;
		SetItemMaterial (currentTarget, selectedMat);
		cam.GetComponent<CameraLook> ().SetTarget (currentTarget.transform);
	}

	public void DeselectItem(GameObject itemToReset)
	{
		if (itemToReset != null) {
			ResetItemMaterial (itemToReset);
		}
	}

	public void ShowHoverState(GameObject itemToHover)
	{
		SetItemMaterial (itemToHover, highlightMat);
	}

}
