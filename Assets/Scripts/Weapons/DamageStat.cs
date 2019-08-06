using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStat {
	public DamageType type { get; set; }
	public int baseDamage { get; set; }
	public float[] levelModifiers { get; set; }
	public List<StatModifier> statModifiers { get; set; }

	public DamageStat(DamageType type, int baseDamage, float[] levelModifiers, List<StatModifier> statModifiers) {
		this.type = type;
		this.baseDamage = baseDamage;
		this.levelModifiers = levelModifiers;
		this.statModifiers = statModifiers;
	}

	public int GetDamage(int level) {
		int damage = baseDamage;
		damage = (int) (damage * levelModifiers[level - 1]);

		this.statModifiers.ForEach(it => damage += it.GetBonus(level));

		return damage;
	}
}

public class StatModifier {
	BaseStat stat { get; set; }
	int minValue { get; set; }
	float modifier { get; set; }  // from 0.1 to 2.5
	float levelModifier { get; set; }

	public string GetClassifier() {
		if (this.modifier > 2.0f) {
			return "S";
		} else if (this.modifier > 1.5f) {
			return "A";
		} else if (this.modifier > 1.50f) {
			return "B";
		} else if (this.modifier > 0.75f) {
			return "C";
		} else if (this.modifier > 0.5f) {
			return "D";
		} else {
			return "E";
		}
	}

	public int GetBonus(int level) {
		int baseValue = this.stat.Value();
		if (baseValue < minValue) {
			return -50;  // give a fair penalty
		}

		return (int) (baseValue * (modifier + (levelModifier * level)));
	}
}

public enum DamageType {
	PHYSICAL,
	FIRE,
	COLD,
	ACID,
	LIGHTINING,
	BUILD_UP_POISON,
	BUILD_UP_FROST,
	BUILD_UP_STONE,
}
