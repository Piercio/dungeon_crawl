using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : Interactable {

	bool isOpen = false;
	float moveTime = 3.6f;
    

	public override bool CanInteract(Transform otherTransform) {
		return !isOpen;
	}

    public override void Interact(Transform otherTransform) {
    	Vector3 newPos = transform.position + transform.up;
    	StartCoroutine(Movement(newPos));
    }

	// function to do actual movement from grid to grid
    public IEnumerator Movement (Vector3 end) {
		// unit is moving and define the distance from unit to end position
        isOpen = true;
        float remainDist = (transform.position - end).sqrMagnitude;
        float invMoveTime = 1.0f / moveTime;

        while (remainDist > float.Epsilon) {
			// define new position, move unit by time and check new distance from unit to end position
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end, invMoveTime * Time.deltaTime);
            transform.position = newPosition;
            remainDist = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }
}
