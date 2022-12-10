using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNaviAI : MonoBehaviour
{
    Transform PlayerObj;
    public NavMeshAgent ZombieAgent;
    public float ChaseDistance = 2f;
    public Animator g_ZombieAnimator;
   
    

    PlayerHealth PlayerHealthScript;
    // Start is called before the first frame update
    void Start()
    {
         
         PlayerObj = GameObject.Find("FPSplayer").transform;
         PlayerHealthScript = PlayerObj.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        float Distance = Vector3.Distance(transform.position,PlayerObj.position);

        if (Distance < ChaseDistance)
        {
            if (Math.Round(Time.time) % 2 == 0)
            {
                PlayerHealthScript.TakeDamage(0.1f);
            }
            g_ZombieAnimator.SetBool("run", false);
            g_ZombieAnimator.SetBool("attack", true);
        }
        else
        {
            g_ZombieAnimator.SetBool("run", true);
            g_ZombieAnimator.SetBool("attack", false);
            ZombieAgent.SetDestination(PlayerObj.transform.position);
        }
        
    }
}
