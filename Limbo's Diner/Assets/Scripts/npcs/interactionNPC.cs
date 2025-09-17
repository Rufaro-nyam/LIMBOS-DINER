using UnityEngine;

public class interactionNPC : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1f;
            Physics.overlapSphere(transform.position, interactRange);
        }
    }
}
