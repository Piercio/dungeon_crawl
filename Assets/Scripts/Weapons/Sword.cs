using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour, IWeapon {
   
	private Animator animator;
	public int currentDamage { get; set; }

	void Start() {
		animator = GetComponent<Animator>();
	}

	public void PerformAttack() {
		animator.SetTrigger("BaseAttack");
		Debug.Log("Damage: " + currentDamage);
    }

    public void PerformSpecialAttack() {
    	Debug.Log(this.name + " SPECIAL attack!");
    }
}
