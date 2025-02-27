﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : Interactable {

	List<string> dialogueLines = new List<string>(2);
	bool firstTime = true;

	void Start() {
		dialogueLines.Add("Pray at the Altar?");
		dialogueLines.Add("Everytime you pray the state of the world resets. Some enemies and bosses will not respawn");
	}

	public override void Interact(Transform transform) {
		DialogueSystem.Instance.AddNewDialogue(
			dialogueLines,
			delegate() { StartPraying(transform); }
		);
	}

	public void StartPraying(Transform transform) {
		if (firstTime) {
			dialogueLines.RemoveAt(1);
			firstTime = false;
		}
		Debug.Log("Player is praying! " + transform);
	}
}
