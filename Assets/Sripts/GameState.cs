using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameTimer gameTimer;

    public bool[] Door = { false, false, false, false, false };


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Door[4] == true)
            {
                if (gameTimer != null && gameTimer.isRunning == true)
                {
                    gameTimer.StopTimer();
                }


            }
        }
    }
        public void PuzzelSolved(int PuzzelID)
        {
            Door[PuzzelID] = true;
        }
        public void PuzzelUnSolved(int PuzzelID) {
            Door[PuzzelID] = false;
        }
    }

