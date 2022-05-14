using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent((typeof(Interactable)))]
public class TakeObjects : MonoBehaviour
{
    private Interactable _interactable;
    private Hand.AttachmentFlags _attachmentFlags = Hand.defaultAttachmentFlags
        & ~Hand.AttachmentFlags.SnapOnAttach
        & ~Hand.AttachmentFlags.DetachOthers
        & ~Hand.AttachmentFlags.VelocityMovement;

    private void Awake()
    {
        _interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        
    }

    private void OnAttachedToHand(Hand hand)
    {
        var rb = hand.currentAttachedObject.GetComponent<Rigidbody>();
        var transformOfAttachedObject = hand.currentAttachedObject.GetComponentInChildren<Transform>();

        rb.drag = 10000;
        rb.angularDrag = 10000;
    }

    private void OnDetachedFromHand(Hand hand)
    {
        var rb = hand.currentAttachedObject.GetComponent<Rigidbody>();
        var transformOfAttachedObject = hand.currentAttachedObject.GetComponent<Transform>();

        rb.drag = 1;
        rb.angularDrag = 1;
    }

    private void HandAttachedUpdate(Hand hand)
    {
        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void HandHoverUpdate(Hand hand)
    {
        var startingGrabType = hand.GetGrabStarting();
        bool isGrabEnd = hand.IsGrabEnding(this.gameObject);

        if (_interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            hand.HoverLock(_interactable);
            hand.AttachObject(gameObject, startingGrabType, _attachmentFlags);
        }
        else if (isGrabEnd)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(_interactable);
        }
    }
}
