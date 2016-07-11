using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public GameObject[] items;
	public int currentObject = 0;

	InteractionScript interactions;

	void Start () {
		interactions = GetComponent<InteractionScript> ();
		//items.Length = 1;
		items.SetValue(null, 0);
	}

	void Update () {
		CheckInput ();
	}

	public void PickupItem(GameObject item) {
		items.SetValue(item,items.Length);
	}


	public void SetItem(int objectIndex) {
		interactions.currentObject = items [objectIndex];
	}



	void NextItem() {

	}

	void PreviousItem() {

	}

	void CheckInput() {
		if (Input.GetKeyDown ("1") && items.Length > 1) {
			currentObject = 1;
			SetItem (currentObject);
		}
		if (Input.GetKeyDown ("2") && items.Length > 2) {
			currentObject = 2;
			SetItem (currentObject);
		}
		if (Input.GetKeyDown ("3") && items.Length > 3) {
			currentObject = 3;
			SetItem (currentObject);
		}
		if (Input.GetKeyDown ("4") && items.Length > 4) {
			currentObject = 4;
			SetItem (currentObject);
		}
		if (Input.GetKeyDown ("0") && items.Length > 0) {
			currentObject = 0;
			SetItem (currentObject);
		}
	}

}
