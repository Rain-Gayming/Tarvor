using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class GunManager : MonoBehaviour
{
    [BoxGroup("References")]
    public WeaponAnimationManager animationManager;
    [BoxGroup("References")]
    public InputManager inputManager;
    [BoxGroup("References")]
    public WeaponSway weaponSway;
    [BoxGroup("References")]
    public WeaponRecoil weaponRecoil;
    [BoxGroup("References/Gun Info")]
    public GunItemInfo gunInfo;
    [BoxGroup("References/Gun Info")]
    public BulletItem bulletInfo;
    
    [BoxGroup("Shooting")]
    public bool canShoot;
    [BoxGroup("Shooting")]
    public Transform barrel;
    [BoxGroup("Shooting")]
    public int currentAmmo;
    
    public void Start()
    {
        currentAmmo = gunInfo.maxAmmo;
        inputManager = GetComponentInParent<InputManager>();
    }

    public void Update()
    {
        if(inputManager.shoot && currentAmmo > 0 && canShoot){
            inputManager.shoot = false;
            StartCoroutine(animationManager.ShootCo());
            Shoot();
        }

        if(inputManager.reload){
            inputManager.reload = false;
            StartCoroutine(ReloadCo());
        }

        if(inputManager.aim){
            inputManager.aim = false;
            weaponRecoil.aiming = !weaponRecoil.aiming;
            weaponSway.aiming = !weaponSway.aiming;
            animationManager.AimChange();
        }
        if(inputManager.canted){
            inputManager.canted = false;
            animationManager.CantedChanged();
        }
    }

    public IEnumerator ReloadCo()
    {
        canShoot = false;
        animationManager.Reload();
        yield return new WaitForSeconds(gunInfo.reloadSpeed);
        currentAmmo = gunInfo.maxAmmo;
        canShoot = true;
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bulletInfo.prefab);

        newBullet.GetComponent<Bullet>().damage = bulletInfo.damage;
        newBullet.GetComponent<Bullet>().velocity = bulletInfo.baseVelocity;
        currentAmmo--;

        newBullet.transform.position = barrel.position;
        newBullet.transform.Rotate(barrel.transform.eulerAngles);
    
        weaponRecoil.RecoilFire();
    }
}
