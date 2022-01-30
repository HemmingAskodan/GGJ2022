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

    private InputDevice[] gooseDevices;
    public InputDevice[] GetGooseDevice()
    {
        return gooseDevices;
    }
    private InputDevice[] mouseDevices;
    public InputDevice[] GetMouseDevice()
    {
        return mouseDevices;
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
        playerInput.GetComponent<UIPlayerChooseCharacter>().SetDevices(playerInput.devices.ToArray());
    }

    public void ShouldProceed()
    {
        if(gooseDevices != null && mouseDevices != null)
        {
            print("CODE HERE TO DO, WHEN YOU WANT TO PROCEED :)");

            PlayerInput.Instantiate(goosePrefab, -1, null, -1, gooseDevices);
            PlayerInput.Instantiate(mousePrefab, -1, null, -1, mouseDevices);
        }
        else
        {
            print("ALL CHARACTERS AREN'T SELECTED YET!");
        }
    }

    public void ChooseGoose(InputDevice[] devices)
    {
        gooseDevices = devices;
        SetPlayersBackToMiddle(ChooseCharacterPositions.GOOSE);
        gooseSelectSection.GetComponent<Button>().interactable = false;
    }
    public void ChooseMouse(InputDevice[] devices)
    {
        mouseDevices = devices;
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
