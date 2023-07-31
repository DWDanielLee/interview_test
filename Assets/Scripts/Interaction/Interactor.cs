using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour
{
    [SerializeField] float maxInteractingDistance = 10f;
    [SerializeField] float interactingRadius = 1f;

    LayerMask layerMask;
    Transform cameraTransform;
    InputAction interactAction;

    //For Gizmo
    Vector3 origin;
    Vector3 direction;
    Vector3 hitPosition;
    float hitDistance;

    [HideInInspector]
    public Interactable interactableTarget;

    public TextMeshProUGUI leftControlText;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        layerMask = LayerMask.GetMask("Interactable");
        interactAction = GetComponent<PlayerInput>().actions[("Interaction")];
        interactAction.performed += Interact;
    }

    void Update()
    {
        direction = cameraTransform.forward;
        origin = cameraTransform.position;
        RaycastHit hit;

        if(Physics.SphereCast(origin, interactingRadius, direction, out hit, maxInteractingDistance, layerMask))
        {
            //Fill in script
        }
        else if(interactableTarget)
        {
            //Also fill in this area
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (Cursor.lockState != CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                leftControlText.text = "Left Control - Mouse <color=red>On</color>/Off";
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                leftControlText.text = "Left Control - Mouse On/<color=red>Off</color>";
            }
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if(interactableTarget != null)
        {
            if(Vector3.Distance(transform.position, interactableTarget.transform.position)
            <= interactableTarget.interactionDistance)
            {
                interactableTarget.Interact();
            }
        }
        else
        {
            print("nothing to interact!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(origin, origin+direction * hitDistance);
        Gizmos.DrawWireSphere(hitPosition, interactingRadius);
    }

    private void OnDestroy()
    {
        interactAction.performed -= Interact;
    }
}
