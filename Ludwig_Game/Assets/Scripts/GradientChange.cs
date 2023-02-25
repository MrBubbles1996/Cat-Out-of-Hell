using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientChange : MonoBehaviour
{
    public GameObject player1RockSlice;
    SpriteRenderer player1RockRenderer;
    public GameObject player1PaperSlice;
    SpriteRenderer player1PaperRenderer;
    public GameObject player1ScissorsSlice;
    SpriteRenderer player1ScissorsRenderer;

    public GameObject player2RockSlice;
    SpriteRenderer player2RockRenderer;
    public GameObject player2PaperSlice;
    SpriteRenderer player2PaperRenderer;
    public GameObject player2ScissorsSlice;
    SpriteRenderer player2ScissorsRenderer;

    Player1_controller player1Script;
    public GameObject player1;

    CpuLogic player2Script;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1Script = player1.GetComponent<Player1_controller>();
        player2Script = player2.GetComponent<CpuLogic>();

        player1RockRenderer = player1RockSlice.GetComponent<SpriteRenderer>();
        player1PaperRenderer = player1PaperSlice.GetComponent<SpriteRenderer>();
        player1ScissorsRenderer = player1ScissorsSlice.GetComponent<SpriteRenderer>();

        player2RockRenderer = player2RockSlice.GetComponent<SpriteRenderer>();
        player2PaperRenderer = player2PaperSlice.GetComponent<SpriteRenderer>();
        player2ScissorsRenderer = player2ScissorsSlice.GetComponent<SpriteRenderer>();
          
    }

    // Update is called once per frame
    void Update()
    {
        player1RockRenderer.color = Color.Lerp(Color.clear, Color.magenta, (float)player1Script.rock/50);
        player1PaperRenderer.color = Color.Lerp(Color.clear, Color.cyan, (float)player1Script.paper/50);
        player1ScissorsRenderer.color = Color.Lerp(Color.clear, Color.yellow, (float)player1Script.scissors/50);

        player2RockRenderer.color = Color.Lerp(Color.clear, Color.magenta, (float)player2Script.rock/50);
        player2PaperRenderer.color = Color.Lerp(Color.clear, Color.cyan, (float)player2Script.paper/50);
        player2ScissorsRenderer.color = Color.Lerp(Color.clear, Color.yellow, (float)player2Script.scissors/50);
    }
}
