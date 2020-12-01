using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroyPlayer : MonoBehaviour
{
    public enum PNumber
    {
        P1=1,
        P2=2,
        P3=3,
        P4=4
    }
    public PNumber pNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameManager.instance.SpawnPlayer((int)pNumber-1,GameManager.instance.GetOrder());
    }
}
