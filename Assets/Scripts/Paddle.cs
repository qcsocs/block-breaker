            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public static bool autoPlay = false;


    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoPlay == false)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}
    void MoveWithMouse()
    {
        Vector3 PaddlePos = new Vector3(0.5f, transform.position.y, 0f);
        float mousePosInBox = Input.mousePosition.x / Screen.width * 16;
        //print(mousePosInBox);
        PaddlePos.x = Mathf.Clamp(mousePosInBox, 0.5f, 15.5f);
        transform.position = PaddlePos;
    }

    void AutoPlay()
    {
        Vector3 PaddlePos = new Vector3(0.5f, transform.position.y, 0f);
        float ballPos = ball.transform.position.x;
        //print(mousePosInBox);
        PaddlePos.x = Mathf.Clamp(ballPos, 0.5f, 15.5f);
        transform.position = PaddlePos;
    }
}
