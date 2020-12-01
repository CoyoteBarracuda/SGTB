using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArcLine : MonoBehaviour
{
    LineRenderer lr;
    public float vel;
    public float angle;
    public int res=10;
    float g;
    float radianAngle;
    public Vector3 LandPoint;
    void Awake()
    {
        lr=GetComponent<LineRenderer>();
        g=Mathf.Abs(Physics.gravity.y);
    }
    void Start()
    {
        //RenderArc();
    }
    public void RenderArc(float v, float a)
    {
        if(a==0)
            a=1;
        angle=a;
        vel=v;
        lr.SetVertexCount(res+1);
        lr.SetPositions(CalculateArcArray());
    }
    Vector3[] CalculateArcArray()
    {
        Vector3[] arrArc=new Vector3[res+1];
        radianAngle=Mathf.Deg2Rad*angle;
        float MaxDistance=(vel*vel*Mathf.Sin(2*radianAngle))/g;
        for(int i=0;i<=res;i++)
        {
            float t=(float)i/(float)res;
            arrArc[i]=CalculateArcPoint(t,MaxDistance);
        }
        LandPoint=transform.TransformPoint(arrArc[res]);
        return arrArc;
    }
    Vector3 CalculateArcPoint(float t, float MaxDistance)
    {
        float z=t*MaxDistance;
        float y=z*Mathf.Tan(radianAngle)-((g*z*z)/(2*vel*vel*Mathf.Cos(radianAngle)*Mathf.Cos(radianAngle)));
        return new Vector3(0,y,z);
    }

}
