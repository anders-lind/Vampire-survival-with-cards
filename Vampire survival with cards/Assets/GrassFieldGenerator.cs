using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFieldGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject grass1, grass2, grass3, grass4;

    [SerializeField]
    int width = 32*4;
    [SerializeField]
    int height = 32*3;
    


    // Start is called before the first frame update
    void Start()
    {
        // Fill the plane with random grass tiles
        List<GameObject> grasss = new List<GameObject>{grass1, grass2, grass3, grass4};
        for (int h = 0; h < height; h++){
            for (int w = 0; w < width; w++){
                int g = Mathf.FloorToInt(Random.Range(0,4));
                Instantiate(grasss[g], new Vector3(-width/2+w, -height/2+h, 0), Quaternion.identity, this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
