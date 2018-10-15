using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dash movement ability
public class Dash : MovementItem {

    public float[] duration;
    public PlayerController playerController;

    public override void Activate()
    {
        // If off cooldown
        if (nextActivate < Time.time)
        {
            nextActivate = Time.time + cooldown[level-1];
            
            // Play effects
            activationSound.Play();
            StartCoroutine(cooldownTimer.abilityActivate(nextActivate, cooldown[level - 1]));

            // Perform dash
            StartCoroutine(performDash());
        }
    }

    // Apply constant force over time
    private IEnumerator performDash()
    {
        float wait_until = Time.time + duration[level - 1];
        while (Time.time < wait_until)
        {
            playerController.restrictVel = false; // Override velocity limits for duration of dash

            player.velocity = playerCam.transform.forward * movementForce[level - 1];
            player.velocity = new Vector3(player.velocity.x, player.velocity.y * 0.3f, player.velocity.z);
            yield return null;
        }

        playerController.restrictVel = true;
    }
}
