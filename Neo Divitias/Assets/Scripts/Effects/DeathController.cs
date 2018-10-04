using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

    public float duration = 5f;
    public GameObject energy;

    float deathTime = 0;

    private void Start()
    {
        deathTime = Time.time + duration;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; ++i)
        {
            GameObject e = Instantiate(energy, transform.position, Quaternion.identity);
            e.GetComponent<EnergyController>().player = players[i].transform;
        }
    }

    void Update () {
        if (Time.time > deathTime) Destroy(gameObject);
	}
}
