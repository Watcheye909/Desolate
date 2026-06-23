using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAnimation : MonoBehaviour
{
    public Animator ani;


    public bool isSlot1;
    public bool isSlot2;
    public bool isSlot3;


    SlotScript currentSlot;
    // Start is called before the first frame update
    void Start()
    {
        if(isSlot1)
            currentSlot = GameObject.Find("SlotButton(1)").GetComponent<SlotScript>();
        
        else if(isSlot2)
            currentSlot = GameObject.Find("SlotButton(2)").GetComponent<SlotScript>();
        
        else
            currentSlot = GameObject.Find("SlotButton(3)").GetComponent<SlotScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //Set the animation bool checks when the slotState = a slot ability
        if(currentSlot.state == SlotScript.slotState.dash)
        {
            
        }
    }
}
