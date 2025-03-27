using UnityEngine;

public class GunSpawner : MonoBehaviour, IGunParent
{
    [SerializeField] private GunSO gunSo;
    [SerializeField] private Transform spawnPoint;

    private Gun gun;

    public void Interact(Player player)
    {
        if (gun == null)
        {
            Transform transformGun = Instantiate(gunSo.prefab, spawnPoint);
            transformGun.GetComponent<Gun>().SetSpawnerParent(this);
        }
        else
        {
            gun.SetSpawnerParent(player);
        }
    }

    public Transform GetFollowSpawnPoint()
    {
        return spawnPoint;
    }

    public void SetGun(Gun gun)
    {
        this.gun = gun;
    }

    public Gun GetGun()
    {
        return gun;
    }

    public bool HasGun()
    {
        return gun != null;
    }

    public void ClearGun()
    {
        gun = null;
    }
}