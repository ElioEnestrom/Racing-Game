using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}
