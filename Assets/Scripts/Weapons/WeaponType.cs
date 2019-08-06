using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType {  // Super Item

	public string slug;
	public List<DamageStat> damageStats { get; set; }
	public int level { get; set; }
	public int lightAttackStamina { get; set; }
    public int heavyAttackStamina { get; set; }

    public WeaponType(string slug, int lightAttackStamina, int heavyAttackStamina, List<DamageStat> damageStats) {
    	this.slug = slug;
    	this.level = 1;
    	this.lightAttackStamina = lightAttackStamina;
    	this.heavyAttackStamina = heavyAttackStamina;
    	this.damageStats = damageStats;
    }

	public void LevelUp() {
		if (level < 10) level++;
	}

	public Dictionary<DamageType, int> GetDamageByType() {
		Dictionary<DamageType, int> damageByType = new Dictionary<DamageType, int>();
		this.damageStats.ForEach(it => damageByType.Add(it.type, it.GetDamage(this.level)));

		return damageByType;		
	}

	public int GetPhysicalDamage() {
		return this.GetDamageByType()[DamageType.PHYSICAL];
	}

}
