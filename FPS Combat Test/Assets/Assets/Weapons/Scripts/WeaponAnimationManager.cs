using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using Sirenix.OdinInspector;

public class WeaponAnimationManager : MonoBehaviour
{
    [BoxGroup("References")]
    public Animator anim;
    [BoxGroup("References")]
    public Transform arms;

    [BoxGroup("Animation Values")]
    public bool aiming;
    [BoxGroup("Animation Values")]
    public bool cantedAim;
    [BoxGroup("Animation Values")]
    public float reloadTime;
    [BoxGroup("Animation Values")]
    public float shootTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!aiming){
            cantedAim = false;
        }

        anim.SetBool("Aiming", aiming);
        anim.SetBool("CantedAim", cantedAim);
    }

    public void Reload()
    {
        StartCoroutine(ReloadCo());
    }

    public void AimChange()
    {
        aiming = !aiming;
    }

    public void CantedChanged()
    {
        cantedAim = !cantedAim;
    }

    public IEnumerator ReloadCo()
    {
        anim.SetBool("HasReloadStarted", true);
        anim.SetLayerWeight(1, 1);
        yield return new WaitForSeconds(reloadTime);
        anim.SetLayerWeight(1, 0);
        anim.SetBool("HasReloadStarted", false);
    }

    public IEnumerator ShootCo()
    {
        arms.position = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -1f), shootTime);
        yield return new WaitForSeconds(shootTime);
        arms.position = Vector3.Lerp(new Vector3(0, 0, -1f), new Vector3(0, 0, 0), shootTime);
    }
}
