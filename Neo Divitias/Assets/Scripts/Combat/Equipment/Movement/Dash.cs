using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementItem {

    public float[] duration;
    public PlayerController playerController;


    public override void Activate()
    {
        if (nextActivate < Time.time)
        {
            nextActivate = Time.time + cooldown[level-1];
            //activationSound.Play();

            // perform dash
            StartCoroutine(performDash());
        }

    }

    private IEnumerator performDash()
    {
        float wait_until = Time.time + duration[level - 1];
        playerController.restrictVel = false;
        Debug.Log("Un-restricting");
        player.AddForce(playerCam.transform.forward * movementForce[level - 1], ForceMode.Impulse);
        yield return new WaitForSeconds(duration[level - 1]);

        Debug.Log(Time.time + " " + wait_until + " Re-restricting");
        playerController.restrictVel = true;
    }
}
