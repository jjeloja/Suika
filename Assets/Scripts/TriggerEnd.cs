using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    private bool end;


    private void OnTriggerEnter2D(Collider2D col)
    {
        end = false;
        Debug.Log(end);
    }
}
