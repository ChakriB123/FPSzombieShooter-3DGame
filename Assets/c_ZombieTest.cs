using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_ZombieTest : MonoBehaviour
{

    public Animator g_ZombieAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            g_ZombieAnimator.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            g_ZombieAnimator.SetBool("run", false);
        }

    }
}
