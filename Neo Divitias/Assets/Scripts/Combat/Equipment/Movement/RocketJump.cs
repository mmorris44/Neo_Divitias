using UnityEngine;

public class RocketJump : MovementItem {

    public override void Activate()
    {
        if (nextActivate < Time.time)
        {
            nextActivate = Time.time + cooldown[level-1];

            // play effects
            StartCoroutine(cooldownTimer.abilityActivate(nextActivate, cooldown[level - 1]));
            activationSound.Play();

            // perform rocket jump
            player.velocity = Vector3.zero;
            player.AddForce(Vector3.up * movementForce[level - 1], ForceMode.Impulse);
        }
    }
}
