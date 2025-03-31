using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    float stopSpeed = 0.01f;
    float decreaseRate = 0.98f;
    float speedRatio = 0.0004f;

    Vector2 startPos;
    Vector2 endPos;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            float swipeLength = endPos.x - startPos.x;
            speed = swipeLength * speedRatio;

            audio.Play();
        }

        transform.position += new Vector3(speed, 0, 0);
        speed *= decreaseRate;

        if(speed < stopSpeed)
        {
            speed = 0;
        }
    }
}
