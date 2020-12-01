using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIChanger : MonoBehaviour
{
    CanvasGroup[] canvases;
    public int CurrentUI=0;
    public Toggle RandomCourses;
    // Start is called before the first frame update
    void Start()
    {
        canvases = GetComponentsInChildren<CanvasGroup>();

        canvases[0].alpha = 1;
        canvases[0].interactable = true;
        //GameObject obj =GetComponent<Transform>().GetChild(0).gameObject;
    }
    public void NPlayers(int i)
    {
        GameManager.instance.NumberOfPlayers=i;
    }
    public void NCourses(int i)
    {
        GameManager.instance.NLevels=i;   
        for(int x=0;x<GameManager.instance.NumberOfPlayers;x++)
            switch (x)
            {
                case 0:
                GameObject.FindGameObjectWithTag("PlayerSpawner1").GetComponent<SetPlayer>().FirstSpawn(0);
                break;
                case 1:
                GameObject.FindGameObjectWithTag("PlayerSpawner2").GetComponent<SetPlayer>().FirstSpawn(1);
                break;
                case 2:
                GameObject.FindGameObjectWithTag("PlayerSpawner3").GetComponent<SetPlayer>().FirstSpawn(2);
                break;
                case 3:
                GameObject.FindGameObjectWithTag("PlayerSpawner4").GetComponent<SetPlayer>().FirstSpawn(3);
                break;
            }   
    }
       
    public void RandomizeCourses()
    {
        GameManager.instance.RandomCourses=RandomCourses.isOn;
    }
    public void StartGame()
    {
        GameManager.instance.playGame();
    }
        public void ReturnMenu()
    {
        GameManager.instance.MainMenu();
    }
    public void ChangeUI(int index)
    {
        GameObject obj;
        //canvases[CurrentUI].alpha = 0;
        DOTweenModuleUI.DOFade(canvases[CurrentUI], 0, 1f);
        obj = GetComponent<Transform>().GetChild(CurrentUI).gameObject;
        DOTweenModuleUI.DOFade(canvases[index], 1, 1f);

        while (DOTween.IsTweening(obj))
        { }

        canvases[index].alpha = 1;
        canvases[CurrentUI].interactable = false;
        canvases[index].interactable = true;
        //obj = GetComponent<Transform>().GetChild(index).gameObject;
        CurrentUI = index;
    }



    public void ChangeUIIngame(int index,bool enableMenu)
    {
        GameObject obj;
        canvases[CurrentUI].alpha = 0;
        if (index == 1)
        {
            DOTweenModuleUI.DOFade(canvases[index], 1, .8f);
            obj = GetComponent<Transform>().GetChild(index).gameObject;
        }
        else
        {
            DOTweenModuleUI.DOFade(canvases[1], 0, .8f);
            obj = GetComponent<Transform>().GetChild(1).gameObject;
        }


    }


}
