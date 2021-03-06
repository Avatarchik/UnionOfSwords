﻿using UnityEngine;
using System.Collections;

public class Attack_Footman : MonoBehaviour {

	private AudioSource swordSound;
	public ParticleSystem _particleSystem;

	// Use this for initialization
	void Start () {
		foreach(ParticleSystem ps in GetComponents<ParticleSystem>())
			ps.startDelay = 0.2f;
		foreach(ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
			ps.startDelay = 0.2f;
		swordSound = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(AttackInfo attackInfo){
		if(animation != null) {
			animation.Play ("Attack",  PlayMode.StopAll);
		}
		_particleSystem.Play (true);
		swordSound.PlayDelayed (0.2f);
		attackInfo.Target.SendMessage ("ApplyDamage", attackInfo.AttackDamage, SendMessageOptions.DontRequireReceiver);
	}

	void WalkAnimate(){
		animation.Play ("Walk", PlayMode.StopAll);
	}

	void StartAnimation() {
		animation.Play ("Wait", PlayMode.StopAll);
	}
}
