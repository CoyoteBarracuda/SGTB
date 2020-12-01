using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceController : MonoBehaviour
{
    public GameObject[] PlayerEntrance;
    public Vector3[] PlayerEntrancePos;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.StartCourse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
