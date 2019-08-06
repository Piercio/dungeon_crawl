using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string slug;
	public int maxHealth;
	public int currentHealth;

    void Awake() {
    	this.currentHealth = this.maxHealth;
    }

    void Update() {
        if (currentHealth <= 0) {
        	Destroy(this.gameObject);
        }
    }

    public void receiveDamage(int amount, DamageType type) {
        Debug.Log(this.slug + " was damaged by " + amount + "(" + type + ")");
    	if (amount > this.currentHealth) {
    		amount = this.currentHealth;
    	}
    	this.currentHealth -= amount;
    }

}
