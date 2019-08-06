using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour {

	[Range(0, 360)]
	public int speed = 50;

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
