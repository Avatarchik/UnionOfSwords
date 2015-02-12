﻿using UnityEngine;
using System.Collections;

public class MoveAndAttack : MonoBehaviour 
{
	private GameObject enemyBase;
	private string enemyTag;
	private bool canAttack = true;

	[Range(0f,10f)]
	public float speed = 2;
	[Range(0.5f, 30f)]
	public float AttackRange = 2;
	[Range(0.1f, 10f)]
	public float AttackSpeed = 2;
	[Range(1, 200)]
	public int AttackDamage = 10;

	// Use this for initialization
	void Start () 
	{
		enemyTag = (this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString ()) ? PlayerBase.PlayerNum.PlayerTwo.ToString () : PlayerBase.PlayerNum.PlayerOne.ToString ();


		InvokeRepeating ("ResetAttack", 0, AttackSpeed);
	}

	private void ResetAttack()
	{
		canAttack = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyBase == null)
		{
			if(this.gameObject.tag == PlayerBase.PlayerNum.PlayerOne.ToString())
			{
				//find playerTwo Base
				enemyBase = GameObject.FindGameObjectWithTag("Player2Base");
			}
			else if(this.gameObject.tag == PlayerBase.PlayerNum.PlayerTwo.ToString())
			{
				//find playerOne Base
				enemyBase = GameObject.FindGameObjectWithTag("Player1Base");
			}
			if(enemyBase == null)
				return;
		}

		// if there's any targetable object in range, stop and call attack method
		Collider target = GetClosestTargetable ();
		if(target != null)
		{
			if(canAttack == true)
			{
				//call attack(target)		
				Debug.Log("Attack");
				target.SendMessage("ApplyDamage", AttackDamage, SendMessageOptions.DontRequireReceiver);
				canAttack = false;
			}
		}
		// move towards enemy base
		else 
		{
		    Vector3 currentPos = transform.position;
			Vector3 enemyBasePos = enemyBase.transform.position;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (currentPos, enemyBasePos, step);
		}
	}

	private Collider GetClosestTargetable()
	{
		float smallestDistance = float.MaxValue;
		Collider closestTarget = null;
		Collider[] cols = Physics.OverlapSphere(transform.position, AttackRange);
		foreach (Collider col in cols)
		{
			if (col && ( col.tag == enemyTag || col.tag == enemyBase.tag))
			{ 
				float distance = Vector3.Distance(transform.position, col.transform.position);
				if(distance<smallestDistance)
				{
					smallestDistance = distance;
					closestTarget = col;					
				}
			}	
		}
		return closestTarget;
	}
}
