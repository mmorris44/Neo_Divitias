using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneCamera : MonoBehaviour {

    public string nextLevel;
    public float cutsceneDuration; // In seconds
    public Transform[] positions;
    public float rotationSpeed = 1f;
    public CutsceneFader cutsceneFader;

    float speed = 0;
    int currentTarget = 1;

	void Start () {
        // Calculate speed
        float distance = 0;
        for (int i = 1; i < positions.Length; ++i)
        {
            distance += (positions[i].position - positions[i - 1].position).magnitude;
        }
        speed = distance / cutsceneDuration;

        // Set position to 0th tranform
        transform.position = positions[0].position;
	}
	
	void Update () {
        // Check if done
        if (currentTarget >= positions.Length){
            StartCoroutine(endScene());
            return;
        }

        float moveDist = speed * Time.deltaTime;

        // Check if at target
        if ((transform.position - positions[currentTarget].position).magnitude < moveDist + 0.0001)
        {
            currentTarget += 1;
            // Check if done
            if (currentTarget >= positions.Length)
            {
                StartCoroutine(endScene());
                return;
            }
        }

        // Lerp towards goal rotation
        Quaternion currentRotation = transform.rotation;
        transform.LookAt(positions[currentTarget]);
        Quaternion goalRotation = transform.rotation;
        transform.rotation = currentRotation;
        transform.rotation = Quaternion.Lerp(currentRotation, goalRotation, rotationSpeed * Time.deltaTime);

        // Move towards goal position
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget].position, moveDist);

        // Skip cutscene
        if (Input.GetButtonDown("Skip"))
        {
            StartCoroutine(endScene());
        }
    }

    public IEnumerator endScene()
    {
        cutsceneFader.FadeOut();

        while (!cutsceneFader.FadedOut()) {

            yield return null;
        }

        SceneManager.LoadSceneAsync(string.Format("Level {0}", GameState.game_level));
    }
}
