using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, Resettable {
	
	private Transform platform;
	public Transform[] points;
	public float speed = 1f;
	private int length;
	private int selector;
	public bool moving;
	private Vector3 init_pos;
	Vector3 Tar_pos;
	
	void Start()
	{
		module tp = GetComponent<Transform>().root.GetComponent<module>();
		tp.AddToReset(this);
		init_pos = GetComponent<Transform>().position;
		platform = GetComponent<Transform>();
		length = points.Length;
		selector = 0;
		Tar_pos = points[selector].position;
	}
	
	public void reset()
	{
		moving = false;
		platform.position = init_pos;
	}
	// Update is called once per frame
	void Update () {
		
		if(moving)
		{
			if(selector >= length)
			{
				selector = 0;
			}
					
			Tar_pos = points[selector].position;
			// Debug.Log(selector);
			platform.position = Vector3.MoveTowards(platform.position, Tar_pos, Time.deltaTime * speed);
			
			if(platform.position == Tar_pos)
			{
				// Debug.Log("Target Reached");
				selector++;
			}
			
		}
	}
}
