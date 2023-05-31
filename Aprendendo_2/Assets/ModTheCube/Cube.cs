using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float changeColorRate = 5.0f;
    public float canChangeColor = -1f;

    void Start()
    {
        transform.position = new Vector3(0, 2, 4);
        transform.localScale = Vector3.one * 10f;
        
        //Material material = Renderer.material;
        
        //material.color = new Color(1f, 1.0f, 0.2f, 1f);
    }
    
    void Update()
    {
        Material material = Renderer.material;
        float randomR = Random.Range(0, 1f);
        float randomB = Random.Range(0, 1f);
        float randomG = Random.Range(0, 1f);

        if (canChangeColor < Time.time)
        {
            material.color = new Color(randomR, randomB, randomG, 1f);
            canChangeColor = Time.time + changeColorRate;
        }
        


        transform.Rotate(2.0f * Time.deltaTime, 5.0f * Time.deltaTime, 3.0f * Time.deltaTime);
    }
} 