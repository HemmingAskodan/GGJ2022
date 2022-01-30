using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayersChooseCharacters.Instance().PlayersAreMade())
        {
            GameObject.FindGameObjectWithTag("Goose").GetComponent<PlayerMovement>().CustomEnable(true);
            GameObject.FindGameObjectWithTag("Mouse").GetComponent<PlayerMovement>().CustomEnable(true);
            GameObject.FindGameObjectWithTag("Goose").transform.position = PlayersChooseCharacters.Instance().gooseSpawnPoint.position;
            GameObject.FindGameObjectWithTag("Mouse").transform.position = PlayersChooseCharacters.Instance().mouseSpawnPoint.position;
        }
    }
}
