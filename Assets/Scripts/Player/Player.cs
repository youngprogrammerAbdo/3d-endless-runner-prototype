using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBehiviours
{
	protected override void Update()
	{
		base.Update();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Enemy>()!=null) 
		{
			GameManager.Instance.endTheGame();
			Debug.Log("Enemy Hit Me");
		}
	}
}
