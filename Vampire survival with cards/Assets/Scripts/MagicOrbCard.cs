using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrbCard : Card
{
    [SerializeField] GameObject magicOrbPrefab;
    [SerializeField] float randomSpread = 0.2f;


    void Start()
    {
        base.projectilePrefab = magicOrbPrefab;

        totalUses = 10;
        usesLeft = totalUses;
    }

    void Update()
    {
    }

    public override void use()
    {
        int a = 1;
        GameObject orb = base.shootProjectile(spread : randomSpread);
        // usesLeft -= 1;

        // Vector3 direction = playerController.getPreviousDirection();
        // Vector3 randomDirection = new Vector3(direction.x + Random.Range(-randomSpread, randomSpread), direction.y + Random.Range(-randomSpread, randomSpread));
        
        // GameObject orb = Instantiate(magicOrbPrefab, player.transform.position + randomDirection*0.5f, Quaternion.FromToRotation(Vector3.up, randomDirection));
        
        MagicOrb magicOrb = orb.GetComponent<MagicOrb>();
        magicOrb.speed = 10;
        magicOrb.aliveTime = 1;
        magicOrb.damage = 3;
    }
}