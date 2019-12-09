using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroybyBoundary : MonoBehaviour
{
    // Start is called before the first frame {
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
