using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractableNameText : MonoBehaviour
{
    TextMeshProUGUI text;
    Transform cameraTransform;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        cameraTransform = Camera.main.transform;
        HideText();
    }

    public void ShowText(Interactable interactable)
    {
        if(interactable is InteractableBIM)
        {
            if(((InteractableBIM)interactable).ispanelOpen)
            {
                text.text = interactable.interactableName + "\n [E] Close Info";
            }
            else
            {
                text.text = interactable.interactableName + "\n [E] Open Info";
            }
        }
    }

    public void HideText()
    {
        text.text = "";
    }

    public void SetInteractableNamePosition(Interactable interactable)
    {
        if(interactable.TryGetComponent(out BoxCollider boxCollider))
        {
            transform.position = interactable.transform.position + new Vector3(2,0,0) * boxCollider.bounds.size.y;
            transform.LookAt(2 * transform.position - cameraTransform.position);
        }
        else if(interactable.TryGetComponent(out CapsuleCollider capsuleCollider))
        {
            transform.position = interactable.transform.position + Vector3.up * capsuleCollider.height;
            transform.LookAt(2 * transform.position - cameraTransform.position);
        }
        else
        {
            print("Error. No Colldier Found!");
        }
    }
}
