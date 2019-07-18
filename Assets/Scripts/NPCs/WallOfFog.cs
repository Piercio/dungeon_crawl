using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFog : Interactable {

	List<string> dialogueLines = new List<string>(1);

	void Awake() {
		this.dialogueLines.Add("Cross the fog wall?");
	}

	public override bool CanInteract(Transform playerTransform) {
		return this.IsFacing(playerTransform);
	}

	public override void Interact(Transform playerTransform) {
		DialogueSystem.Instance.AddNewDialogue(
			dialogueLines,
			delegate () { this.CrossFogWall(playerTransform); }
		);
	}

	public void CrossFogWall(Transform playerTransform) {
		PlayerMovement playerMovement = playerTransform.GetComponent<PlayerMovement>();
		playerMovement.ForceMovementForward(2);
	}

	private bool IsFacing(Transform playerTransform) {
        return this.transform.forward == -playerTransform.forward;
    }

}
