using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float launchForce;
    [SerializeField] private Transform spawnPoint;

    private PlayerInputs playerInputs;
    private GameObject leaser;

    private void Start()
    {
        playerInputs = GetComponent<PlayerInputs>();
        leaser = Resources.Load<GameObject>("Prefabs/Projectiles/Leaser");
    }

    private void Update()
    {
        if(playerInputs.IsPressingFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject leaserInstance = PoolManager.instance.ReleaseFromThePool(leaser, spawnPoint.position);
        Projectile projectile = leaserInstance.GetComponent<Projectile>();
        
        if(projectile != null)
        {
            projectile.Launch(spawnPoint.up, launchForce);
        }
    }
}
