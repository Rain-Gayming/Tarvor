using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class HealthManager : MonoBehaviour
{
    public bool shouldDestroy;
    [BoxGroup("Conditions")]
    [BoxGroup("Conditions/Light Bleed")]
    public float lightBleedDamage;
    [BoxGroup("Conditions/Light Bleed")]
    public float lightBleedTime;
    [BoxGroup("Conditions/Light Bleed")]
    public float lightBleedTimer;
    
    [BoxGroup("Conditions/Heavy Bleed")]
    public float heavyBleedDamage;
    [BoxGroup("Conditions/Heavy Bleed")]
    public float heavyBleedTime;
    [BoxGroup("Conditions/Heavy Bleed")]
    public float heavyBleedTimer;

    [BoxGroup("Limbs")]
    public List<LimbHealth> limbs;
    [BoxGroup("Limbs")]
    public float totalLimbHealth;
    
    public void Start()
    {
        for (int i = 0; i < limbs.Count; i++)
        {
            totalLimbHealth += limbs[i].health;
        }
    }

    private void Update()
    {
        lightBleedTimer -= Time.deltaTime;
        heavyBleedTimer -= Time.deltaTime;

        if(lightBleedTimer <= 0){
            for (int i = 0; i < limbs.Count; i++)
            {
                if(limbs[i].conditions.Contains(Conditions.lightBleed)){
                    limbs[i].health -= Mathf.RoundToInt(lightBleedDamage);
                }
            } 

            lightBleedTimer = lightBleedTime;
        }   
        if(heavyBleedTimer <= 0){
            for (int i = 0; i < limbs.Count; i++)
            {
                if(limbs[i].conditions.Contains(Conditions.heavyBleed)){
                    limbs[i].health -= Mathf.RoundToInt(heavyBleedDamage);
                }
            } 
            heavyBleedTimer = heavyBleedTime;
        }   
    }

    public void TakeLimbDamage(float damage, Limbs limb)
    {
        for (int i = 0; i < limbs.Count; i++)
        {
            if(limbs[i].limb == limb){
                limbs[i].health -= damage;
                if(limbs[i].health <= 0){
                    limbs[i].health = 0;
                    limbs[i].dead = true;
                    print(limbs[i].limb + " is dead");
                }
                if(limbs[i].health <= limbs[i].health % 75 && limbs[i].health > limbs[i].health % 40){
                    if(!limbs[i].conditions.Contains(Conditions.lightBleed)){
                        limbs[i].conditions.Add(Conditions.lightBleed);
                        limbs[i].conditions.Add(Conditions.pain);
                    }
                }
                if(limbs[i].health <= limbs[i].health % 50){
                    if(!limbs[i].conditions.Contains(Conditions.broken)){
                        limbs[i].conditions.Add(Conditions.broken);
                    }
                }
                if(limbs[i].health <= limbs[i].health % 40 && !limbs[i].conditions.Contains(Conditions.heavyBleed)){
                    limbs[i].conditions.Remove(Conditions.lightBleed);
                    limbs[i].conditions.Add(Conditions.heavyBleed);
                }
            }

            if(limbs[i].limb == Limbs.Head){
                if(limbs[i].health <= 0){
                    Die();
                }
            }
            if(limbs[i].limb == Limbs.Chest){
                if(limbs[i].health <= 0){
                    Die();
                }
            }
        }

        int limbsDead = 0;

        for (int i = 0; i < limbs.Count; i++)
        {
            if(limbs[i].dead){
                limbsDead++;
            }
        }

        if(limbsDead >= 3){
            Die();
        }
    }

    public virtual void Die()
    {
        if(shouldDestroy){
            Destroy(gameObject);
        }
    }

}

[System.Serializable]
public class LimbHealth
{
    public Limbs limb;
    public List<Conditions> conditions;
    public float health;
    public bool dead;
}