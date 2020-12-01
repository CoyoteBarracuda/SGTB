using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    GameObject target;
    public float smoothing = 5f;
    Vector3 offset;
    float xRot, yRot=0f;
    public float RotSpeed=5f;
    bool FollowBall=false;
    public Transform DirectionShot;
    public Vector3 EuAngles;
    public bool PreparingShoot=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ResetCam(Vector3 pos)
    {
        xRot=0f;
        yRot=0f;
        transform.rotation=Quaternion.Euler(0f,0f,0f);
        transform.position=pos;
    }
    void FixedUpdate() 
    {
        // if(!FollowBall)
        // {
        //     target=GameObject.FindGameObjectWithTag("Ball");
        //     if(target!=null)
        //         FollowBall=true;
        // }
        // else
        // {
        //     target=GameObject.FindGameObjectWithTag("Ball");
        //     if(target==null)
        //         FollowBall=false;
        // }
        if(GameObject.FindGameObjectWithTag("Ball")!=null)
        {
        target=GameObject.FindGameObjectWithTag("Ball");
        //offset=transform.position-target.GetComponent<Transform>().position;
        Vector3 targetCamPos=target.transform.position+offset;
        transform.position=Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
            if(!PreparingShoot&&GameObject.FindGameObjectWithTag("Player")!=null)
        //transform.position=ball.position;
                if(Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
                {
                    xRot+=Input.GetAxis("Horizontal")*RotSpeed;
                    yRot+=Input.GetAxis("Vertical")*RotSpeed;
                    if(yRot>0 &&GameObject.FindGameObjectWithTag("Ball")==null)
                        yRot=0;
                    if(yRot<-80&&GameObject.FindGameObjectWithTag("Ball")==null)
                        yRot=-80;
                    transform.rotation=Quaternion.Euler(yRot,xRot,0f);
            
                }
        //GameManager.instance.Direction=transform;
        


    }
    
}
