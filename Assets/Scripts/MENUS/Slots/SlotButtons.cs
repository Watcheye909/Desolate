using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButtons : MonoBehaviour
{
    public UpgradeMenu um;
    public GameMaster gm;
    public GameObject player;
    public PowerUps power;

    public GameObject slot1;
    public SlotScript slot1Script;

    public GameObject slot2;
    public SlotScript slot2Script;

    public GameObject slot3;
    public SlotScript slot3Script;

    [Header("Slot Keybindings")]
    public KeyCode slot1Key;
    public KeyCode slot2Key;
    public KeyCode slot3Key;
    // Start is called before the first frame update
    void Start()
    {
        slot1 = GameObject.Find("SlotButton(1)");
        slot2 = GameObject.Find("SlotButton(2)");
        slot3 = GameObject.Find("SlotButton(3)");

        slot1Script = GameObject.Find("SlotButton(1)").GetComponent<SlotScript>();
        slot2Script = GameObject.Find("SlotButton(2)").GetComponent<SlotScript>();
        slot3Script = GameObject.Find("SlotButton(3)").GetComponent<SlotScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slot1Select()
    {
        Debug.Log("Slot 1 Selected");
        AssignSlotKeyToPowerup(slot1Key);

        //slot1Script.empty = false;
    }
    public void Slot2Select()
    {
        Debug.Log("Slot 2 Selected");
        AssignSlotKeyToPowerup(slot2Key);
    }
    public void Slot3Select()
    {
        Debug.Log("Slot 3 Selected");
        AssignSlotKeyToPowerup(slot3Key);
    }

    private void AssignSlotKeyToPowerup(KeyCode key)
    {
        if (power == null)
        {
            Debug.LogWarning("SlotButtons: No PowerUps reference assigned.");
            return;
        }

        power.AssignSlotKey(key);
    }
}
