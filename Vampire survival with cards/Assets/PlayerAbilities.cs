using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] GameObject magicOrb;
    [SerializeField] List<GameObject> magicOrbs = new List<GameObject>();


    public void useAbility(string ability)
    {
        if (ability == "magic orb"){
            print(ability);
            magicOrbs.Add(Instantiate(magicOrb, this.transform.position + this.transform.up*0.5f, this.transform.rotation));
        }
    }
}
