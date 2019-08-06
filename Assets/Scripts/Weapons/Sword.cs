using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour, IWeapon {
   
	private Animator animator;

	[SerializeField] public WeaponType swordType;

	void Start() {
		animator = GetComponent<Animator>();
		// lightAttackStamina = 27;
		// heavyAttackStamina = 45;
	}

	Enemy CheckHit(Transform playerTransform) {
		RaycastHit target;
    	Vector3 playerPositin = playerTransform.position;
    	Vector3 enemyPosition = playerPositin + playerTransform.forward;

    	if (Physics.Linecast(playerPositin, enemyPosition, out target)) {
    		return target.transform.GetComponent<Enemy>();
    	}
		return null;
	}

	void DamageTarget(Enemy enemy) {
		enemy.receiveDamage(swordType.GetPhysicalDamage(), DamageType.PHYSICAL);
		// Dictionary<DamageType, int> damages = swordType.GetDamageByType();
		// damages.Values.ForEach(it => enemy.receiveDamage(it.Value, it.Key));
	}

	public int PerformLightAttack(Transform playerTransform) {
		Debug.Log(this.name + " Light Attack!");
		animator.SetTrigger("LightAttack");

    	Enemy enemy = CheckHit(playerTransform);
		if (enemy != null) {
			Debug.Log("It HITS!!!");
			this.DamageTarget(enemy);
		} else {
			Debug.Log("Miss...");
		}
		return swordType.lightAttackStamina;
    }

    public int PerformHeavyAttack(int strength, int dexterity, int inteligence) {
		// animator.SetTrigger("HeavyAttack");
    	Debug.Log(this.name + " Heavy Attack!");
    	return swordType.heavyAttackStamina;
    }

}
