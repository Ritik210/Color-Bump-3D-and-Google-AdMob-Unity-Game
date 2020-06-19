using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }
    public bool GameWon{ get; private set; }

    [SerializeField] private float slowMotionFactor = 0.1f;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform goalTransform;
    [SerializeField] private BallController ball;
   


    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }



    public void Start()
    {
        StartGame();

        EntireDistance = goalTransform.position.z - startTransform.position.z;

    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;

        }else if(singleton != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

    public void StartGame()
    {
        GameStarted = true;
        Debug.Log("Game Started");
    }

    public void EndGame(bool win)
    {
        GameEnded = true;
        Debug.Log("Game Ended");

        if(!win)
        {
            Invoke("" , 2 * slowMotionFactor);
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
           
        }
        else
        {
           GameWon = true;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            // Invoke("RestartGame",2);
        }
    }

    public void RestartGame()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadedLevel.buildIndex);

    }

    public void RestartUI()
    {

    }
    
   
    
   

    // Update is called once per frame
    void Update()
    {
        DistanceLeft = Vector3.Distance(ball.transform.position, goalTransform.position);

        if (DistanceLeft > EntireDistance)
        {
            DistanceLeft = EntireDistance;
        }
            
        if (ball.transform.position.z > goalTransform.transform.position.z)
        {
            DistanceLeft = 0;

        }

        Debug.Log("Travelled distance is" + DistanceLeft + "entire distance is " + EntireDistance);
    }
}
