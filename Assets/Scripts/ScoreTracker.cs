using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private int leftScore;
    private int rightScore;
    private bool gameFinish;

    // display score
    Text score;

    // a way to display a winner
    public WinnerDisplayer winnerDisplayer;


    private void Start()
    {
        score = GetComponent<Text>();
        gameFinish = false;
        leftScore = 0;
        rightScore = 0;
    }

    // increase the left player's score.
    // If someone one, return true. Else, false.
    public void IncreaseLeftScore()
    {
        leftScore++;
        score.text = $"{leftScore} : {rightScore}";
        checkWinner();
    }

    // increase the left player's score.
    // If someone one, return true. Else, false.
    public void IncreaseRightScore()
    {
        rightScore++;
        score.text = $"{leftScore} : {rightScore}";
        checkWinner();
    }

    // check if there's a winner. If there is, return
    // true. Else, false.
    private void checkWinner() 
    {
        if (leftScore == 3)
        {
            winnerDisplayer.setWinner("LEFT");
            gameFinish = true;
        } else if (rightScore == 3)
        {
            winnerDisplayer.setWinner("RIGHT");
            gameFinish = true;
        }
    }

    public void StartNewRound() 
    {
        if (gameFinish) 
        {
            Reset();
        }
    }

    public void Reset()
    {
        score.text = "0 : 0";
        winnerDisplayer.clear();
        Start();
    }

}
