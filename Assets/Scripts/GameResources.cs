using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResources : MonoBehaviour
{    
    [Header ("Objects")]

    public Text woodText;
    public Text stoneText;
    public Text techText;
    public Text foodText;
    public Text medsText;
    public Text gasolineText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        woodText.text = GameInformations.wood.ToString();
        //stoneText.text = stone.ToString();
        techText.text = GameInformations.tech.ToString();
        foodText.text = GameInformations.food.ToString();
        medsText.text = GameInformations.meds.ToString();
        gasolineText.text = GameInformations.gasoline.ToString();


    }
}
