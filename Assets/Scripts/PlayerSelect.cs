using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Girls=new GameObject[4];
    public GameObject[] GirlsSad=new GameObject[4];
    public Vector3[] GirlsPos=new Vector3[4];
    public int [] Relation=new int [4];
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangePlayer(GameObject go)
    {

    }
    void Update()
    {
        if(GameManager.instance.FinalCourse)
        {
            GameManager.instance.FinalCourse=false;
            ResultSpawn(GameManager.instance.Ranking);
        }
    }
    public void ResultSpawn(int[] pos)
    {
        for(int i=0;i<GameManager.instance.NumberOfPlayers;i++)
        {           
            if(i==0)
                Instantiate( GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[pos[i]], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsPos[i], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Girls[pos[i]].transform.rotation);       
            else
                Instantiate( GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsSad[pos[i]], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsPos[i], GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().GirlsSad[pos[i]].transform.rotation);
            GameObject[] go=GameObject.FindGameObjectsWithTag("GirlResult");
            go[i].GetComponent<TextMesh>().text="Score: "+GameManager.instance.POrder[i].Shoots.ToString();
            //x.transform.parent = gameObject.transform;
        }
    }
}
