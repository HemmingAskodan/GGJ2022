using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum ChooseCharacterPositions{GOOSE,MIDDLE,MOUSE}
public class PlayersChooseCharacters : PlayerInputManager
{
    public GameObject goosePrefab;
    public GameObject mousePrefab;
    private static PlayersChooseCharacters instance;
    public static PlayersChooseCharacters Instance(){
        return instance;
    }

    public GameObject gooseSelectSection;
    public bool gooseSelected => !gooseSelectSection.GetComponent<Button>().IsInteractable();
    public GameObject middleSection;
    public GameObject mouseSelectSection;
    public bool mouseSelected => !mouseSelectSection.GetComponent<Button>().IsInteractable();

    private InputDevice gooseDevice;
    public InputDevice GetGooseDevice()
    {
        return gooseDevice;
    }
    private InputDevice mouseDevice;
    public InputDevice GetMouseDevice()
    {
        return mouseDevice;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnPlayerJoined(PlayerInput playerInput) {
        // print(playerInput.devices[0]);
        playerInput.transform.position = middleSection.transform.position;
        playerInput.GetComponent<UIPlayerChooseCharacter>().SetDevice(playerInput.devices[0]);
    }

    public void ShouldProceed()
    {
        if(gooseDevice != null && mouseDevice != null)
        {
            print("CODE HERE TO DO, WHEN YOU WANT TO PROCEED :)");

            PlayerInput.Instantiate(goosePrefab, -1, null, -1, gooseDevice);
            PlayerInput.Instantiate(mousePrefab, -1, null, -1, mouseDevice);
        }
        else
        {
            print("ALL CHARACTERS AREN'T SELECTED YET!");
        }
    }

    public void ChooseGoose(InputDevice device)
    {
        gooseDevice = device;
        SetPlayersBackToMiddle(ChooseCharacterPositions.GOOSE);
        gooseSelectSection.GetComponent<Button>().interactable = false;
    }
    public void ChooseMouse(InputDevice device)
    {
        mouseDevice = device;
        SetPlayersBackToMiddle(ChooseCharacterPositions.MOUSE);
        mouseSelectSection.GetComponent<Button>().interactable = false;
    }

    void SetPlayersBackToMiddle(ChooseCharacterPositions pos)
    {
        foreach(UIPlayerChooseCharacter uiPCC in FindObjectsOfType<UIPlayerChooseCharacter>())
        {
            if(uiPCC.GetCurrentPos() == pos)
            {
                uiPCC.transform.position = middleSection.transform.position;
                uiPCC.SetCurrentPos(ChooseCharacterPositions.MIDDLE);
            }
        }
    }

    void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
