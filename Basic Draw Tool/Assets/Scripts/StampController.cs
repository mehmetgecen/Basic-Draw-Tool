using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampController : MonoBehaviour
{
    public GameObject[] stampPrefabs;
    public float spawnDistance = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = spawnDistance;
            Instantiate(SelectRandomStamp(), mousePosition, Quaternion.identity);
        }
    }
    GameObject SelectRandomStamp()
    {
        return stampPrefabs[Random.Range(0, stampPrefabs.Length)];
    }
    
}
