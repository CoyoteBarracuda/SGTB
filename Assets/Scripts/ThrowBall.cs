using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    GameObject BallClone;
    Animator animator;
    bool create=true;
    GirlStats Stats;
    GirlRot Rot;
    public float DelayTime;
    void Start()
    {
        animator=gameObject.GetComponentInParent<Animator>();
        Stats=gameObject.GetComponentInParent<GirlStats>();
        Rot=gameObject.GetComponentInParent<GirlRot>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(animator.GetBool("Shoot")&&create)
        {
            GameObject go=GameObject.FindGameObjectWithTag("MainCamera");
            go.GetComponent<Control>().EuAngles=new Vector3(go.transform.eulerAngles.x,go.transform.eulerAngles.y,go.transform.eulerAngles.z);
            go.transform.eulerAngles=new Vector3(0f,go.transform.eulerAngles.y,0f);
            Invoke("Shoot",animator.GetCurrentAnimatorStateInfo(0).length/DelayTime);
            create=false;
        }
    }
    void Shoot()
    {
        //if(create)
        //{
        Vector3 pos = this.transform.position;
        BallClone=Instantiate(Ball, pos, new Quaternion(0, 0, 0, 100));
        GameObject go=GameObject.FindGameObjectWithTag("Direction");
        BallClone.GetComponent<Rigidbody>().AddForce(go.transform.forward*(Stats.Power*Rot.Force),ForceMode.Impulse);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Control>().PreparingShoot=false;
        GameObject.FindGameObjectWithTag("Direction").GetComponent<Control>().PreparingShoot=false;
        //create=false;
        //}
    }
}
