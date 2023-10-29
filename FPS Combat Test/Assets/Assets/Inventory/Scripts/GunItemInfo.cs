using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(menuName = "Items/Gun")]
public class GunItemInfo : WeaponItemInfo
{
    [BoxGroup("Gun Info")]
    public int maxAmmo;
    [BoxGroup("Gun Info")]
    public float reloadSpeed;
    
    [BoxGroup("Recoil")]
    [BoxGroup("Recoil/Non Aim")]
    public float recoilX;
    [BoxGroup("Recoil/Non Aim")]
    public float recoilY;
    [BoxGroup("Recoil/Non Aim")]
    public float recoilZ;
    [BoxGroup("Recoil/Aiming")]
    public float aimRecoilX;
    [BoxGroup("Recoil/Aiming")]
    public float aimRecoilY;
    [BoxGroup("Recoil/Aiming")]
    public float aimRecoilZ;
}
