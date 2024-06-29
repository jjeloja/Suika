using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class SettingsManager : MonoBehaviour
{
    public GameObject EndScreen;

    public void openUI()
    {
        if (!EndScreen.activeSelf)
        {

            this.gameObject.SetActive(true);
            this.transform.SetAsLastSibling();

        }
    }

    public void closeUI()
    {
        this.gameObject.SetActive(false);
    }
}
