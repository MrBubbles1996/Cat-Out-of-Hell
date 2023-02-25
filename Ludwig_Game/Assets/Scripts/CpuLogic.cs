using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CpuLogic : MonoBehaviour
{   
    public int rock = 0;
    public int paper = 0;
    public int scissors = 0;

    public Sprite rock_object;
    public Sprite paper_object;
    public Sprite scissors_object;

    public GameObject rock_slice;
    public GameObject paper_slice;
    public GameObject scissor_slice;

    RPSManager sceneManager;
    public GameObject manager;

    public GameObject hand; 
    SpriteRenderer handRenderer;

    public int choice = 0;
    public float numberOfSeconds = 5f;
    public bool isRunning = true;

    public int min;
    public int max;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = manager.GetComponent<RPSManager>();
        handRenderer = hand.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( sceneManager.updateOn == true)
        {
            if (isRunning == true)
            {
                StartCoroutine(Wait());
            }
        }
    }

    public IEnumerator Wait()
    {
        isRunning = false;

        yield return new WaitForSeconds (numberOfSeconds);
        
        choice = Random.Range(min,max);
        
        if (sceneManager.timeLeft > 0)
        {
            if (choice == 1 || choice == 4 || choice == 7)
            {
                rock++;
                handRenderer.sprite = rock_object;
            }
            else if (choice == 2 || choice == 5 || choice == 8)
            {
                paper++;
                handRenderer.sprite = paper_object;
            }
            else if (choice == 3 || choice == 6 || choice == 9)
            {
                scissors++;
                handRenderer.sprite = scissors_object;
            }
        }
        isRunning = true;
    }
}