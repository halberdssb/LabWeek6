using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DesertScene : MonoBehaviour
{
    private Vector2 sceneDimensions; // size of plane/scene area

    // forest variables
    public int treeAmount = 10; //number of trees made in forest
    private int numForestObjects; // number of objects to make in the forest
    private float minForestObjectSize;
    private float maxForestObjectSize;

    // pyramid variables
    private int numPyramidRows; // how many levels the pyramid will have
    private float spaceBtwCubes; // space buffer between cubes to allow spac ebetween everything
    private Color[] pyramidColors; // colors for each pyramid layer
    private GameObject pyramidParent; // parent object for pyramid cubes
    private Vector3 pyramidCenter; // center position of pyramid


    void Start()
    {
        InitializeVariables();
        CreateGround();
        CreatePyramid();
        CreateForest();
    }

    // sets variables for scene creation
    public void InitializeVariables()
    {
        // set size of scene to 20 x and 20 y
        sceneDimensions = new Vector2(1, 1);

        // get random number of forest objects from 5 to 10
        numForestObjects = Random.Range(5, 11);

        // set pyramid levels to 5
        numPyramidRows = 5;

        // set pyramid colors for each tier
        pyramidColors = new Color[numPyramidRows];
        pyramidColors[0] = Color.red;
        pyramidColors[1] = Color.yellow;
        pyramidColors[2] = Color.green;
        pyramidColors[3] = Color.blue;
        pyramidColors[4] = Color.magenta;

        // create empty parent object
        pyramidParent = new GameObject("PyramidParent");

        // get center point of pyramid
        pyramidCenter = new Vector3(2, 0.5f, -3);
    }

    // creates the ground plane for the scene
    public void CreateGround()
    {
        // create plane
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);

        // set size of plane to ground dimensions - keep y scale the same to have thin ground layer
        ground.transform.localScale = new Vector3(sceneDimensions.x, ground.transform.localScale.y, sceneDimensions.y);

        // set color of plane to red
        SetObjectColor(ground, Color.red);


    }

    public void CreatePyramid()
    {
        // used to offset each layer of pyramid on middle
        float offset = 0;

        // loop through each level of pyramid
        for (int i = numPyramidRows; i > 0; i--)
        {
            // calculate offset for each row - 0.5 is half cube width
            offset = (numPyramidRows - i) * 0.5f;

            // loop through each row in level
            for (int j = i; j > 0; j--)
            {
                // create cube on each space of the row
                for (int k = i; k > 0; k--)
                {
                    // create object
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    // move to desired position and scale down slightly to create offset
                    cube.transform.position = new Vector3(k + offset, 5 - i, j + offset);
                    cube.transform.position += pyramidCenter;
                    cube.transform.localScale *= 0.9f;

                    // set parent of cube to clean up hierarchy
                    cube.transform.parent = pyramidParent.transform;

                    // set color of cube
                    SetObjectColor(cube, pyramidColors[numPyramidRows - i]);
                }
            }
        }
    }

    public void CreateForest()
    {
        for (int t = 0; t <= treeAmount; t++)
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

    // creates a new material of a desired color and sets it to the object passed in
    private void SetObjectColor(GameObject primitive, Color color)
    {
        Renderer renderer = primitive.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = color;
    }
}
