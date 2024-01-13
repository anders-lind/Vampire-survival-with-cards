using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMagicOrb : Card
{
    [SerializeField] GameObject magicOrbPrefab;
    [SerializeField] float randomSpread = 0.2f;
    [SerializeField] List<GameObject> magicOrbs = new List<GameObject>();


    void Start()
    {
        totalUses = 10;
        usesLeft = totalUses;
    }

    void Update()
    {
    }

    public override void use()
    {
        usesLeft -= 1;

        Vector3 direction = playerController.getPreviousDirection();
        Vector3 randomDirection = new Vector3(direction.x + Random.Range(-randomSpread, randomSpread), direction.y + Random.Range(-randomSpread, randomSpread));
        
        GameObject orb = Instantiate(magicOrbPrefab, player.transform.position + randomDirection*0.5f, Quaternion.FromToRotation(Vector3.up, randomDirection));
        
        MagicOrb magicOrb = orb.GetComponent<MagicOrb>();
        magicOrb.speed = 10;
        magicOrb.aliveTime = 1;
        magicOrb.damage = 3;
    }
}