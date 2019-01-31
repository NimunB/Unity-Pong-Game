//Nimun Bajwa
//January 29th
//Pong game with Unity
//Guidance/Information/Steps from: https://www.youtube.com/watch?v=1oY--Zk9b6w&t=585s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;

    }

    public void Init(bool isRightPaddle){

        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            //Place paddle on right of screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; //move a bit to the left

            input = "PaddleRight";
        }
        else
        {
            //Place paddle on left of screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; //move a bit to the right

            input = "PaddleLeft";
        }

        //Update this paddle's position
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        //Now let's move the paddle!

        //GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Restrict paddle movement
        // If paddle is too low and user is continuing to move down, stop
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        // If paddle is too high and user is continuing to move up, stop
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
