using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    private float bottomBound = -6.0f;
    private float topBound = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Input for left paddle (main player)
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 paddlePos = new Vector3(0, 0.1f, 0);
            transform.Translate(paddlePos);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 paddlePos = new Vector3(0, -0.1f, 0);
            transform.Translate(paddlePos);
        }

    }
}
