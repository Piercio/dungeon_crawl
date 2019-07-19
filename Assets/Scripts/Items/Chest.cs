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
		this.animator = GetComponent<Animator>();
		this.item = new Item(itemSlug);   // TODO: create Item by slug from db
	}

	public override bool CanInteract(Transform playerTransform) {
		return !isEmpty;
	}

	public override void Interact(Transform playerTransform) {
		if (this.storedItem == null) {
			List<string> dialogueLines = new List<string>(1);
			dialogueLines.Add("You found a " + item.slug);

			this.Open();

			DialogueSystem.Instance.AddNewDialogue(
				dialogueLines,
				delegate() { this.Pickup(playerTransform); }
			);
		}
	}

	public void Open() {
		this.animator.SetTrigger("OpenChest");
		this.createItem();
	}

	private void createItem() {
		this.storedItem = (GameObject) Instantiate(Resources.Load<GameObject>(this.item.slug));
        this.storedItem.transform.SetParent(this.transform);
    }

    public void Pickup(Transform playerTransform) {
    	InventoryController inventory = playerTransform.GetComponent<InventoryController>();
    	inventory.AddToBackpack(storedItem);
    	this.isEmpty = true;
    }
}
