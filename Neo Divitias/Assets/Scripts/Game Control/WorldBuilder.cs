using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour {

    public float maxRadius = 100f,
        minOutwardStep = 10f,
        maxOutwardStep = 30f,
        minSphericalGap = 5f,
        maxSphericalGap = 20f;
    public int cubeProbability = 3;

    public GameObject pillar,
        cuboBlue,
        cuboOrange,
        sphere,
        capsule;

    public Material[] materials;

    GameObject[] cubes = new GameObject[2];
    GameObject[] junk = new GameObject[2];

    void Start () {
        // Set prefabs
        cubes[0] = cuboBlue;
        cubes[1] = cuboOrange;
        junk[0] = sphere;
        junk[1] = capsule;

        // Move out through circles
        float radius = 0;
        bool pillarCircle = true;

        while (radius < maxRadius)
        {
            radius += getRandomFloat(minOutwardStep, maxOutwardStep);

            // Move around circle
            float angle = 0f;
            while (angle < 2 * Mathf.PI)
            {
                Vector3 position = cartesianFromPolar(radius, angle);
                GameObject obj;
                if (pillarCircle)
                {
                    // Create object
                    obj = pillar;
                    Instantiate(obj, position, Quaternion.identity);
                } else
                {
                    int rand = getRandomInt(0, cubeProbability);
                    if (rand == 0)
                    {
                        // Create object
                        obj = getRandomJunk();
                        GameObject junk = Instantiate(obj, position, Quaternion.identity);
                        junk.GetComponentInChildren<Renderer>().material = getRandomMaterial();
                    }
                    else
                    {
                        // Create object
                        obj = getRandomCube();
                        Instantiate(obj, position, Quaternion.identity);
                    }
                }

                angle += getRandomAngleStep(minSphericalGap, maxSphericalGap, radius);
            }

            pillarCircle = !pillarCircle;
        }
	}

    Vector3 cartesianFromPolar (float radius, float angle)
    {
        return new Vector3(radius * Mathf.Sin(angle), 0, radius * Mathf.Cos(angle));
    }

    float getRandomAngleStep (float minArcLength, float maxArcLength, float radius)
    {
        return getRandomFloat(minArcLength / radius, maxArcLength / radius);
    }

    // min inclusive, max inclusive
    float getRandomFloat (float min, float max)
    {
        return Random.Range(min, max);
    }

    // min inclusive, max exclusive
    int getRandomInt (int min, int max)
    {
        return min + (int)(Random.value * (max - min));
    }

    GameObject getRandomCube ()
    {
        return cubes[getRandomInt(0, cubes.Length)];
    }

    GameObject getRandomJunk ()
    {
        return junk[getRandomInt(0, junk.Length)];
    }

    Material getRandomMaterial ()
    {
        return materials[getRandomInt(0, materials.Length)];
    }
}
