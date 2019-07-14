using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public string slug { get; set; }
	public int damage { get; set; }
	public List<BaseStat> statBonuses { get; set; }

	public Item(string slug, int damage, List<BaseStat> statBonuses) {
		this.slug = slug;
		this.damage = damage;
		this.statBonuses = statBonuses;
	}
}
