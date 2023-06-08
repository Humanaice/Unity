using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public TextMeshProUGUI counterText;
    public string color;
    private int Count = 0;
    [SerializeField] Material[] material;
    Renderer rend;
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer[] mesh;

    //int numOfChilds = tran

    private void Start()
    {
        Count = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            color = "Red";
            //rend.sharedMaterial = material[0];
            ChangeObjectsMaterials(0);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            color = "Yellow";
            //rend.sharedMaterial = material[1];
            ChangeObjectsMaterials(1);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            color = "Blue";
            //rend.sharedMaterial = material[2];
            ChangeObjectsMaterials(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(color))
        {
            Count += 1;
            counterText.text = "Count : " + Count + " Balls";
        }
    }
    void ChangeObjectsMaterials(int numbColor)
    {
        transform.Find("Cube (1)").GetComponent<Renderer>().sharedMaterial = material[numbColor];
        transform.Find("Cube (2)").GetComponent<Renderer>().sharedMaterial = material[numbColor];
        transform.Find("Cube (3)").GetComponent<Renderer>().sharedMaterial = material[numbColor];
    }


}
