using System.Collections.Generic;

public interface IWeapon {

	void FillStatsFromItem(Item weaponItem);

    int PerformLightAttack(int strength, int dexterity, int inteligence);
    
    int PerformHeavyAttack(int strength, int dexterity, int inteligence);
}