using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float distance;
    public float goal;
    Vector3 goalPos;
    Vector3 playerPos;
    GameObject miniBall;
    bool Started=false;
    bool Stop=false;
    int pN;
    // Start is called before the first frame update
    void Start()
    {
        goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
        playerPos=GameObject.FindGameObjectWithTag("Player").transform.position;
        pN=GameObject.FindGameObjectWithTag("Player").GetComponent<GirlRot>().PN;
        string PlayerName=GameObject.FindGameObjectWithTag("Player").GetComponent<GirlStats>().Name;
        miniBall=GameObject.FindGameObjectWithTag("minimapBall"+PlayerName);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Stop)
        {
        distance=(float)System.Math.Round((playerPos-transform.position).magnitude,2);
        goal=(float)System.Math.Round((goalPos-transform.position).magnitude,2);
        miniBall.transform.position=new Vector3(transform.position.x,0,transform.position.z);
        GameManager.instance.Distance=distance;
        GameManager.instance.Goal=goal;
        Rigidbody r=GetComponent<Rigidbody>();
        if(r.velocity.magnitude>0f)
            Started=true;
        if(distance>0f && r.velocity.magnitude<=0.1f && Started==true)
        {   
            Stop=true; 
            Started=false;
            Invoke("Next",2.0f);
        }
        }
    }
    void Next()
    {
        GameManager.instance.NextPlayer(pN,gameObject.transform.position);
    }
}
