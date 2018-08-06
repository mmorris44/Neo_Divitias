using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    AudioSource[] songs;

	// Use this for initialization
	void Start () {
        StartCoroutine(playMusic());
	}

    private IEnumerator playMusic ()
    {
        songs = GetComponents<AudioSource>();

        System.Random random = new System.Random();

        while (true)
        {
            // Create order
            List<int> numbers = new List<int>();
            List<int> order = new List<int>();

            for (int i = 0; i < songs.Length; ++i)
            {
                numbers.Add(i);
            }

            int total = numbers.Count;
            for (int i = 0; i < total; ++i)
            {
                int index = random.Next(0, numbers.Count);
                order.Add(numbers[index]);
                numbers.RemoveAt(index);
            }

            // Play in order
            for (int i = 0; i < order.Count; ++i)
            {
                songs[order[i]].Play();
                yield return new WaitForSeconds(songs[order[i]].clip.length);
            }
        }
    }
}
