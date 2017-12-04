using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update()
	{
		transform.Rotate(0,20*Time.deltaTime,0);
	}
}

