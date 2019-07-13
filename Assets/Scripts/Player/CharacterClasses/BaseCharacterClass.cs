using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass {
	public string DispalyName;
	public string Description;

	public int StartingStrength;
	public int StartingDexterity;
	public int StartingVitality;
	public int StartingEndurance;
	public int StartingInteligence;
	public int StartingResistance;

	public BaseStat GetStrength() {
		return new BaseStat("Força", StartingStrength, "Requirements for equipment. Increases damage on weapons with STR scaling");
	}

	public BaseStat GetDexterity() {
		return new BaseStat("Dextreza", StartingDexterity, "Requirements for equipment. Increases damage on weapons with DEX scaling");
	}

	public BaseStat GetVitality() {
		return new BaseStat("Vitalidade", StartingVitality, "Max HP UP");
	}

	public BaseStat GetEndurance() {
		return new BaseStat("Vigor", StartingEndurance, "Max Stamina UP. Equip Burden UP");
	}

	public BaseStat GetInteligence() {
		return new BaseStat("Inteligencia", StartingInteligence, "Requirements for equipment and sorceries. Increases damage on weapons with INT scaling. Magic Adjustment UP");
	}

	public BaseStat GetResistance() {
		return new BaseStat("Resistencia", StartingResistance, "Physical Defense UP. Fire Defense UP. Poison Resist UP. Bleed Resist UP");
	}
}
