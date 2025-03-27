using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunSO _gunSo;

    private IGunParent gunParent;

    public GunSO GetGunSo()
    {
        return _gunSo;
    }

    public void SetSpawnerParent(IGunParent iGunParent)
    {
        if (iGunParent!=null)
        {
            iGunParent.ClearGun();
        }
        this.gunParent = iGunParent;
        iGunParent.SetGun(this);
        
        transform.parent = this.gunParent.GetFollowSpawnPoint();
        transform.localPosition = Vector3.zero;
    }

    public IGunParent GetSpawnerParent()
    {
        return gunParent;
    }
}