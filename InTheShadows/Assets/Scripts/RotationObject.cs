using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
	public float positionVariance = 0.0005f;
	public float rotationVariance = 0.0005f;
	public float rotationXScrambleMin = 0f;
	public float rotationXScrambleMax = 0f;
	public float rotationYScrambleMin = 25f;
	public float rotationYScrambleMax = 125f;

	Vector3 victoryPosition;
	Quaternion startingRotation;
	Quaternion victoryRotation;

	void Awake()
	{
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
		transform.RotateAround(transform.position, new Vector3(1, 0, 0), Random.Range(rotationXScrambleMin, rotationXScrambleMax));
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

		if ((Quaternion.Dot(rot, victoryRotation) > 1f - rotationVariance) && Vector3.Dot(pos, victoryPosition) > 1f - positionVariance)
		{
			return (true);
		}
		return (false);
	}
}
