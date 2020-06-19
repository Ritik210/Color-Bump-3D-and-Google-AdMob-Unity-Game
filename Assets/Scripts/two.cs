using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class two : MonoBehaviour
{
    public GameObject NextLevelUI;

    
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        

        if (GameManager.singleton.GameWon == true)
        {
            NextLevel();
        }

     }

    

    void NextLevel()
    {

        NextLevelUI.SetActive(true);
        //RestartUI.SetActive(false);
    }
}
