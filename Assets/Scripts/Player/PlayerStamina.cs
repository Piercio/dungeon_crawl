using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

    public int startingStamina = 75;
    public float currentStamina;
    public Slider staminaSlider;

    private bool isAttacking = false;
    private float attackDuration;
    private float attackSpeed = 1.0f;

    public float regeneration = 17.0f;

    // Start is called before the first frame update
    void Awake() {
    	currentStamina = startingStamina;
        InvokeRepeating("Regenerate", 0.0f, 1.0f / regeneration);
    }

    // Update is called once per frame
    void Update() {
    	if (isAttacking) {
    		attackDuration -= Time.deltaTime;
			if (attackDuration < 0) 
				isAttacking = false;
    	}
    }

    public void UseStamina(int amount) {
    	if (!isAttacking) {
    		isAttacking = true;
    		attackDuration = attackSpeed;
        	currentStamina -= amount;
        	staminaSlider.value = currentStamina;
    	}
	}

	public bool CanAttack() {
		return !isAttacking && currentStamina > 27;
	}

	 void Regenerate() {
     	if (!isAttacking && currentStamina < startingStamina)
              currentStamina += 1.0f;
              staminaSlider.value = currentStamina;
 	}
}
