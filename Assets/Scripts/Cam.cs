using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        	if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				switch(hit.transform.gameObject.name)
                {
                    case "Player1":
                    GameObject.FindGameObjectWithTag("PlayerSpawner1").GetComponent<SetPlayer>().CreatePlayer(0);
                    break;
                    case "Player2":
                    GameObject.FindGameObjectWithTag("PlayerSpawner2").GetComponent<SetPlayer>().CreatePlayer(1);
                    break;
                    case "Player3":
                    GameObject.FindGameObjectWithTag("PlayerSpawner3").GetComponent<SetPlayer>().CreatePlayer(2);
                    break;
                    case "Player4":
                    GameObject.FindGameObjectWithTag("PlayerSpawner4").GetComponent<SetPlayer>().CreatePlayer(3);
                    break;
                }
			}
		}
    }
}
