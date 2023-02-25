using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RPSManager : MonoBehaviour
{
    public bool updateOn = false;
    public bool finalThrowDownOn = false;
    public bool finalThrowDownDone = false;

    public string player2FinalChoice;
    public string player1FinalChoice;

    public float timeLeft = 1f;
    public bool timerOn = false;

    public GameObject winButton;
    public GameObject loseButton;

    Player1_controller player1Manager;
    public GameObject player_1;

    CpuLogic player2Manager;
    public GameObject player_2;

    public GameObject endScreen;

    public GameObject finalThrowDown;

    public TMP_Text winnerStatus;
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    public TMP_Text player2Choice;

    public TMP_Text TimerTxt;

    int player1Score = 0;
    int player2Score = 0;

    void Awake()
    {
        player1Manager = player_1.GetComponent<Player1_controller>();
        player2Manager = player_2.GetComponent<CpuLogic>();
        StartCoroutine(updateOff());
    }
    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        finalThrowDown.SetActive(false);
        winButton.SetActive(false);
        loseButton.SetActive(false);
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(updateOn == true)
        {
            if(timerOn)
            {
                if(timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    updateTimer(timeLeft);
                }

                else
                {
                    if (finalThrowDownOn == false)
                    {
                        finalThrowDown.SetActive(true);
                    }

                    if (finalThrowDownOn == true)
                        {
                            FinalThrowDown();
                            if(finalThrowDownDone == true)
                            {
                        
                            CountScore(player1Manager.rock,player1Manager.paper,player1Manager.scissors,player2Manager.rock,player2Manager.paper,player2Manager.scissors);
                            endScreen.SetActive(true);
                            player1ScoreText.text = player1Score.ToString();
                            player2ScoreText.text = player2Score.ToString();

                            if(player1Score > player2Score)
                            {
                            winnerStatus.text = "You Win";

                            winButton.SetActive(true);

                            }
                            else if (player2Score >player1Score)
                            {
                                winnerStatus.text = "You Lose";
                                loseButton.SetActive(true);
                            }

                            timeLeft = 0;
                            timerOn = false;

                            }
                        }

                }

            }
        }
    }

    IEnumerator updateOff()
    {
        yield return new WaitForSeconds(3.0f);
        updateOn = true;
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void CountScore(int rock1, int paper1, int scissors1, int rock2, int paper2, int scissors2)
    {
        player1Score = rock1 + paper1 + scissors1;
        player2Score = rock2 + paper2 + scissors2;

        if ( rock1 > scissors2)
        {
            player1Score += scissors2 * 2 + rock1 - scissors2;
        }
        
        if ( paper1 > rock2)
        {
            player1Score += rock2 * 2 + paper1 - rock2;
        }

        if (scissors1 > paper2)
        {
            player1Score += paper2 * 2 + scissors1 - paper2;
        }

        if (rock2 > scissors1)
        {
            player2Score += scissors1 * 2 + rock2 - scissors1;
        }

        if (paper2 > rock1)
        {
            player2Score += rock1 * 2 + paper2 - rock1;
        }

        if (scissors2 > paper1)
        {
            player2Score += paper1 * 2 + scissors2 - paper1;
        }  
    }

    public void NextFight()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RockChoice()
    {
        player1FinalChoice = "Rock";
        finalThrowDownOn = true;
    }

    public void PaperChoice()
    {
        player1FinalChoice = "Paper";
        finalThrowDownOn = true;
    }

    public void scissorsChoice()
    {
        player1FinalChoice = "Scissors";
        finalThrowDownOn = true;
    }

    

    void FinalThrowDown()
    {
        finalThrowDownOn = true;
        finalThrowDown.SetActive(true);

        if ( player2Manager.rock > player2Manager.paper && player2Manager.rock > player2Manager.scissors)
        {
            player2FinalChoice = "Rock";
            player2Choice.text = player2FinalChoice;
        }
        else if (player2Manager.paper > player2Manager.rock && player2Manager.paper>player2Manager.scissors)
        {
            player2FinalChoice = "Paper";
            player2Choice.text = player2FinalChoice;
        }
        else
        {
            player2FinalChoice = "Scissors";
            player2Choice.text = player2FinalChoice;
        }

        if (player1FinalChoice == "Rock" && player2FinalChoice == "Paper")
        {
            player2Score += 50;
        }
        else if (player1FinalChoice == "Rock" && player2FinalChoice == "Scissors")
        {
            player1Score += 50;
        }
        else if (player1FinalChoice == "Rock" && player2FinalChoice == "Rock")
        {
            player1Score += 0;
        }
        else if (player1FinalChoice == "Paper" && player2FinalChoice == "Paper")
        {
            player2Score += 0;
        }
        else if (player1FinalChoice == "Paper" && player2FinalChoice == "Scissors")
        {
            player2Score += 50;
        }
        else if (player1FinalChoice == "Paper" && player2FinalChoice == "Rock")
        {
            player1Score += 50;
        }
        else if (player1FinalChoice == "Scissors" && player2FinalChoice == "Paper")
        {
            player1Score += 50;
        }
        else if (player1FinalChoice == "Scissors" && player2FinalChoice == "Scissors")
        {
            player1Score += 0;
        }
        else if (player1FinalChoice == "Scissors" && player2FinalChoice == "Rock")
        {
            player2Score += 50;
        }

        StartCoroutine(Waiting());
        
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3.0f);
        finalThrowDownDone = true;
        finalThrowDown.SetActive(false);
    }
}
