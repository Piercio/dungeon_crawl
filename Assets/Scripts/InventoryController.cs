using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	public PlayerController playerController;
	public Item sword;

    // Start is called before the first frame update
    void Start() {
    	playerController = GetComponent<PlayerController>();
    	sword = new Item("Sword", 15, new List<BaseStat>());
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.V)) {
        	playerController.EquipWeapon(sword);
        }
    }
}
