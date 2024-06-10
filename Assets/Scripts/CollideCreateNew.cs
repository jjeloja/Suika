using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideCreateNew : MonoBehaviour
{
    public GameObject angel1;
    public GameObject angel2;
    public GameObject angel3;
    public GameObject angel4;
    public GameObject angel5;
    public GameObject angel6;
    public GameObject angel7;
    public GameObject angel8;
    public GameObject angel9;
    public GameObject angel10;
    private GameObject[] angels;
    private string[] angelTags;
    private GameObject currentSonny;
    private int sonnyIndex;
    public static bool destroyed = false;
    public static bool createNew = false;
    private int[] angelScores;
    public static int gameScore;
    public Text scoreText;


    void Start()
    {
        /** instantiates angels as an array of all the provided sonnys */
        /** instantiates angelTags as an array of all the sonny's tags */
        if (angel1 != null && angel2 != null && angel3 != null && angel4 != null & angel5 != null && angel6 != null && angel7 != null && angel8 != null && angel9 != null && angel10 != null)
        {
            angels = new GameObject[10] { angel1, angel2, angel3, angel4, angel5, angel6, angel7, angel8, angel9, angel10 };
            angelTags = new string[10] { angel1.gameObject.tag, angel2.gameObject.tag, angel3.gameObject.tag, angel4.gameObject.tag, angel5.gameObject.tag, angel6.gameObject.tag, angel7.gameObject.tag, angel8.gameObject.tag, angel9.gameObject.tag, angel10.gameObject.tag };
            angelScores = new int[10] { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };
        }

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        currentSonny = this.gameObject;
        sonnyIndex = System.Array.IndexOf(angelTags, currentSonny.gameObject.tag);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /** checks if currSonny has collided with sonny angel of the same type
            and destroys both currSonny and collidedSonny if so */
        if (angelTags[sonnyIndex] == other.gameObject.tag)
        {
            // ensures only one new sonny angel is created in place instead of two
            if (!createNew)
            {
                GameObject newSonny = angels[System.Array.IndexOf(angelTags, currentSonny.gameObject.tag) + 1];
                newSonny = Instantiate(newSonny, currentSonny.gameObject.transform.position, transform.rotation);
                newSonny.gameObject.GetComponent<Collider2D>().enabled = !newSonny.gameObject.GetComponent<Collider2D>().enabled;
                newSonny.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                createNew = true;
                gameScore += angelScores[sonnyIndex + 1];
                scoreText.text = "Score:\n" + gameScore;
            }
            else
            {
                createNew = false;
            }

            Destroy(this.gameObject);
        }
    }
}
