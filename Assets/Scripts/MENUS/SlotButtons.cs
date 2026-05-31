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
    public GameObject slot2;
    public GameObject slot3;

    [Header("Slot Keybindings")]
    public KeyCode slot1Key;
    public KeyCode slot2Key;
    public KeyCode slot3Key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slot1Select()
    {
        Debug.Log("Slot 1 Selected");
        AssignSlotKeyToPowerup(slot1Key);
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
