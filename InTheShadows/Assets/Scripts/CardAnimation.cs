using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    enum AnimState
    {
        STATIC,
        YANK,
        TOEND,
        TOSTART,
    }
    public Vector3  endPos;
    public Vector3  yankPos;
    public float    moveSpeed;
    public float    yankSpeed;
    public Vector3  start;
    bool            animating;
    AnimState       animState;
    public float    delay;
    float           delayCount;

	void Start ()
    {
        animState = AnimState.STATIC;
        start = transform.position;
    }

    public void Yank()
    {
        animState = AnimState.YANK;
        animating = true;
    }

    public void MoveToEnd()
    {
        animState = AnimState.TOEND;
        animating = true;
    }

    void StepToStart()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, start, step);
        if (transform.position == start)
        {
            animating = false;
        }
    }

    void StepToEnd()
    {
       // delayCount += Time.deltaTime;
        //if (delayCount > delay)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos)
            {
                animating = false;
                delayCount = 0;
            }
        }
    }

    void StepToYank()
    {
        delayCount += Time.deltaTime;
        if (delayCount > delay)
        {
            float step = yankSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, yankPos, step);
            if (transform.position == yankPos)
            {
                animState = AnimState.TOEND;
                delayCount = 0;
            }
        }
    }

    void Update ()
    {
		if (animating)
        {
            switch (animState)
            {
                case AnimState.STATIC:
                    break;
                case AnimState.TOEND:
                    {
                        StepToEnd();
                        break;
                    }
                case AnimState.TOSTART:
                    {
                        StepToStart();
                        break;
                    }
                case AnimState.YANK:
                    {
                        StepToYank();
                        break;
                    }
            }
        }
	}
}
