using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void LoadPlayerVsPlayer()
    {
        //Debug.Log("PvP");
        SceneManager.LoadScene("SampleScene");
        PaddleController2.secondPlayer = true;
    }

    public void LoadPlayerVsComputer()
    {
        //Debug.Log("Computer");
        SceneManager.LoadScene("SampleScene");
        PaddleController2.secondPlayer = false;
    }
}
