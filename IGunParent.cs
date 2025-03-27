using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunParent
{
    public Transform GetFollowSpawnPoint();

    public void SetGun(Gun gun);

    public Gun GetGun();

    public bool HasGun();

    public void ClearGun();
}
