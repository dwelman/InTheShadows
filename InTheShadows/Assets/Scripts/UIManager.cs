﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Camera   camera;
    bool            animating;
    public CardAnimation    play, test, quit,
                            levels, arrow, 
							ivory, rooibos, home, mol;
	int level;
	public Material	completeMat;
	public Material	defaultMat;

    enum State { MAIN, LEVELS, INGAME}
    State state;
	// Use this for initialization
	void Start ()
    {
        state = State.MAIN;

        ivory.transform.position = ivory.endPos;
		rooibos.transform.position = rooibos.endPos;
		home.transform.position = home.endPos;
		mol.transform.position = mol.endPos;

        arrow.transform.position = arrow.endPos;
        levels.transform.position = levels.endPos;
		level = PlayerPrefs.GetInt ("level");
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
					ivory.GetComponent<Renderer> ().material = defaultMat;
					rooibos.GetComponent<Renderer> ().material = defaultMat;
					home.GetComponent<Renderer> ().material = defaultMat;	
					mol.GetComponent<Renderer> ().material = defaultMat;

					if (level > 0)
					{
						rooibos.MoveToStart ();
					ivory.GetComponent<Renderer> ().material = completeMat;
					}
					if (level > 1)
					{
						home.MoveToStart ();
					rooibos.GetComponent<Renderer> ().material = completeMat;
						
					}
					if (level > 2)
					{
						mol.MoveToStart ();
					home.GetComponent<Renderer> ().material = completeMat;
					}
					if (level > 3)
					{
					mol.GetComponent<Renderer> ().material = completeMat;
					}
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
					rooibos.MoveToEnd();
					home.MoveToEnd();
					mol.MoveToEnd ();

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
					level = PlayerPrefs.GetInt ("level");
                    UpdateUIToActiveState();
                }
                if (hit.transform.CompareTag("BackBtn"))
                {
					
                    state = State.MAIN;
                    UpdateUIToActiveState();
                }
                if (hit.transform.CompareTag("TestBtn"))
                {
					level = 4;
                    state = State.LEVELS;
                    UpdateUIToActiveState();
                }
				if (hit.transform.CompareTag("QuitBtn"))
				{
					Application.Quit ();
				}
                if (hit.transform.CompareTag("Lv1"))
                {
					SceneManager.LoadScene("Level1");
                }
				if (hit.transform.CompareTag("Lv2"))
				{
					SceneManager.LoadScene("Level2");
				}
				if (hit.transform.CompareTag("Lv3"))
				{
					SceneManager.LoadScene("Level3");
				}
				if (hit.transform.CompareTag("Lv4"))
				{
					SceneManager.LoadScene("Level4");
				}
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            state = State.MAIN;
            UpdateUIToActiveState();
        }
		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerPrefs.DeleteAll();
		}
    }
}
