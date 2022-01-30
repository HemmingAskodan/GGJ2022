using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIPlayerChooseCharacter : MonoBehaviour
{
    private ChooseCharacterPositions currentPos = ChooseCharacterPositions.MIDDLE;
    public ChooseCharacterPositions GetCurrentPos()
    {
        return currentPos;
    }
    public void SetCurrentPos(ChooseCharacterPositions pos)
    {
        currentPos = pos;
    }
    private InputDevice[] inputDevices;

    private bool playerControlsEnabled = true;
    // Start is called before the first frame update
    void Awake()
    {
        transform.SetParent(FindObjectOfType<Canvas>().transform);
    }

    public void SetDevices(InputDevice[] inputDevices)
    {
        this.inputDevices = inputDevices;
    }

    private void OnNavigate(InputValue value)
    {
        if(!playerControlsEnabled)
            return;

        float x = value.Get<Vector2>().x;

        if(currentPos == ChooseCharacterPositions.GOOSE && x > 0)
        {
            transform.position = PlayersChooseCharacters.Instance().middleSection.transform.position;
            currentPos = ChooseCharacterPositions.MIDDLE;
        }else

        if(currentPos == ChooseCharacterPositions.MIDDLE && x < 0 && !PlayersChooseCharacters.Instance().gooseSelected)
        {
            transform.position = PlayersChooseCharacters.Instance().gooseSelectSection.transform.position;
            currentPos = ChooseCharacterPositions.GOOSE;
        }else

        if(currentPos == ChooseCharacterPositions.MIDDLE && x > 0 && !PlayersChooseCharacters.Instance().mouseSelected)
        {
            transform.position = PlayersChooseCharacters.Instance().mouseSelectSection.transform.position;
            currentPos = ChooseCharacterPositions.MOUSE;
        }else

        if(currentPos == ChooseCharacterPositions.MOUSE && x < 0)
        {
            transform.position = PlayersChooseCharacters.Instance().middleSection.transform.position;
            currentPos = ChooseCharacterPositions.MIDDLE;
        }
    }

    private void OnSubmit(InputValue value)
    {
        if(!playerControlsEnabled)
            return;

        if(value.Get<float>() == 1)
        {
            if(currentPos == ChooseCharacterPositions.GOOSE)
            {
                ChooseGoose();
            }
            
            if(currentPos == ChooseCharacterPositions.MOUSE)
            {
                ChooseMouse();
            }
        }
    }

    public void ChooseGoose()
    {
        PlayersChooseCharacters.Instance().ChooseGoose(inputDevices);

        playerControlsEnabled = false;
        GetComponent<Image>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;

        PlayersChooseCharacters.Instance().ShouldProceed();
    }
    
    public void ChooseMouse()
    {
        PlayersChooseCharacters.Instance().ChooseMouse(inputDevices);
        
        playerControlsEnabled = false;
        GetComponent<Image>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;

        PlayersChooseCharacters.Instance().ShouldProceed();
    }
}
