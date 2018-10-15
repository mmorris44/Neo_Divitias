using UnityEngine;

// Rocket jump movement ability
public class RocketJump : MovementItem {

    // Apply single hard force upwards after setting velocity to zero
    public override void Activate()
    {
        if (nextActivate < Time.time)
        {
            nextActivate = Time.time + cooldown[level-1];

            // Play effects
            StartCoroutine(cooldownTimer.abilityActivate(nextActivate, cooldown[level - 1]));
            activationSound.Play();

            // Perform rocket jump
            player.velocity = Vector3.zero;
            player.AddForce(Vector3.up * movementForce[level - 1], ForceMode.Impulse);
        }
    }
}
