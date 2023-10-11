using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroys particle system after it is instantiated
        Destroy(gameObject, 5f);
    }
}