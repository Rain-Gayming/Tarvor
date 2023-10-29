using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public Limbs limb;

    public void TakeDamage(float damage)
    {
        GetComponentInParent<HealthManager>().TakeLimbDamage(damage, limb);
    }
}
