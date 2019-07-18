using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

	public string itemSlug;

	Animator animator;
	Item item;
	GameObject storedItem;
	bool isEmpty = false;

	void Awake() {
		animator = GetComponent<Animator>();
		item = new Item(itemSlug);   // TODO: create Item by slug from db
	}

	public override void Interact(Transform playerTransform) {
		if (isEmpty) {
			return;
		}		

		List<string> dialogueLines = new List<string>(1);

		if (storedItem == null) {
			dialogueLines.Add("Open this chest?");
			DialogueSystem.Instance.AddNewDialogue(
				dialogueLines,
				delegate() { Open(); }
			);
		} else {
			dialogueLines.Add("Pickup " + item.slug + "?");
			DialogueSystem.Instance.AddNewDialogue(
				dialogueLines,
				delegate() { Pickup(playerTransform); }
			);
		}
	}

	public void Open() {
		animator.SetTrigger("OpenChest");
		createItem();
	}

	void createItem(){
		storedItem = (GameObject) Instantiate(Resources.Load<GameObject>(item.slug));
        storedItem.transform.SetParent(this.transform);
    }

    public void Pickup(Transform playerTransform) {
    	InventoryController inventory = playerTransform.gameObject.GetComponent<InventoryController>();
    	inventory.AddToBackpack(storedItem);
    }
}
