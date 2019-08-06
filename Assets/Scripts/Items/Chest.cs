using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

	public string itemSlug;

	Animator animator;
	WeaponType item; // TODO item
	GameObject storedItem;
	bool isEmpty = false;

	void Awake() {
		this.animator = GetComponent<Animator>();
		// this.item = new Item(itemSlug);   // TODO: create Item by slug from db
		float[] levelModifiers = {1.0f, 1.2f, 1.3f};
		DamageStat physicalDamage = new DamageStat(DamageType.PHYSICAL, 35, levelModifiers, new List<StatModifier>());
		List<DamageStat> damages = new List<DamageStat>();
		damages.Add(physicalDamage);
		this.item = new WeaponType(itemSlug, 27, 45, damages);
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
		this.storedItem.GetComponent<Sword>().swordType = this.item;
        this.storedItem.transform.SetParent(this.transform);
    }

    public void Pickup(Transform playerTransform) {
    	InventoryController inventory = playerTransform.GetComponent<InventoryController>();
    	inventory.AddToBackpack(storedItem);
    	this.isEmpty = true;
    }
}
