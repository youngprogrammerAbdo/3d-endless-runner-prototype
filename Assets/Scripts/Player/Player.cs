using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBehiviours
{
	protected override void Update()
	{
		base.Update();
	}
	//End Game When enemy hit player
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Obstacle>()!=null) 
		{
			GameManager.Instance.endTheGame();
			Debug.Log("Enemy Hit Me");
		}
	}
}
