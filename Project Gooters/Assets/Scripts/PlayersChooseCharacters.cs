using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum ChooseCharacterPositions
{
    GOOSE,
    MIDDLE,
    MOUSE
}

public class PlayersChooseCharacters : PlayerInputManager
{
    private static PlayersChooseCharacters instance;
    public Transform gooseSpawnPoint;
    public Transform mouseSpawnPoint;

    public GameObject goosePrefab;
    public GameObject mousePrefab;

    public GameObject gooseSelectSection;
    public GameObject middleSection;
    public GameObject mouseSelectSection;

    public UnityEvent onGameReady;

    private InputDevice[] gooseDevices;
    private InputDevice[] mouseDevices;
    public bool gooseSelected => !gooseSelectSection.GetComponent<Button>().IsInteractable();
    public bool mouseSelected => !mouseSelectSection.GetComponent<Button>().IsInteractable();

    GameObject goose, mouse;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public static PlayersChooseCharacters Instance()
    {
        return instance;
    }

    public InputDevice[] GetGooseDevice()
    {
        return gooseDevices;
    }

    public InputDevice[] GetMouseDevice()
    {
        return mouseDevices;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        // print(playerInput.devices[0]);
        // playerInput.transform.position = middleSection.transform.position;

        var characterChoice = playerInput.GetComponent<UIPlayerChooseCharacter>();
        if (characterChoice != null)
        {
            characterChoice.SetDevices(playerInput.devices.ToArray());
        }
    }

    public void ShouldProceed()
    {
        print("PROCEED");
        if (gooseDevices != null && mouseDevices != null)
        {
            // print("CODE HERE TO DO, WHEN YOU WANT TO PROCEED :)");

            var goose = PlayerInput.Instantiate(goosePrefab, -1, null, -1, gooseDevices);
            goose.transform.position = gooseSpawnPoint.transform.position;
            this.goose = goose.gameObject;
            DontDestroyOnLoad(goose);

            var mouse = PlayerInput.Instantiate(mousePrefab, -1, null, -1, mouseDevices);
            mouse.transform.position = mouseSpawnPoint.transform.position;
            this.mouse = mouse.gameObject;
            DontDestroyOnLoad(mouse);

            onGameReady.Invoke();
        }
        else
        {
            // print("ALL CHARACTERS AREN'T SELECTED YET!");
        }
    }

    public bool PlayersAreMade()
    {
        return goose != null && mouse != null;
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

    private void SetPlayersBackToMiddle(ChooseCharacterPositions pos)
    {
        foreach (var uiPCC in FindObjectsOfType<UIPlayerChooseCharacter>())
        {
            if (uiPCC.GetCurrentPos() == pos)
            {
                uiPCC.transform.position = middleSection.transform.position;
                uiPCC.SetCurrentPos(ChooseCharacterPositions.MIDDLE);
            }
        }
    }
}