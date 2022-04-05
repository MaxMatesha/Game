using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[UniqueComponent(tag = "ai.destination")]
public class NavigationEnemy : MonoBehaviour
{

	/// <summary>The object that the AI should move to</summary>
	public Transform target;
	public GameObject pig;
	bool startMove;
	private float timer = 0;
	IAstarAI ai;


	void OnEnable()
	{
		ai = GetComponent<IAstarAI>();

		if (ai != null) ai.onSearchPath += Update;
	}

	void OnDisable()
	{
		if (ai != null) ai.onSearchPath -= Update;
	}

	void Update()
	{
		if (!startMove)
		{
			ai.destination = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
			startMove = true;
		}

		timer += Time.deltaTime;

		if (timer > 4f)
		{
			ai.destination = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
			timer = 0;
		}



	}



}
