//Nimun Bajwa
//January 29th
//Pong game with Unity
//Guidance/Information/Steps from: https://www.youtube.com/watch?v=1oY--Zk9b6w&t=585s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;


    // Start is called before the first frame update
    //Use for initialization
    void Start()
    {
        //Convert screen's pixel coordinate into game's coordinate 
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        //create ball
        Instantiate(ball);

        //create two paddles
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true); //right paddle
        paddle2.Init(false); //left paddle




}
}
