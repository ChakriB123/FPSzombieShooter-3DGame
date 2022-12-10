using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera CamObj;
    public float Range = 100f;
    public float FireRate = 15f;

    public float HitDamage = 20f;


    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;
    public GameObject ImpactEffect1;

    private float NextTimeToFire = 0f;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 

        m_RayCast();

    }

    void m_RayCast()
    {
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
           

            NextTimeToFire = Time.time + 1f / FireRate;
            MuzzleFlash.Play();
            RaycastHit HitObj;
           
            if (Physics.Raycast(CamObj.transform.position, CamObj.transform.forward, out HitObj, Range))
            {
              


                if (HitObj.transform.tag == "enemy")
                {
                    EnemyHealth EnemyHealthScript = HitObj.transform.GetComponent<EnemyHealth>();
                    EnemyHealthScript.EnemyDamage(HitDamage);

                    GameObject ImpactObj = Instantiate(ImpactEffect1, HitObj.point, Quaternion.LookRotation(HitObj.normal));

                    Destroy(ImpactObj, 0.29f);
                }
                else
                {
                    GameObject ImpactObj = Instantiate(ImpactEffect, HitObj.point, Quaternion.LookRotation(HitObj.normal));

                    Destroy(ImpactObj, 2f);
                }

            }
            
        }


    }

}
