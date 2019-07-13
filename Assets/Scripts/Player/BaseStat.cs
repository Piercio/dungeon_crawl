using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int BaseValue { get; set; }

    public List<StatBonus> AppliedBonuses { get; }


    public BaseStat(string name, int baseValue, string description) {
    	this.Name = name;
    	this.Description = description;
    	this.BaseValue = baseValue;
    	this.AppliedBonuses = new List<StatBonus>();
    }

    public void ApplyBonus(StatBonus bonus) {
    	this.AppliedBonuses.Add(bonus);
    }

    public void RemoveBonus(StatBonus bonus) {
    	this.AppliedBonuses.Remove(bonus);
    }

    public int Value() {
    	int value = this.BaseValue;
    	this.AppliedBonuses.ForEach(it => value += it.BonusValue);
    	return value;
    }
}
