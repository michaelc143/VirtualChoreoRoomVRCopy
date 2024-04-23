using System.Collections;
using System.Collections.Generic;
// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;

public class hi : MonoBehaviour
{
    public GameObject model;
    public GameObject studio;
    public void spawn()
    {

        if (model != null) {
            //Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward *2.0f;
            Vector3 spawnPos = studio.transform.position + studio.transform.forward *2.0f;

            GameObject dup = Instantiate(model, spawnPos, Quaternion.identity);
            dup.tag = "Duplicate";
            Debug.Log("the tag of this dup is :" + dup.tag);
        }
    }
}
