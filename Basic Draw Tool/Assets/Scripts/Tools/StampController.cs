using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StampController : MonoBehaviour
{
    public GameObject[] stampPrefabs;
    public float spawnDistance = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !InteractWithUI())
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = spawnDistance;
            GameObject stamp = Instantiate(SelectRandomStamp(), mousePosition, Quaternion.identity);
            stamp.GetComponent<AudioSource>().Play();
            
        }
    }
    GameObject SelectRandomStamp()
    {
        return stampPrefabs[Random.Range(0, stampPrefabs.Length)];
    }
    
    private bool InteractWithUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        return false;
    }
    
}
