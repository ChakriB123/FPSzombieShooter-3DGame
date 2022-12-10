using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePooling : MonoBehaviour
{

     public GameObject ZombieObj;
     
     public GameObject[] ZombieSpawnArray;
     public GameObject[] SpawnPosArray;

     float g_ElapsedTime = 0f;
     float g_StartTime = 0f;
     float g_TargetTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

        g_ElapsedTime = 0f;
        g_StartTime = Time.time;
        g_TargetTime = 2f;

        //ZombieSpawnArray = new GameObject[];
        for (int i = 0; i < ZombieSpawnArray.Length; i++)
        {
            int l_RandomIndex = Random.Range(0, SpawnPosArray.Length);
            ZombieSpawnArray[i] = Instantiate(ZombieObj, SpawnPosArray[l_RandomIndex].transform.position, Quaternion.identity);
            ZombieSpawnArray[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        ZombieRespawn();
        
    }

    public void ZombieRespawn()
    {

        g_ElapsedTime = Time.time - g_StartTime;
        if (g_ElapsedTime >= g_TargetTime)
        {
            g_ElapsedTime = 0f;
            g_StartTime = Time.time;

            for (int i = 0; i < ZombieSpawnArray.Length; i++)
            {
                if (ZombieSpawnArray[i].activeInHierarchy == false)
                {
                    ZombieSpawnArray[i].SetActive(true);
                    int l_RandomIndex = Random.Range(0, SpawnPosArray.Length);
                    ZombieSpawnArray[i].transform.position = SpawnPosArray[l_RandomIndex].transform.position;
                    ZombieSpawnArray[i].GetComponent<EnemyHealth>().ZombieHealth = 100f;
                    break;
                    
                }
            }
        }
    }
}
