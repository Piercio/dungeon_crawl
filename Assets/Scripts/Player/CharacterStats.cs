using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats: MonoBehaviour {
	public BaseStat Strength {get; set;}
	public BaseStat Dexterity { get; set; }
	public BaseStat Vitality { get; set; }
	public BaseStat Endurance { get; set; }
	public BaseStat Intelligence { get; set; }
	public BaseStat Resistance { get; set; }

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

	void Update() {
		//pass 
	}
}
