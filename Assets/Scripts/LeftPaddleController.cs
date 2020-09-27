using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleController : MonoBehaviour
{
    private float bottomY = -7.7f;
    private float topY = 12.5f;
    private float paddleSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 clampPos = transform.position;
        clampPos.y = Mathf.Clamp(clampPos.y, bottomY, topY);
        transform.position = clampPos;

        // Input for left paddle (main player)
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 paddlePos = new Vector3(0, paddleSpeed, 0);
            transform.Translate(paddlePos);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 paddlePos = new Vector3(0, -paddleSpeed, 0);
            transform.Translate(paddlePos);
        }

    }
}
