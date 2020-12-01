using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointer : MonoBehaviour
{
    public LineRenderer linePointer;
    void Start()
    {
        Vector3 goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
        Vector3 playerPos=GameObject.FindGameObjectWithTag("PlayerSpawner").transform.position;
        linePointer.transform.position=(playerPos+goalPos)/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDistance(Vector3 PPos)
    {
        Vector3 goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
        linePointer.transform.position=(PPos+goalPos)/2;
    }
}
