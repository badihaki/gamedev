using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GM gameMaster = GameObject.Find("Game Master").GetComponent<GM>();

        gameMaster.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
