using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles objective collection
public class ObjectiveCollect : MonoBehaviour
{
	public GameObject pickupFX;
    GameManager gm;

    // Get gamemanager script
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Check for player collecting objective
    private void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Player"))
		{
            // Handle income
            if (other.GetComponent<Player1Controller>() != null)
            {
                GameState.player_one.money += 30;
                GameState.player_two.money += 20;
            }
            else
            {
                GameState.player_one.money += 20;
                GameState.player_two.money += 30;
            }

            // Play effects
            Vector3 pos = gameObject.transform.position;
            pos.y += 1.5f;
            Instantiate(pickupFX, pos, pickupFX.transform.rotation);

            // Notify gamemanager
			gm.CollectObjective();

			Destroy(gameObject);
		}	
	}
}
