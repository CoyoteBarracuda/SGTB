using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlRot : MonoBehaviour
{
    // Start is called before the first frame update

    float xRot, yRot=0f;

    public float RotSpeed=5f;
    public GameObject target;
    public LineRenderer lineVisual;
    public LineRenderer lineTotal;
    public LineRenderer ArcPointer;
    float LineLenght=0.1f;
    public int MaxLine;
    public int MinLine;
    bool Shoot=false;
    public float Force;
    Animator animator;
    public int PN;
    GameObject MC;
    GameObject mmAim;

    void Start()
    {
        //lineVisual.positionCount=LineLenght;
        StartCoroutine(LineGrowth());
        LineLenght=MinLine;
        lineVisual.SetPosition(1, new Vector3 (0,0,MinLine));
        lineTotal.SetPosition(1, new Vector3 (0,0,MaxLine));
        animator=gameObject.GetComponentInParent<Animator>();
        MC=GameObject.FindGameObjectWithTag("MainCamera");
        mmAim=GameObject.FindGameObjectWithTag("minimapAim");
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")!=0&&!Shoot)
        {
            xRot+=Input.GetAxis("Horizontal")*RotSpeed;
            transform.rotation=Quaternion.Euler(0,xRot,0f);
            Vector3 lPos=lineVisual.GetPosition(1);
            lPos.x+=xRot;
            ArcPointer.transform.rotation=Quaternion.Euler(0,lPos.x,0f);
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        if(animator.GetBool("Shoot"))
        {
            Shoot=true;
        }
    }
    IEnumerator LineGrowth()
    {
        bool Reverse=false;
        while(!Shoot)
        {
        yield return new WaitForSeconds(.1f);               
        if(LineLenght>MaxLine)
            Reverse=true;
        if(LineLenght<MinLine)
            Reverse=false;
        if(Reverse)
            LineLenght-=gameObject.GetComponent<GirlStats>().Control*Time.deltaTime;
        else
            LineLenght+=gameObject.GetComponent<GirlStats>().Control*Time.deltaTime;
        lineVisual.SetPosition(1, new Vector3 (0,0,LineLenght));
        gameObject.GetComponentInChildren<ArcLine>().RenderArc(GetComponent<GirlStats>().Power*LineLenght,-MC.transform.rotation.eulerAngles.x);
        //mmAim.transform.position=new Vector3(transform.position.x+(gameObject.GetComponentInChildren<ArcLine>().LandPoint.z*(xRot/60)),0,transform.position.z+gameObject.GetComponentInChildren<ArcLine>().LandPoint.z*.8f);
        mmAim.transform.position=gameObject.GetComponentInChildren<ArcLine>().LandPoint;
        }
        Force=LineLenght;
        gameObject.GetComponentInChildren<ArcLine>().RenderArc(GetComponent<GirlStats>().Power*LineLenght,-MC.GetComponent<Control>().EuAngles.x);
        //mmAim.transform.position=new Vector3(transform.position.x+(gameObject.GetComponentInChildren<ArcLine>().LandPoint.z*(xRot/60)),0,transform.position.z+gameObject.GetComponentInChildren<ArcLine>().LandPoint.z*.8f);
        mmAim.transform.position=gameObject.GetComponentInChildren<ArcLine>().LandPoint;
    }
}
