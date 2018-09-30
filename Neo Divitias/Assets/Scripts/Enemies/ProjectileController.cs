using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed = 1f;
    public int damage = 1;
    public float duration = 10f;

    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Time.time > startTime + duration)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        DamageableObject dobj = other.GetComponent<DamageableObject>();

        if (dobj)
        {
            dobj.damage(damage);
        }

        Destroy(gameObject);
    }
}
