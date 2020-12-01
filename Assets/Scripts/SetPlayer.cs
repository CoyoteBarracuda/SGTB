using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerID;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void FirstSpawn(int y)
    {
        var x=Instantiate( GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[y], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsPos[y], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[y].transform.rotation);
        x.transform.parent = gameObject.transform;
    }
    public void CreatePlayer(int i)
    {
        Destroy(transform.GetChild(0).gameObject);
        int y=PlayerID;
        y++;
        if(y==5)
            y=1;
        GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Relation[i]=y-1;
        var x=Instantiate( GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[y-1], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsPos[i], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[y-1].transform.rotation);
        x.transform.parent = gameObject.transform;
        PlayerID=y;
    }
}
