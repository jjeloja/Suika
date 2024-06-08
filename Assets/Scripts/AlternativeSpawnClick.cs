using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
  private string[] angelTags;
  public static bool holdingSonny = true;
  public static GameObject currSonny;

  void Start()
  {
    /** instantiates angels as an array of all the provided sonnys */
    /** instantiates angelTags as an array of all the sonny's tags */
    if (angel1 != null && angel2 != null && angel3 != null && angel4 != null & angel5 != null && angel6 != null && angel7 != null && angel8 != null && angel9 != null && angel10 != null)
    {
      angels = new GameObject[10] { angel1, angel2, angel3, angel4, angel5, angel6, angel7, angel8, angel9, angel10 };
      angelTags = new string[10] { angel1.gameObject.tag, angel2.gameObject.tag, angel3.gameObject.tag, angel4.gameObject.tag, angel5.gameObject.tag, angel6.gameObject.tag, angel7.gameObject.tag, angel8.gameObject.tag, angel9.gameObject.tag, angel10.gameObject.tag };
    }

    currSonny = this.transform.GetChild(0).gameObject;
  }

  // Update is called once per frame
  void Update()
  {
    /** updates Wings position to follow mousePos.x  */
    Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 390, 0);
    transform.position = mousePos;

    /** drops current sonny */
    if (Input.GetButtonDown("Fire1") && holdingSonny)
    {
      currSonny.transform.parent = null;
      currSonny.gameObject.GetComponent<Collider2D>().enabled = !currSonny.gameObject.GetComponent<Collider2D>().enabled;
      currSonny.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      currSonny.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
      holdingSonny = false;
      StartCoroutine(SpawnSonny());
    }
  }

  IEnumerator SpawnSonny()
  {
    yield return new WaitForSeconds(1);

    /** updates Wings position to follow mousePos.x  */
    Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 390, 0);

    gameObject.transform.position = mousePos;
    GameObject newSonny = angels[Random.Range(0, 3)];
    newSonny = Instantiate(newSonny, mousePos, transform.rotation);
    newSonny.transform.SetParent(this.transform);
    currSonny = newSonny;
    holdingSonny = true;
  }
}
