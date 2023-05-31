using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //https://blog.devgenius.io/day-10-of-game-dev-how-to-create-a-cooldown-feature-in-unity-4420b0ae9038
    public GameObject dogPrefab;
    private float firerate = 1f;
    private float canFire = -1f;
    
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canFire < Time.time)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canFire = Time.time + firerate;
        }
    }
}
