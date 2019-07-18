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

	Item sword;
	Dictionary<Item, GameObject> items;


    // Start is called before the first frame update
    void Start() {
    	playerController = GetComponent<PlayerController>();
    	sword = new Item("Sword");
    	items = new Dictionary<Item, GameObject>();
    }

    // Update is called once per frame
    void Update() {
    	GameObject item;
        if (Input.GetKeyDown(KeyCode.V)) {
        	if (items.TryGetValue(sword, out item)) {
        		this.ToggleEquipWeapon(item);
        	} else {
        		Debug.Log("No sword to equip!");
        	}
        } else if (Input.GetKeyDown(KeyCode.C)) {
        	if (!items.TryGetValue(sword, out item)) {
        		this.CreateWeapon(sword);
        	} else {
        		this.DestroyWeapon(sword);
        	}
        }
    }

    public void CreateWeapon(Item weaponToCreate) {
    	GameObject weapon = (GameObject) Instantiate(Resources.Load<GameObject>("Weapons/" + weaponToCreate.slug));
        weapon.transform.SetParent(backPack.transform);
        items.Add(weaponToCreate, weapon);

        Debug.Log("Creating weapon: " + weapon);
    }

    public void DestroyWeapon(Item weaponToDestroy) {
    	Destroy(items[weaponToDestroy]);
    	items.Remove(weaponToDestroy);

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
