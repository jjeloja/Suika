using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternativeSpawnClick : MonoBehaviour
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
  public float launchVelocity = 700f;
  private GameObject[] angels;
  public static bool holdingSonny;
  public static GameObject currSonny;
  public static GameObject newSonny;
  public GameObject EndScreen;

  void Start()
  {
    holdingSonny = true;

    /** instantiates angels as an array of all the provided sonnys */
    /** instantiates angelTags as an array of all the sonny's tags */
    if (angel1 != null && angel2 != null && angel3 != null && angel4 != null & angel5 != null && angel6 != null && angel7 != null && angel8 != null && angel9 != null && angel10 != null)
    {
      angels = new GameObject[10] { angel1, angel2, angel3, angel4, angel5, angel6, angel7, angel8, angel9, angel10 };
    }

    currSonny = this.transform.GetChild(0).gameObject;
    newSonny = angels[Random.Range(0, 4)];
    newSonny = Instantiate(newSonny, GameObject.Find("NextSonnyBG").transform.position, transform.rotation);
    newSonny.transform.SetParent(GameObject.Find("Canvas").transform);
  }

  // Update is called once per frame
  void Update()
  {
    if (EndScreen.activeSelf)
    {
      EndScreen.transform.SetAsLastSibling();
      EndScreen.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Score:\n" + CollideCreateNew.gameScore;
    }


    Debug.Log(GameObject.Find("NewContainer").transform.position.x);
    Debug.Log(GameObject.Find("NewContainer").GetComponent<SpriteRenderer>().sprite.rect.width);
    /** updates Wings position to follow mousePos.x  */
    Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 390, 0);
    if (currSonny == null)
    {
      if (mousePos.x < 345)
      {
        mousePos.x = 345;
      }
      else if (mousePos.x > 605)
      {
        mousePos.x = 605;
      }
    }
    // GameObject.Find("NewContainer").GetComponent<RectTransform>().anchoredPosition.x - (GameObject.Find("NewContainer").GetComponent<RectTransform>().sizeDelta.x * 0.5f))
    else if (mousePos.x < (int)(currSonny.GetComponent<Renderer>().bounds.size.x / 2f) + GameObject.Find("LeftEdge").transform.position.x)
    {
      mousePos.x = (int)(currSonny.GetComponent<Renderer>().bounds.size.x / 2f) + GameObject.Find("LeftEdge").transform.position.x;
    }
    else if (mousePos.x > GameObject.Find("RightEdge").transform.position.x - (int)(currSonny.GetComponent<Renderer>().bounds.size.x / 2f))
    {
      mousePos.x = GameObject.Find("RightEdge").transform.position.x - (int)(currSonny.GetComponent<Renderer>().bounds.size.x / 2f);
    }
    transform.position = mousePos;

    /** drops current sonny */
    if ((Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) && holdingSonny)
    {
      currSonny.transform.SetParent(GameObject.Find("Canvas").transform);
      currSonny.gameObject.GetComponent<Collider2D>().enabled = !currSonny.gameObject.GetComponent<Collider2D>().enabled;
      currSonny.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      currSonny.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
      holdingSonny = false;
      if (!TriggerEnd.end)
      {
        StartCoroutine(SpawnSonny());
      }

    }
  }

  IEnumerator SpawnSonny()
  {
    yield return new WaitForSeconds(1);

    /** updates Wings position to follow mousePos.x  */
    Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 390, 0);
    if (newSonny == null)
    {
      if (mousePos.x < 345)
      {
        mousePos.x = 345;
      }
      else if (mousePos.x > 605)
      {
        mousePos.x = 605;
      }
    }
    else if (mousePos.x < (int)(newSonny.GetComponent<Renderer>().bounds.size.x / 2f) + GameObject.Find("LeftEdge").transform.position.x)
    {
      mousePos.x = (int)(newSonny.GetComponent<Renderer>().bounds.size.x / 2f) + GameObject.Find("LeftEdge").transform.position.x;
    }
    else if (mousePos.x > GameObject.Find("RightEdge").transform.position.x - (int)(newSonny.GetComponent<Renderer>().bounds.size.x / 2f))
    {
      mousePos.x = GameObject.Find("RightEdge").transform.position.x - (int)(newSonny.GetComponent<Renderer>().bounds.size.x / 2f);
    }

    transform.position = mousePos;


    /** changes newSonny angel to be at wings */
    gameObject.transform.position = mousePos;
    newSonny.transform.position = mousePos;
    newSonny.transform.SetParent(this.transform);
    currSonny = newSonny;


    /** updated newSonny to create a new angel at side location */
    newSonny = angels[Random.Range(0, 4)];
    newSonny = Instantiate(newSonny, GameObject.Find("NextSonnyBG").transform.position, transform.rotation);
    newSonny.transform.SetParent(GameObject.Find("Canvas").transform);
    holdingSonny = true;
  }
}
