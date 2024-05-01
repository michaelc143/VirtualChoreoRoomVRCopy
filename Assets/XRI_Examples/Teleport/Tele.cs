using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tele : MonoBehaviour
{
    public Transform teleportDestination;

    private void Start()
    {
        var interactor = GetComponent<XRBaseInteractor>();
        if (interactor != null)
        {
            interactor.selectEntered.AddListener(HandleSelectEntered);
        }
    }

    private void HandleSelectEntered(SelectEnterEventArgs args)
    {
        if (teleportDestination != null)
        {
            args.interactor.transform.root.position = teleportDestination.position;  // Move the player to the destination
            args.interactor.transform.root.rotation = teleportDestination.rotation; // Orient the player according to the destination
        }
    }

    private void OnDestroy()
    {
        var interactor = GetComponent<XRBaseInteractor>();
        if (interactor != null)
        {
            interactor.selectEntered.RemoveListener(HandleSelectEntered);
        }
    }
}
