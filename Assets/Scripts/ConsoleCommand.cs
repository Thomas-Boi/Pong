using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class ConsoleCommand : MonoBehaviour
{
    public bool awake = false;
    public GameObject console;
    public InputField input;
    public GameObject background;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        console.SetActive(awake);
    }

    // Update is called once per frame
    void Update()
    {
        if (awake == true)
        {
            //focus input
            input.ActivateInputField();

            //close console
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                awake = false;
                console.SetActive(false);
            }

            // submit
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Submit(input.text);
            }



            

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            awake = true;
            console.SetActive(true);
        }

    }

    private void Submit(string text)
    {

        input.text = "";

        if (text == "red")
        {
            background.GetComponent<Renderer>().material.color = Color.red;
        }
        if (text == "green")
        {
            background.GetComponent<Renderer>().material.color = Color.green;
        }
        if (text == "blue")
        {
            background.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (text == "white")
        {
            background.GetComponent<Renderer>().material.color = Color.white;
        }
        if (text == "ballred")
        {
            ball.GetComponent<Renderer>().material.color = Color.red;
        }
        if (text == "ballgreen")
        {
            ball.GetComponent<Renderer>().material.color = Color.green;
        }
        if (text == "ballblue")
        {
            ball.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (text == "ballwhite")
        {
            ball.GetComponent<Renderer>().material.color = Color.white;
        }

    }


}
