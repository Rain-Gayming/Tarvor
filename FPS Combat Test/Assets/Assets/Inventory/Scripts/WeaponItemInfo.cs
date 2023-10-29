using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class WeaponItemInfo : DurableItemInfo
{
    [BoxGroup("Weapon Info")]
    public float attackSpeed;
    [BoxGroup("Weapon Info")]
    public int damage;
}
