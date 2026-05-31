using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    /*
        This script serves the purpose of keeping track of ability values
        and feeding the information to the GameMaster script
    */

    [Header("References")]
    public GameMaster GM;
    public GameObject player;
    PlayerMovement PM;

    [Header("Player Stats")]
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpHeight;
    //add more based on the stat upgrades added to the game


    [Header("Dash Stats")]
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;

    [Header("Ability Checks")]
    public bool gotDash;
    public bool gotDoubleJump;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
