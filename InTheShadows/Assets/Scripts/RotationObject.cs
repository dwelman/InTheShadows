using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
	public float positionVariance = 0.0005f;
    public float rotationVariance = 2f;
	public float rotationXScrambleMin = 0f;
	public float rotationXScrambleMax = 0f;
	public float rotationYScrambleMin = 25f;
	public float rotationYScrambleMax = 125f;
    public GameObject axes;

	Vector3 victoryPosition;
	Quaternion startingRotation;
	Quaternion victoryRotation;

	void Awake()
	{
		Random.InitState(42);
		SetVictoryPosition();
		SetVictoryRotation();
		ScrambleRotation();
		startingRotation = transform.rotation;
	}

	void SetVictoryPosition()
	{
		victoryPosition = transform.position;
	}

	void SetVictoryRotation()
	{
		victoryRotation = transform.rotation;
	}

	void ScrambleRotation()
	{
		transform.Rotate(Random.Range(rotationXScrambleMin, rotationXScrambleMax), 0, 0, Space.Self);
		transform.RotateAround(transform.position, new Vector3(0, 1, 0), Random.Range(rotationYScrambleMin, rotationYScrambleMax));
	}

	public void ResetRotation()
	{
		transform.rotation = startingRotation;
	}

	public bool CheckVictoryCondition()
	{
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;

        //Debug.Log(Quaternion.Angle(rot, victoryRotation));
		if (Quaternion.Angle(rot, victoryRotation) <= rotationVariance && Quaternion.Angle(rot, victoryRotation) >= -rotationVariance)
		{
			return (true);
		}
		return (false);
	}
}
