using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollect : MonoBehaviour
{
	public GameObject pickupFX;
	
	private void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Player"))
		{
			Instantiate(pickupFX, gameObject.transform.position, Quaternion.identity);
			GameManager.CollectObjective();
			Destroy(gameObject);
		}	
	}
}
