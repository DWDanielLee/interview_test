using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interactable : MonoBehaviour
{
    [Header("Interaction Data")]
    public string interactableName = "";
    public float interactionDistance = 10;
    InteractableNameText interactableNameText;
    [SerializeField] bool isInteractable = true;

    GameObject interactableNameCanvas;

    public virtual void Start()
    {
        interactableNameCanvas = GameObject.FindGameObjectWithTag("WorldSpaceCanvas");
        interactableNameText = interactableNameCanvas.GetComponentInChildren<InteractableNameText>();
    }

    public void TargetOn()
    {
        interactableNameText.ShowText(this);
        interactableNameText.SetInteractableNamePosition(this);
    }

    public void TargetOff()
    {
        interactableNameText.HideText();
    }

    public void Interact()
    {
        if(isInteractable) Interaction();
    }

    protected virtual void Interaction()
    {
        print("interact with : " + this.name);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);    
    }

    private void OnDestroy() 
    {
        TargetOff();    
    }
}