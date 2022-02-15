using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSceneManager : MonoBehaviour
{
    public GameMaster master { get; private set; }

    public Transform[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("Game Master").GetComponent<GameMaster>();

        for(int i = 0; i < master._Players.Count; i++)
        {
            master._Players[i].InitGameplay(spawnLocations[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
