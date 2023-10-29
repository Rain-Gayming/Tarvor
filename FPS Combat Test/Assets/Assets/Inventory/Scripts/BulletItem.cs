using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(menuName = "Items/Bullet")]
public class BulletItem : WeaponItemInfo
{
   [BoxGroup("Bullet Info")]
   public float baseVelocity;
   [BoxGroup("Bullet Info")]
   public GameObject prefab;
}
