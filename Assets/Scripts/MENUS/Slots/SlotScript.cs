using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public bool empty = true;
    public slotState state = slotState.None;

    public enum slotState
    {
        None,
        dash,
        doubleJump,
        highJump,
        sprintBoost,
        groundPound,
        peachFloat,
        slowMotion,
        grappleHook,
        platform,
        speedRing
    }

    public void AssignState(slotState newState)
    {
        state = newState;
        empty = newState == slotState.None;
    }

    public void ClearSlot()
    {
        AssignState(slotState.None);
    }
}
