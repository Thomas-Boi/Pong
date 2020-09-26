using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerDisplayer : MonoBehaviour
{
    Text winnerText;
    // Start is called before the first frame update
    void Start()
    {
        winnerText = GetComponent<Text>();
    }

    /**
     * Set a winner. Must be either "LEFT"
     * or "RIGHT".
     */
    public void setWinner(string winner) 
    {
        winnerText.text = $"{winner} PLAYER WINS!";
    }

    public void clear()
    {
        winnerText.text = "";
    }
}
