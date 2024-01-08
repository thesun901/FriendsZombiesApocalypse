using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject flask;
    SpriteRenderer flaskSR;
    public Sprite[] flaskSprite;

    void Start()
    {
        flaskSR = flask.GetComponent<SpriteRenderer>();
    }
    public void ChangeFlaskSprite()
    {
        flask.SetActive(true);
        flaskSR.sprite = flaskSprite[Random.Range(0, flaskSprite.Length)];
    }

    public void HideFlask()
    {
        flask.SetActive(false);
    }

}
