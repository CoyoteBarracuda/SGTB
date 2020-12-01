using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
public static GameManager instance = null;
    public Transform SpawnPoint;
    public GameObject[] Player;
    public Transform Direction;
    public bool Shooting=false;
    public float _Goal;
    public Text GoalText;
    public float _Distance;
    public Text distanceText;
    public Text ShotText;
    public Text CPText;
    public int[] PlayerFinish=new int[4]; 
    public bool[] PlayerEnter=new bool[4]; 
    public Vector3[] PPos=new Vector3[4];
    Vector3[] CamPos=new Vector3[4];
    public int[] Ranking=new int[4];
    public int[] NShots=new int[4];
    GameObject Entrances;
    public int NumberOfPlayers;
    public bool RandomCourses;
    public bool OB=false;
    int[] rel;
    public bool FinalCourse=false;
    public int NLevels=1;
    int CurrentLevel=0;
    public string[] scenes;
    string[] scenesPlayed=new string[6];
    public List<P> POrder;
    public class P 
    {
        public int Player { get; set; }
        public int Skin { get; set; }
        public int Shoots { get; set; }
        public P()
        {
            Player=0;
            Skin=0;
            Shoots=0;
        }
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start() 
    {

    }
    public void ReloadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartCourse()
    {
        Vector3 goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
        Goal=(float)System.Math.Round((goalPos-SpawnPoint.position).magnitude,2);
        Distance=0;
        Entrances=GameObject.FindGameObjectWithTag("PlayerEntrance");
        SpawnPlayer(rel[0],0);
    }
    public float Distance
    {
        get { return _Distance; }
        set
        {
            _Distance = value;
            distanceText.text = "Distance: " + _Distance.ToString()+"Km";
        }
    }
    public float Goal
    {
        get { return _Goal; }
        set
        {
            _Goal = value;
            GoalText.text = "Goal: " + _Goal.ToString()+"Km";
        }
    }
    public void playGame()
    {
        rel=GameObject.FindGameObjectWithTag("CanvasGroup").GetComponent<PlayerSelect>().Relation;
        CurrentLevel++;
        string sc="";
        if(RandomCourses)
            do
                sc=scenes[Random.Range(0, scenes.Count())];
            while(System.Array.Exists(scenesPlayed, str => str == sc));
        else
            sc=scenes[CurrentLevel-1];
        scenesPlayed[0]=sc;
        SceneManager.LoadScene(sc);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GoalReached(int p)
    {
        PlayerFinish[p-1]=1;
    }
    bool CheckNextLevel()
    {
        if(PlayerFinish[0]+PlayerFinish[1]+PlayerFinish[2]+PlayerFinish[3]==NumberOfPlayers)
            return true;
        else
            return false;
    }
    void NextLevel()
    {
        for (int i=0;i<4;i++)
        {
            PlayerEnter[i]=false;
            PlayerFinish[i]=0;
            PPos[i]=new Vector3(-1.807315f,0.38f,1.355345f);
            CamPos[i]=new Vector3(0.012f,0.25f,1.93f);
        }    
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Control>().ResetCam(CamPos[0]);
        GameObject.FindGameObjectWithTag("Direction").GetComponent<Control>().ResetCam(CamPos[0]);    
        SpawnPoint.position=new Vector3(-1.807315f,0.38f,1.355345f);
        CurrentLevel++;
        if(CurrentLevel>NLevels)
        {
            POrder=new List<P>();
            for (int i=0;i<GameManager.instance.NumberOfPlayers;i++)
            {
                P PO=new P();
                PO.Shoots=NShots[i];
                PO.Player=i;
                PO.Skin=rel[i];
                POrder.Add(PO);
            }
            // POrder[0].Shoots=NShots[0];
            // POrder[0].Player=0;
            // POrder[1].Shoots=NShots[1];
            // POrder[1].Player=1;
            // POrder[2].Shoots=NShots[2];
            // POrder[2].Player=2;
            // POrder[3].Shoots=NShots[3];
            // POrder[3].Player=3;
            //int[] values=new int[4];
            //values[0]=p1;
            //values[1]=p2;
            //values[2]=p3;
            //values[3]=p4;
            POrder=POrder.OrderBy(x => x.Shoots).ToList();
            //System.Array.Sort(values);
            for (int i=0;i<GameManager.instance.NumberOfPlayers;i++)
            {
                Ranking[i]=POrder[i].Skin;
            }
            GameManager.instance.FinalCourse=true;
            SceneManager.LoadScene("Results");
        }
        else
        {
            string sc="";
            if(RandomCourses)
                do
                    sc=scenes[Random.Range(0, scenes.Count())];
                while(System.Array.Exists(scenesPlayed, str => str == sc));
            else
                sc=scenes[CurrentLevel-1];
            scenesPlayed[CurrentLevel-1]=sc;
            SceneManager.LoadScene(sc);
        }
    }
    public int GetOrder()
    {
        int i=0;
        Vector3 goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
        switch(NumberOfPlayers)
        {
            case 1:
                i=0;
                break;
            case 2:
                if(
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[1]).magnitude,2))
                )
                {
                    i=0;
                }
                else
                {
                    i=1;
                }
                break;
            case 3:
                if(
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[1]).magnitude,2))&&
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[2]).magnitude,2))
                )
                {
                    i=0;
                }
                else if(
                ((float)System.Math.Round((goalPos-PPos[1]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[2]).magnitude,2))
                )
                {
                    i=1;
                }
                else
                {
                    i=2;
                }
                break;
            case 4:
                if(
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[1]).magnitude,2))&&
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[2]).magnitude,2))&&
                ((float)System.Math.Round((goalPos-PPos[0]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[3]).magnitude,2))
                )
                {
                    i=0;
                }
                else if(
                ((float)System.Math.Round((goalPos-PPos[1]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[2]).magnitude,2))&&
                ((float)System.Math.Round((goalPos-PPos[1]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[3]).magnitude,2))
                )
                {
                    i=1;
                }
                else if(
                ((float)System.Math.Round((goalPos-PPos[2]).magnitude,2)>=(float)System.Math.Round((goalPos-PPos[3]).magnitude,2))
                )
                {
                    i=2;
                }
                else
                {
                    i=3;
                }
                break;
        }
        return i;
    }
    public void NextPlayer(int n,Vector3 Pos)
    {
        int i=0;     
        if(!OB)
        {
            PPos[n]=Pos;
            CamPos[n]=GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        }
        else
        {
            NShots[n]++;
            OB=false;
        }
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Ball"));
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Control>().ResetCam(CamPos[n]);
        GameObject.FindGameObjectWithTag("Direction").GetComponent<Control>().ResetCam(CamPos[n]);
        
        if(!CheckNextLevel())
        {           
            NShots[n]++;
            i=GetOrder();
            SpawnPoint.position=PPos[i];
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Control>().ResetCam(CamPos[i]);
            GameObject.FindGameObjectWithTag("Direction").GetComponent<Control>().ResetCam(CamPos[i]);
            Distance=0;
            Vector3 goalPos=GameObject.FindGameObjectWithTag("Hole").transform.position;
            Goal=(float)System.Math.Round((goalPos-PPos[i]).magnitude,2);
            ShotText.text = "Shot: " + NShots[i];
            SpawnPlayer(rel[i],i);
        }
        else
            NextLevel();              
    }
    public void SpawnPlayer(int i,int Order)
    {
        if(PlayerEnter[Order]==false)
        {
            PlayerEnter[Order]=true;
            Instantiate(Entrances.GetComponent<EntranceController>().PlayerEntrance[i],Entrances.GetComponent<EntranceController>().PlayerEntrancePos[i], new Quaternion(0,0,0,100));
            //PlayerEntrance[i].SetActive(true);
        }
        else
        {
            Vector3 pos = SpawnPoint.position;
            GameObject go=Instantiate(Player[i], pos, new Quaternion(0, 0, 0, 100));
            GameObject.FindGameObjectWithTag("LightPointer").GetComponent<GoalPointer>().UpdateDistance(pos);
            go.GetComponent<GirlRot>().PN=Order;
        }
        GameObject.FindGameObjectWithTag("minimapPlayer").transform.position=SpawnPoint.position;
        CPText.text = "Current Player: " + (Order+1);
    }
}
