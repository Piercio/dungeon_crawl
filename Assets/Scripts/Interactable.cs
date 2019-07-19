using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour {

	public virtual bool CanInteract(Transform otherTransform) {
		return true;
	}

    public virtual void Interact(Transform otherTransform) {
		Debug.Log("Interated with " + otherTransform);      
    }

}
