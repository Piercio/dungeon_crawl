using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour, IWeapon {
   
	private Animator animator;
	public int baseDamage;
	public int level;

    int lightAttackStamina { get; set; }
    int heavyAttackStamina { get; set; }

	void Start() {
		animator = GetComponent<Animator>();
		
		lightAttackStamina = 27;
		heavyAttackStamina = 45;
	}

	public void FillStatsFromItem(Item weaponItem) {

	}

	public int PerformLightAttack(int strength, int dexterity, int inteligence) {
		animator.SetTrigger("LightAttack");
		Debug.Log(this.name + " Light Attack!");
		return lightAttackStamina;
    }

    public int PerformHeavyAttack(int strength, int dexterity, int inteligence) {
		// animator.SetTrigger("HeavyAttack");
    	Debug.Log(this.name + " Heavy Attack!");
    	return heavyAttackStamina;
     }

}
