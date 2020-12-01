using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="Hole")
        {
            GetComponent<Rigidbody>().velocity= Vector3.zero;
            int pN=(int)GameObject.FindGameObjectWithTag("Player").GetComponent<GirlRot>().PN;
            GameManager.instance.GoalReached(pN+1);
        }
        if(other.gameObject.tag=="OB")
        {
            GetComponent<Rigidbody>().velocity= Vector3.zero;
            GameManager.instance.OB=true;
        }
        if(other.gameObject.tag=="PlainField")
        {
            GetComponent<Rigidbody>().mass= 2;
            GetComponent<Rigidbody>().drag= .15f;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="Mud")
        {
            GetComponent<Rigidbody>().velocity= Vector3.zero;
        }
    }
}
