using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnd : MonoBehaviour
{
    public static bool end;
    private int endInt;
    public GameObject EndScreen;

    void Start()
    {
        end = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        endInt = 0;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        endInt++;
        if (endInt > 50 && !end)
        {
            end = true;
            EndScreen.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Score: " + CollideCreateNew.gameScore;
            EndScreen.transform.SetAsLastSibling();
            EndScreen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        endInt = 0;
    }
}
