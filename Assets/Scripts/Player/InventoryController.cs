using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	private PlayerController playerController;

	public GameObject rightHandSlot;
	public GameObject leftHandSlot;
	public GameObject headSlot;
	public GameObject bodySlot;
	public GameObject legsSlot;
	public GameObject rightRingSlot;
	public GameObject leftRingSlot;

	public GameObject backPack;

	Dictionary<string, GameObject> items;


    // Start is called before the first frame update
    void Start() {
    	playerController = GetComponent<PlayerController>();
    	items = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update() {
    	GameObject item;
        if (Input.GetKeyDown(KeyCode.V)) {
        	if (items.TryGetValue("sword", out item)) {
        		this.ToggleEquipWeapon(item);
        	} else {
        		Debug.Log("No sword to equip!");
        	}
        }
    }

    public void AddToBackpack(GameObject itemToStore) {
        itemToStore.transform.SetParent(backPack.transform);
        items.Add("sword", itemToStore);

        Debug.Log("Item added to the players backPack: " + itemToStore);
    }

    public void DestroyWeapon(Item weaponToDestroy) {
    	Destroy(items["sword"]);
    	items.Remove("sword");

    	Debug.Log("Sword destroyed!");
    }

    public void ToggleEquipWeapon(GameObject weaponToEquip) {
    	if (playerController.equipedWeapon == null) {
    		weaponToEquip.transform.SetParent(rightHandSlot.transform, false);	
	        playerController.equipedWeapon = weaponToEquip.GetComponent<IWeapon>();

    	    Debug.Log("Equiping weapon " + weaponToEquip.transform.position);
	    } else {
	    	weaponToEquip.transform.SetParent(backPack.transform, false);
	    	playerController.equipedWeapon = null;

	    	Debug.Log("Unequiping weapon " + weaponToEquip.transform.position);
	    }
    }
}
