using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1_controller : MonoBehaviour
{       
    public int rock = 0;
    public int paper = 0;
    public int scissors = 0;
    
    public Sprite rock_object;
    public Sprite paper_object;
    public Sprite scissors_object;

    RPSManager sceneManager;
    public GameObject manager;


    public GameObject hand; 
    SpriteRenderer handRenderer;


    void Awake()
    {
        sceneManager = manager.GetComponent<RPSManager>();
        handRenderer = hand.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneManager.updateOn == true)
        {
            if (sceneManager.timeLeft > 0)
            {
                if (Input.GetKeyDown(KeyCode.M) && (Input.GetButton("z")))
                {
                    rock++;
                    
                    handRenderer.sprite = rock_object;
                    
                }
                else if ( Input.GetKeyDown(KeyCode.M) && (Input.GetButton("x")))
                {
                    paper++;
                    
                    handRenderer.sprite = paper_object;
                }
                else if (Input.GetKeyDown(KeyCode.M) && (Input.GetButton("c")))
                {
                    scissors++;
                    
                    handRenderer.sprite = scissors_object;
                }
            }
        }
    }
}
