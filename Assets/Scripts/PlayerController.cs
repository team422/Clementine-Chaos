using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
        //MainMenuHandler.selected = "Purple";
        GameObject handler = GameObject.Find("GameHandler");
        string label = "NO";
        if (gameObject.name.Equals("Purple"))
        {
            label = "PR";
        }
        else if (gameObject.name.Equals("Blue"))
        {
            label = "BL";
        }
        else if (gameObject.name.Equals("Yellow"))
        {
            label = "YE";
        }
        else if (gameObject.name.Equals("Brown"))
        {
            label = "BR";
        }

        if (MainMenuHandler.selected.Equals(gameObject.name))
        {
            float speedCap = 0.2f;
            float deltaX = Input.GetAxis("Horizontal") * speedCap;
            float deltaY = Input.GetAxis("Vertical") * speedCap;
            float speed = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (speed > speedCap)
            {
                deltaX *= speedCap / speed;
                deltaY *= speedCap / speed;
            }
            transform.position = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, transform.position.y + deltaY - 0.97f); //Z is same as Y, but at bottom of rect

            if ((deltaX > 0 && transform.localScale.x > 0) || (deltaX < 0 && transform.localScale.x < 0))
            {
                //flip to be facing the right way
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                GetComponent<CircleCollider2D>().transform.localScale = scale;

                Vector3 position = transform.localPosition;
                if (deltaX > 0)
                {
                    position.x += 1f;
                }
                else
                {
                    position.x -= 1f;
                }
                transform.localPosition = position;
                GetComponent<CircleCollider2D>().transform.localPosition = position;

            }
            //Debug.Log(label + "X:" + string.Format("{0:N2}", transform.position.x) + " " + label + "Y:" + string.Format("{0:N2}", transform.position.y) + " " + label + "Z:" + string.Format("{0:N2}", transform.position.z));

            handler.GetComponent<TcpLink>().sendMessageToServer(label + "X:" + string.Format("{0:N2}", transform.position.x) + " " + label + "Y:" + string.Format("{0:N2}", transform.position.y) + " " + label + "Z:" + string.Format("{0:N2}", transform.position.z));
        }
        else {
            Regex xCoord = new Regex(@"(?<="+label+@"X:)\d+");
            Regex yCoord = new Regex(@"(?<="+label+@"Y:)\d+");
            Regex zCoord = new Regex(@"(?<="+label+@"Z:)\d+");
            string message = handler.GetComponent<TcpLink>().serverOut();
            if (xCoord.Match(message).Success&& xCoord.Match(message).Success&& xCoord.Match(message).Success) {
                transform.position = new Vector3(float.Parse(xCoord.Match(message).Value), float.Parse(yCoord.Match(message).Value));
            }
            
        }

    }
}