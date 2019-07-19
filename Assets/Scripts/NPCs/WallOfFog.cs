using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFog : Interactable {

	List<string> dialogueLines = new List<string>(1);

	void Awake() {
		this.dialogueLines.Add("Cross the fog wall?");
	}

	public override bool CanInteract(Transform otherTransform) {
		return this.IsFacing(otherTransform);
	}

	public override void Interact(Transform otherTransform) {
		DialogueSystem.Instance.AddNewDialogue(
			dialogueLines,
			delegate () { this.CrossFogWall(otherTransform); }
		);
	}

	public void CrossFogWall(Transform otherTransform) {
		PlayerMovement playerMovement = otherTransform.GetComponent<PlayerMovement>();
		playerMovement.ForceMovementForward(2);
	}

	private bool IsFacing(Transform otherTransform) {
        return transform.forward == -otherTransform.forward;
    }

}
