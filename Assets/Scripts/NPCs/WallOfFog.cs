using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFog : Interactable {

	List<string> dialogueLines = new List<string>(2);

	void Awake() {
		dialogueLines.Add("Cross the fog wall?");
	}

	public override void Interact(Transform playerTransform) {
		if (this.IsFacing(playerTransform)) {
			DialogueSystem.Instance.AddNewDialogue(
				dialogueLines,
				delegate () { CrossFogWall(playerTransform); }
			);
		}
	}

	public void CrossFogWall(Transform playerTransform) {
		PlayerMovement playerMovement = playerTransform.GetComponent<PlayerMovement>();
		playerMovement.ForceMovementForward(2);

		Debug.Log("Player crosses the wall of fog! ");
	}

	bool IsFacing(Transform playerTransform) {
        return transform.forward == -playerTransform.forward;
    }

}
