using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingUnit {

	PlayerHealth playerHealth;

	// Use this for initialization
    protected override void Awake () {
    	base.Awake();
    	playerHealth = GetComponent<PlayerHealth>();
    }
	
	public void MovePlayer(int hor, int ver, int rot) {
		if (enabled) {
			Vector3 endPos = Vector3.zero;

			if (ver != 0) {
				endPos = transform.position + transform.forward * ver;
				base.StartMove(endPos);
				playerHealth.TakeDamage(1);
			} else if (hor != 0) {
				endPos = transform.position + transform.right * hor;
				base.StartMove(endPos);
			} else if (rot != 0) {
				base.StartRotation(rot);
			}
		}
	}

	protected override void CannotMove<T>(T component) {
		Debug.Log("blocked!");
	}
}
