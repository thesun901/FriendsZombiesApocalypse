using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiding_top : MonoBehaviour
{
    public Transform[] players;
    SpriteRenderer sr;
    public int distance = 40;
    public bool isInside;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(players[1].position, this.transform.position) > distance && Vector2.Distance(players[2].position, this.transform.position) > distance && Vector2.Distance(players[3].position, this.transform.position) > distance && Vector2.Distance(players[4].position, this.transform.position) > distance && Vector2.Distance(players[5].position, this.transform.position) > distance)
        {
            sr.color = new Color(1, 1, 1, sr.color.a + Time.deltaTime);
            isInside = false;

            if (sr.color.a >= 1)
                sr.color = new Color(1, 1, 1, 1);
        }

        if (Vector2.Distance(players[1].position, this.transform.position) < distance || Vector2.Distance(players[2].position, this.transform.position) < distance || Vector2.Distance(players[3].position, this.transform.position) < distance || Vector2.Distance(players[4].position, this.transform.position) < distance || Vector2.Distance(players[5].position, this.transform.position) < distance)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - Time.deltaTime);
            isInside = true;

            if (sr.color.a <= 0)
                sr.color = new Color(1, 1, 1, 0);
        }
    }


}
