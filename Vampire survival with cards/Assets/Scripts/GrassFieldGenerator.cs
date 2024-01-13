using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class GrassFieldGenerator : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] GameObject grass1, grass2, grass3, grass4;
    [SerializeField] int width = 32*4;
    [SerializeField] int height = 32*3;
    

    List<GameObject> grass_types = new();
    List<GameObject> grass_field = new();

    // Start is called before the first frame update
    void Start()
    {
        grass_types = new List<GameObject>{grass1, grass2, grass3, grass4};

        

        // Fill the plane with random grass tiles
        for (int h = 0; h < height; h++){
            for (int w = 0; w < width; w++){
                int g = Random.Range(0,4);
                GameObject grass = Instantiate(grass_types[g], new Vector3(-width/2+w, -height/2+h, 0), Quaternion.identity, this.transform);
                grass_field.Add(grass);

                // Make grass not-clickable
                SceneVisibilityManager.instance.DisablePicking(grass, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (GameObject grass in grass_field){
        //     if ((grass.transform.position - camera.transform.position).magnitude < 10){

        //     }
        // }
    }
}
