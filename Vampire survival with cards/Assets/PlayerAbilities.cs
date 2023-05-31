using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] GameObject magicOrb;
    [SerializeField] List<GameObject> magicOrbs = new List<GameObject>();
    [SerializeField] float randomSpread = 0.3f;


    public void useAbility(string ability, Vector3 direction)
    {
        if (ability == "magic orb"){
            Vector3 randomDirection = new Vector3(direction.x + Random.Range(-randomSpread, randomSpread), direction.y + Random.Range(-randomSpread, randomSpread));
            magicOrbs.Add(Instantiate(magicOrb, this.transform.position + randomDirection*0.5f, Quaternion.FromToRotation(Vector3.up, randomDirection)));
        }
    }
}