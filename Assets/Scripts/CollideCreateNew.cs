using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCreateNew : MonoBehaviour
{
    public GameObject angel1;
    public GameObject angel2;
    public GameObject angel3;
    public GameObject angel4;
    public GameObject angel5;
    public GameObject angel6;
    private GameObject[] angels;
    private string[] angelTags;
    private GameObject currSonny;
    private int sonnyIndex;

    void Start()
    {
        /** instantiates angels as an array of all the provided sonnys */
        /** instantiates angelTags as an array of all the sonny's tags */
        if (angel1 != null && angel2 != null && angel3 != null && angel4 != null & angel5 != null && angel6 != null)
        {
            angels = new GameObject[6] { angel1, angel2, angel3, angel4, angel5, angel6 };
            angelTags = new string[6] { angel1.gameObject.tag, angel2.gameObject.tag, angel3.gameObject.tag, angel4.gameObject.tag, angel5.gameObject.tag, angel6.gameObject.tag };
        }

        currSonny = this.gameObject;
        sonnyIndex = System.Array.IndexOf(angelTags, currSonny.gameObject.tag); ;
        Debug.Log("Slay");

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /** checks if currSonny has collided with sonny angel of the same type
            and destroys both currSonny and collidedSonny if so */
        if (angelTags[sonnyIndex] == other.gameObject.tag)
        {
            Destroy(other.gameObject);

            GetComponent<SpawnClick>().holdingSonny = false;
            GetComponent<CollisionCheck>().collided = false;
            Destroy(gameObject);
        }
    }
}
