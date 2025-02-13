using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    //number of trees made in forest
    public int treeAmount = 10;

    //number of layers on the pyramid
    public int pyramidLayers = 5;


    void InitializeVariables()
    {
       
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer renderer = ground.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;
        ground.transform.position = new UnityEngine.Vector3(0, 0, 0);
    }
    void CreateForest()
    {
        for (int t = 0; t <= 5; t++)
        {
            int treeColor = Random.Range(1, 4);
            float treeXPosition = Random.Range(-2f, -0.3f);
            float treeZPosition = Random.Range(-2f, -0.3f);
            float treeHeight = Random.Range(.25f, 1f);
            float treeWidth = Random.Range(.25f, 1f);
            float treeDepth = Random.Range(.25f, 1f);
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.transform.position = new UnityEngine.Vector3(treeXPosition, (treeHeight * 0.75f), treeZPosition);
            tree.transform.localScale = new UnityEngine.Vector3(treeDepth, treeHeight, treeWidth);
            int currentTreeColor = treeColor;
            if (currentTreeColor == 1)
            {
                Renderer renderer = tree.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard"));
                renderer.material.color = Color.green;
            }
            else if (currentTreeColor == 2)
            {
                Renderer renderer = tree.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard"));
                renderer.material.color = Color.green * 1.5f;
            }
            else
            {
                Renderer renderer = tree.GetComponent<Renderer>();
                renderer.material = new Material(Shader.Find("Standard"));
                renderer.material.color = Color.green * 0.5f;
            }
        }
    }

    void CreatePyramid()
    {
        for(int k = 0; k < 6; k++)
        {
    
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        CreateGround();
        CreateForest();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
