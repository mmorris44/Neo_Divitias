using UnityEngine;

public class Shotgun : Weapon {

    public int[] numProjectiles;
    
    public new void Shoot(Camera playerCam) 
    {
        for (int i = 0; i < numProjectiles[level-1]; i++)
        {
            base.Shoot(playerCam);
        }
    }
}
