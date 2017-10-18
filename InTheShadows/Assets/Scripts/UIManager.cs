using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Camera   camera;
    bool            animating;
    public CardAnimation    play, test, quit,
                            levels, arrow, ivory;


    enum State { MAIN, LEVELS, INGAME}
    State state;
	// Use this for initialization
	void Start ()
    {
        state = State.MAIN;

        ivory.transform.position = ivory.endPos;
        arrow.transform.position = arrow.endPos;
        levels.transform.position = levels.endPos;
    }

    void UpdateUIToActiveState()
    {
        switch (state)
        {
            case State.LEVELS :
                {
                    play.Yank();
                    test.Yank();
                    quit.Yank();
                    ivory.MoveToStart();
                    arrow.MoveToStart();
                    levels.MoveToStart();
                    break;
                }
            case State.MAIN :
                {
                    play.MoveToStart();
                    test.MoveToStart();
                    quit.MoveToStart();

                    ivory.MoveToEnd();
                    arrow.MoveToEnd();
                    levels.MoveToEnd();
                    break;
                }
        }

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
                    UpdateUIToActiveState();
                }
                if (hit.transform.CompareTag("BackBtn"))
                {
                    state = State.MAIN;
                    UpdateUIToActiveState();
                }
                if (hit.transform.CompareTag("TestBtn"))
                {
                    state = State.LEVELS;
                    UpdateUIToActiveState();
                }
                if (hit.transform.CompareTag("Lv1"))
                {
                    SceneManager.LoadScene(SceneManager.GetSceneByName("Level1").buildIndex, LoadSceneMode.Additive);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            state = State.MAIN;
            UpdateUIToActiveState();
        }
    }
}
