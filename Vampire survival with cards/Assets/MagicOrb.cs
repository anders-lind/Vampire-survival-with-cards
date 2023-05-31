using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    [SerializeField] float speed = 8;


    // Update is called once per frame
    void Update()
    {
        this.transform.position += speed * this.transform.up * Time.deltaTime;
    }
}
