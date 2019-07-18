using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingUnit {
	
	public void MovePlayer(int hor, int ver, int rot) {
		if (enabled) {
			DialogueSystem.Instance.CancelDialogue();
			Vector3 endPos = Vector3.zero;

			if (ver != 0) {
				endPos = transform.position + transform.forward * ver;
				base.StartMove(endPos, true);
			} else if (hor != 0) {
				endPos = transform.position + transform.right * hor;
				base.StartMove(endPos, false);
			} else if (rot != 0) {
				base.StartRotation(rot);
			}
		}
	}

	protected override void CannotMove<T>(T component) {
		Debug.Log("blocked!");
	}

}
