using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats: MonoBehaviour {
	BaseStat Strength {get; set;}
	BaseStat Dexterity { get; set; }
	BaseStat Vitality { get; set; }
	BaseStat Endurance { get; set; }
	BaseStat Intelligence { get; set; }
	BaseStat Resistance { get; set; }

	public BaseCharacterClass CharacterClass { get; set; }

	void Awake() {
		CharacterClass = new Soldier();
		this.Strength = this.CharacterClass.GetStrength();
		this.Dexterity = this.CharacterClass.GetDexterity();
		this.Vitality =  this.CharacterClass.GetVitality();
		this.Endurance = this.CharacterClass.GetEndurance();
		this.Intelligence = this.CharacterClass.GetInteligence();
		this.Resistance = this.CharacterClass.GetResistance();
	}

}
