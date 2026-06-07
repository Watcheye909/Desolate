using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public bool empty;
    public slotState state;

    public enum slotState
    {
        dash,
        groundPound,
        peachFloat,
        slowMotion,
        grappleHook,
        platform,
        speedRing
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StateHandler()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
