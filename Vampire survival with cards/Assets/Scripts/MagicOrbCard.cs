using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrbCard : Card
{
    [SerializeField] GameObject magicOrbPrefab;
    [SerializeField] float randomSpread = 0.15f;


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
        GameObject orb = base.shootProjectile(spread: randomSpread);
        
        MagicOrb magicOrb = orb.GetComponent<MagicOrb>();
        magicOrb.speed = 10;
        magicOrb.aliveTime = 1;
        magicOrb.damage = 3;
    }
}