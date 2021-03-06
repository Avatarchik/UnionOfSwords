﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

	public PlayerBase.PlayerNum player;

	Text resource;
	public static int currentResource_P1 = 20;
	public static int currentResource_P2 = 20;
	
	// Use this for initialization
	void Start () {
		resource = GetComponent<Text> ();
		resource.text = "Resource : " + 20;
		InvokeRepeating ("income", 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		if(player == PlayerBase.PlayerNum.PlayerOne) {
			resource.text = "Resource : " + currentResource_P1;
		}else if(player == PlayerBase.PlayerNum.PlayerTwo)
		{
			resource.text = "Resource : " + currentResource_P2;
		}		
	}
	
	private void income() {
		currentResource_P1 += 2;
		currentResource_P2 += 2;
	}
}

