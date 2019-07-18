using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour {

	public virtual bool CanInteract(Transform transform) {
		return true;

	}

    public virtual void Interact(Transform transform) {
		Debug.Log("Interated with " + transform);      
    }

}
