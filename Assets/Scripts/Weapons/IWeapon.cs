using System.Collections.Generic;

public interface IWeapon {
    int currentDamage { get; set; }

    void PerformAttack();
    
    void PerformSpecialAttack();
}