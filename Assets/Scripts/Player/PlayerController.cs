using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to manage all player keyboard input
public class PlayerController : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerStamina playerStamina;
    private CharacterStats characterStats;
    public GameObject rightHand;
    public GameObject rightHandSlot;
    private IWeapon rightHandWeapon;

	// Use this for initialization
	void Awake () {
        playerMovement = GetComponent<PlayerMovement>();
        playerStamina = GetComponent<PlayerStamina>();
        characterStats = GetComponent<CharacterStats>();
	}

    public void EquipWeapon(Item weaponToEquip) {
        Debug.Log("Equiping weapon!");
        if (rightHandSlot != null) {
            // Destroy(rightHand.transform.GetChild(0).gameObject);
            Destroy(rightHandSlot);
            Debug.Log("Removed item: " + rightHandSlot);
        }

        rightHandSlot = (GameObject) Instantiate(
            Resources.Load<GameObject>("Weapons/" + weaponToEquip.slug),
            rightHand.transform.position,
            rightHand.transform.rotation
        );
        rightHandSlot.transform.SetParent(rightHand.transform);
        Debug.Log(rightHandSlot);
        
        rightHandWeapon = rightHandSlot.GetComponent<IWeapon>();
        rightHandWeapon.currentDamage = weaponToEquip.damage;
        Debug.Log(rightHandWeapon);
    }

    public void PerformWeaponAttack() {
        Debug.Log("attack action");
        rightHandWeapon.PerformAttack();
        playerStamina.UseStamina(27);
    }

	void Update () {
        if (!playerMovement.IsMoving()) {
        	// if player is not moving (return value of IsMoving is false)
            GetPlayerInput();
        }
	}

    private void GetPlayerInput() {
		// variables of horizontal moving, vertical moving and turning
        int horizontal = 0;
        int vertical = 0;
        int turning = 0;
        int attack = 0;

		// cache movement and turning values based on input axis
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));
        turning = (int)(Input.GetAxisRaw("Turning"));
        attack = (int)(Input.GetAxisRaw("Attack"));

		// limit movement and turning values so that only one value is something than zero
        if (horizontal != 0) {
            playerMovement.MovePlayer(horizontal, 0, 0);
        } else if (vertical != 0) {
            playerMovement.MovePlayer(0, vertical, 0);
        } else if (turning != 0) {
            playerMovement.MovePlayer(0, 0, turning);
        } else if (attack != 0 && playerStamina.CanAttack()) {
           this.PerformWeaponAttack();
        }
    }
}