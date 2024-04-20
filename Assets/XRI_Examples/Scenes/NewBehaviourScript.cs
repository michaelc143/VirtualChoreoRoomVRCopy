using System.Collections;
using System.Collections.Generic;
// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject model;
    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            Instantiate(model, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }
    }
}
