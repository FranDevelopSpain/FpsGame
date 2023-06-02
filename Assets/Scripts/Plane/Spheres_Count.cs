
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres_Count : MonoBehaviour
{
    public  int count = 0;
    void Start()
    {
        Debug.Log("Esferas recogidas: " + count); 
    }
    void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Sphere")) 
        {
            count += 1;
            Debug.Log("Esferas recogidas: " + count);
            Destroy(other.gameObject);
        }      
    }
}

