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
            activationSound.Play();

            // perform dash
            StartCoroutine(performDash());
        }

    }

    private IEnumerator performDash()
    {
        float wait_until = Time.time + duration[level - 1];
        StartCoroutine(cooldownTimer.abilityActivate(nextActivate, cooldown[level-1]));
        while (Time.time < wait_until)
        {
            playerController.restrictVel = false;
            player.velocity = playerCam.transform.forward * movementForce[level - 1];
            //player.AddForce(playerCam.transform.forward * movementForce[level - 1], ForceMode.Impulse);
            yield return null;
        }

        playerController.restrictVel = true;
    }
}
