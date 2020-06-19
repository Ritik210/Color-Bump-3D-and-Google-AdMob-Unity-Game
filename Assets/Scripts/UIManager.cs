using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject RestartUI;
    public GameObject abc;
    bool a = true;


    void Start()
    {
        a = true;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        
            if (GameManager.singleton.GameEnded == true)
            {
                Pause();
            }
        
       
    
    }


    void FixedUpdate()
    {
        if (GameManager.singleton.GameWon == true)
        {
            NextLevel();
            a = false;
           
        }
    }

    void Pause()
    {
       if (a == true)
        {
            RestartUI.SetActive(true);
        }

       else if (a == false)
        {
            RestartUI.SetActive(false);
        }



    }

    void NextLevel()
    {

        abc.SetActive(true);
        
        RestartUI.SetActive(false);
       
    }
        


}

