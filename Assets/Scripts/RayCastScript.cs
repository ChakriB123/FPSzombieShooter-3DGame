using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    public Camera CamObj;

    float MouseX;
    float MouseY;

    GameObject SeletedObj;
    bool IsMoved;

    // Start is called before the first frame update
    void Start()
    {
        IsMoved = false;
    }

    // Update is called once per frame
    void Update()
    {

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        
            m_RayCast();
       
    }

    void m_RayCast()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit HitObj;
            Ray RayOnclick = CamObj.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(RayOnclick, out HitObj, 30f))
            {
                Debug.Log(HitObj.transform.name);
                SeletedObj = HitObj.collider.gameObject;
                IsMoved = true;

            }
        }

        if(Input.GetButtonUp("Fire1"))
        {
            IsMoved = false;
        }

        if(IsMoved == true)
        {

            Vector3 DragPos = CamObj.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,7));
            SeletedObj.transform.position = DragPos;
        }


    }


}
