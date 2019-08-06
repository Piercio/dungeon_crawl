using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {

    int PerformLightAttack(Transform playerTransform);
    
    int PerformHeavyAttack(int strength, int dexterity, int inteligence);
}