using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    public List<string> TextToDisplay;
    
    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    int dialogue = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[CurrentText];
        
        SparksParticles.Play();

        

        switch (3)
        {
            case 2:
                print("Goodbye, old friend");
                break;
            case 1:
                print("Hello there");
                break;
            default:
                print("Incorrect dialogue value");
                break;
        }

    }

 

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;
        Text.transform.Rotate(0, RotatingSpeed, 0);
        if (TimeToNextText > 3.0f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }


            Text.text = TextToDisplay[CurrentText];
        }
    }

}