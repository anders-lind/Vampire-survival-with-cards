using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCard : Card
{
    [SerializeField] GameObject fireballPrefab;


    // Start is called before the first frame update
    void Start()
    {
        base.projectilePrefab = fireballPrefab;

        totalUses = 2;
        usesLeft = totalUses;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void use()
    {
        GameObject orb = base.shootProjectile();
        
        FireBall fireball = orb.GetComponent<FireBall>();
        fireball.speed = 20;
        fireball.aliveTime = 0.5f;
        fireball.damage = 10;
    }
}
