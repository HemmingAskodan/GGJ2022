using UnityEngine;

public class RotationalSpawn : MonoBehaviour
{
    public Transform spawnFrom;
    public float rotationThreshold = 11.6f;
    public GameObject itemToReveal;

    private void Update()
    {
        var rot = transform.rotation.eulerAngles;
        if (!(rot.z > rotationThreshold))
        {
            return;
        }

        itemToReveal.transform.position = spawnFrom.position;
        itemToReveal.SetActive(true);
        enabled = false;
    }
}