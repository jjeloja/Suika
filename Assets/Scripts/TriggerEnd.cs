using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{

    private bool end;

    void Start()
    {
        end = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        end = !end;
        if (end)
        {
            Debug.Log(end);
        }
    }

}
