﻿using UnityEngine;
using System.Collections;

public class AttackParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach(ParticleSystem ps in GetComponents<ParticleSystem>())
			ps.startDelay = 0.2f;
		foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
			ps.startDelay = 0.2f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(){
		particleSystem.Play (true);
		
	}
}
