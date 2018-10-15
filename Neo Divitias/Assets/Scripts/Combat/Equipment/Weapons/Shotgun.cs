using UnityEngine;

// Shotgun weapon
public class Shotgun : Weapon {
    
    public new void Shoot(Camera playerCam) 
    {
        base.Shoot(playerCam);
    }
}
