using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnd : MonoBehaviour
{
    private int endInt;
    public Text scoreText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        endInt = 0;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        endInt++;
        if (endInt > 50)
        {
            scoreText.text += "\n\nGame End";
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        endInt = 0;
    }
}
