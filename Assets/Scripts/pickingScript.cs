using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingScript : MonoBehaviour
{
    /// <summary>
    /// -Script made for picking heroes by clicking mouse on them
    /// -Sript uses object that is separate (is not child) from hero, to avoid lots of bugs associated with multiple colliders layered on hero and its childrens
    /// -This script should be assigned to empty game object with collider as trigger and with rigidbody
    /// </summary>

    public controller controller;
    public BasicHeroScript bhs;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //obcjet is following assigned hero
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    public void OnMouseDown()
    {
        controller.heroId = bhs.id;
    }
}
