using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage death animation of an enemy and spawn energy objects to fly back to them
public class DeathController : MonoBehaviour {

    public float duration = 5f;
    public GameObject energy;

    float deathTime = 0;

    private void Start()
    {
        // Find players
        deathTime = Time.time + duration;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; ++i)
        {
            // Send energy flying back to players
            GameObject e = Instantiate(energy, transform.position, Quaternion.identity);
            e.GetComponent<EnergyController>().player = players[i].transform;
        }
    }

    // Check if time for death animation has expired
    void Update () {
        if (Time.time > deathTime) Destroy(gameObject);
	}
}
