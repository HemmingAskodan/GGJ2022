using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public ComponentDetection detection;

    private void OnInteract()
    {
        if (!detection.SearchForComponent(out InteractionResponse interaction))
        {
            return;
        }

        interaction.Interact();
    }
}