using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float ZombieHealth = 100f;
    public Animator g_ZombieAnimator;


    void Update()
    {
        if (ZombieHealth <= 0f)
        {
            Invoke("ZombieDeath", 1f);
        }
    }

    public void ZombieDeath()
    {
        this.gameObject.SetActive(false);
    }


    public void EnemyDamage(float damage)
    {
       ZombieHealth -= damage;

        if (ZombieHealth <= 0f)
        {
            ZombiePooling ZombieSpawnScript = GetComponent<ZombiePooling>();
            g_ZombieAnimator.SetBool("die", true);
          
        }
    }
}
