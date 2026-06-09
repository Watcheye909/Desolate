using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum AbilityType
    {
        None,
        Dash,
        DoubleJump,
        HighJump,
        SprintBoost
    }

    public AbilityType abilityType = AbilityType.None;

    /*
    Upgrade process:
    1. Player picks up an upgrade item (not in this script, but you would have some sort of prompt to have the player choose which slot to put the upgrade in).
    2. The player presses the corresponding key (Q, F, or V) to select the upgrade slot they want to use.
    3. The upgrade is applied to the player ().
    */ 

    [Header("Settings")]
    public bool randomize;

    [Header("Slot Abilities")]
    public bool dashUpgrade;
    
    [Header("Upgraded Moves")]
    public bool doubleJumpUpgrade;

    [Header("Stat Upgrades")]
    public bool highjumpUpgrade;
    public bool sprintUpgrade;


    [Header("Stat Upgrade Values")]
    public float newJumpValue;
    public float newSprintValue;


    public GameObject manager;
    public GameMaster GM;
    public GameObject Player;
    public PlayerMovement pm;
    public PlayerDash PDash;
    public DoubleJump doublej;

    [Header("Slot Assignment")]
    public KeyCode assignedSlotKey = KeyCode.None;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameMaster");
        GM = manager.GetComponent<GameMaster>();

        Player = GameObject.Find("Player");
        pm = Player.GetComponent<PlayerMovement>();
        doublej = Player.GetComponent<DoubleJump>();
        PDash = Player.GetComponent<PlayerDash>();

        if(randomize)
            RandomizeUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomizeUpgrade()
    {
        dashUpgrade = false;
        doubleJumpUpgrade = false;
        highjumpUpgrade = false;
        sprintUpgrade = false;

        int randomIndex = Random.Range(0, 4);

        switch (randomIndex)
        {
            case 0:
                dashUpgrade = true;
                break;
            case 1:
                doubleJumpUpgrade = true;
                break;
            case 2:
                highjumpUpgrade = true;
                break;
            case 3:
                sprintUpgrade = true;
                break;
        }
    }

    //[ABILTIES]
    public void gainDash()
    {
        if (assignedSlotKey != KeyCode.None && PDash != null)
        {
            PDash.dashKey = assignedSlotKey;
            // Store in GameMaster so it persists after player death
            if (GM != null)
            {
                GM.dashSlotKey = assignedSlotKey;
            }
        }

        if (PDash != null)
        {
            PDash.enabled = true;
        }

        if (GM != null)
        {
            GM.gotDash = true;
        }

        this.gameObject.SetActive(false);
    }

    public void gainDoubleJump()
    {
        if (doublej != null)
        {
            doublej.enabled = true;
        }

        this.gameObject.SetActive(false);
    }

    public void AssignSlotKey(KeyCode key)
    {
        assignedSlotKey = key;

        if (dashUpgrade && PDash != null)
        {
            PDash.dashKey = assignedSlotKey;
            // Store in GameMaster so it persists after player death
            if (GM != null)
            {
                GM.dashSlotKey = key;
            }
        }
    }

    public AbilityType GetAbilityType()
    {
        if (abilityType != AbilityType.None)
            return abilityType;

        if (dashUpgrade)
            return AbilityType.Dash;
        if (doubleJumpUpgrade)
            return AbilityType.DoubleJump;
        if (highjumpUpgrade)
            return AbilityType.HighJump;
        if (sprintUpgrade)
            return AbilityType.SprintBoost;

        return AbilityType.None;
    }

    public void ApplyPendingUpgrade()
    {
        switch (GetAbilityType())
        {
            case AbilityType.Dash:
                gainDash();
                break;
            case AbilityType.DoubleJump:
                gainDoubleJump();
                break;
            case AbilityType.HighJump:
                gainHighJump();
                break;
            case AbilityType.SprintBoost:
                gainSpeedBoost();
                break;
            default:
                Debug.LogWarning("PowerUps: No pending upgrade to apply.");
                break;
        }
    }

    
    //[STAT UPGRADES]
    public void gainHighJump()
    {
        pm.storeJumpForce += newJumpValue;
        pm.jumpForce = pm.storeJumpForce; 
        this.gameObject.SetActive(false);
    }

    public void gainSpeedBoost()
    {
        pm.sprintSpeed += newSprintValue;
        this.gameObject.SetActive(false);
    }

}
