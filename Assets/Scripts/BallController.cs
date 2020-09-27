using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public int targetFrameRate = 60;

    // track the ball's speed
    float x_speed = 0.085f;
    float y_speed;

    // track the score and whether the round is done
    bool roundFinish = false;
    Vector3 initialPosition = new Vector3(0, 0, 0);
    public ScoreTracker scoreTracker;

    System.Random randGen;

    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        // fps lock, because the ball moves at 10x speed at 600 fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;


        // generate random y_speed everytime
        randGen = new System.Random();
        float range_ = 0.079f;
        float base_ = 0.01f;
        y_speed = ((float) randGen.NextDouble()) * range_ + base_;

        // see whether the ball will fly left or right
        bool facingRight = randGen.NextDouble() > 0.5;
        if (!facingRight) x_speed = -x_speed; // flip the initial value

        // see whether the ball will fly up or down
        bool facingUp = randGen.NextDouble() > 0.5;
        if (!facingUp) y_speed = -y_speed; // flip the initial value

        scoreTracker.StartNewRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (!roundFinish) transform.Translate(x_speed, y_speed, 0);

        // check if user wants to play a new round
        if (roundFinish && Input.GetKeyDown(KeyCode.Space)) 
        {
            Start();
            roundFinish = false;
        }
    }

    private void Reset()
    {
        roundFinish = true;
        transform.position = initialPosition;
    }

    /**
     * Detect when the ball touches an object.
     * If it's a paddle, reverse x_speed.
     * if it's ceiling or ground, reverse y_speed.
     * If it's a wall, end the round.
     */
    private void OnCollisionEnter(Collision collision)
    {
        String collidedName = collision.collider.name;
        if (collidedName == "LeftPaddle" || collidedName == "RightPaddle")
        {
            if (x_speed > -0.3 && x_speed < 0.3)
            {
                x_speed = (x_speed > 0) ? x_speed + 0.01f : x_speed - 0.01f;
            }
            if (y_speed > -0.3 && y_speed < 0.3)
            {
                y_speed = (y_speed > 0) ? y_speed + 0.01f : y_speed - 0.01f;
            }
            x_speed = -x_speed;
        }
        else if (collidedName == "Ground" || collidedName == "Ceiling")
        {
            y_speed = -y_speed;
        }
        else if (collidedName == "LeftWall")
        {
            scoreTracker.IncreaseRightScore();
            Reset();
        }
        else if (collidedName == "RightWall")
        {
            scoreTracker.IncreaseLeftScore();
            Reset();
        }
    }
}
