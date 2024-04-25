using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserDecider : MonoBehaviour
{
    public GameObject eraser;
    
    //set eraser to brush mode
    public void SetBrushMode()
    {
        eraser.SetActive(false);
        eraser.GetComponent<LineFinder>().enabled = false;
        eraser.GetComponent<LineGenerator>().enabled = true;
    }
    
    //set eraser to touch mode
    public void SetTouchMode()
    {
        eraser.GetComponent<LineFinder>().enabled = true;
        eraser.GetComponent<LineGenerator>().enabled = false;
    }
}
