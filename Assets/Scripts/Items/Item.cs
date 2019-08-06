using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public string slug { get; set; }

	public Item(string slug) {
		this.slug = slug;
	}

	// DamageStat{
	// 	damageType { physical, fire, cold, acid, lightning, buildUp_}
	// 	baseDamage { int }
	// 	levelModifier { % gain on baseDamage per level }
	// 	StatModifilers [{ 
	// 		stat { BaseStat }
	// 		levelModifier { % gain based on stat per level }
	// 		classifier { E-A..S based on range of levelModifier}
	// 	 }]
	// }
}
