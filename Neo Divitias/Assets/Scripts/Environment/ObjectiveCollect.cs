using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCollect : MonoBehaviour
{
	public GameObject pickupFX;
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Player"))
		{
            // handle income
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

            Vector3 pos = gameObject.transform.position;
            pos.y += 1.5f;
            Instantiate(pickupFX, pos, pickupFX.transform.rotation);
			gm.CollectObjective();
			Destroy(gameObject);
		}	
	}
}
