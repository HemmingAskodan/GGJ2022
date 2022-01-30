using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayersOnStart : MonoBehaviour
{
    public Vector2 spawnGooseLocation;
    public Vector2 spawnMouseLocation;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gooseGO = GameObject.FindGameObjectWithTag("Goose");
        gooseGO.transform.position = spawnGooseLocation;
        gooseGO.GetComponent<PlayerMovement>().CustomEnable(true);

        GameObject mouseGO = GameObject.FindGameObjectWithTag("Mouse");
        mouseGO.transform.position = spawnMouseLocation;
        mouseGO.GetComponent<PlayerMovement>().CustomEnable(true);
    }
}
