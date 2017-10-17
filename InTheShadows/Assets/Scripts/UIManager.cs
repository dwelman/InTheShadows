using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Camera   camera;
    bool            animating;
    public CardAnimation   play, test, quit;

   
    enum State { MAIN, LEVELS, INGAME}
    State state;
	// Use this for initialization
	void Start ()
    {
        state = State.MAIN;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.tag);
                if (hit.transform.CompareTag("PlayBtn"))
                {
                    state = State.LEVELS;
                    play.Yank();
                    test.Yank();
                    quit.Yank();
                }
            }
        }
    }
}
