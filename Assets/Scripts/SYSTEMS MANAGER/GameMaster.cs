using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public bool checkpointActivated = false;
    public bool playerDied;

    [Header("References")]
    private static GameMaster instance;
    public LeTimer timer;
    public GameObject HitMarker;
    public GameObject player;
    public GameObject endPortal;
    public bool startSearch;
    public AbilityManager AM;


    [Header("Scene Positions")]
    public Vector3 startCheckPointPos;
    public Vector3 lastCheckPointPos;

    /*
    in unity I'm making a game that lets the player select 1 of 3 
    powerups at the start of each level and the game is supposed to 
    let you keep all those abilities to use in the final level. 
    My problem is that I can't figure out how to make the GameManager 
    script keep track of which powerups the player obtained in older levels.
    */
    
    public bool gotDash;
    public bool gotDoubleJump;
    public bool gotHighJump;
    public bool gotSprintBoost;

    [Header("Assigned Slot Keybindings")]
    public SlotButtons slotScript;
    public KeyCode dashSlotKey = KeyCode.None;
    public KeyCode doubleJumpSlotKey = KeyCode.None;

    //REFERENCES
    public UpgradeMenu UM;
    public PlayerMovement PM;
    public DoubleJump doubleJumpScript;
    public PlayerDash dashScript;
    private EnemyAI EA;

    
    //KEYCODES
    public KeyCode returnKey;


    void Awake()
    {
        

        timer = GameObject.FindGameObjectWithTag("GM").GetComponent<LeTimer>();
        startCheckPointPos = lastCheckPointPos;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UM = GameObject.Find("Menu").GetComponent<UpgradeMenu>();
        slotScript = GameObject.Find("Menu").GetComponent<SlotButtons>();
        //playerSearch();
        /*
        if
        {
            endPortal.SetActive(false);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkpointActivated && playerDied)
        {
            timer.currenttime = 0;
            playerDied = false;
        }
        
        // [USED FOR TESTING]
            if (Input.GetKey(returnKey))
            {
                lastCheckPointPos = startCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        

        //Physics.IgnoreLayerCollision(10,10);
        //Physics.IgnoreLayerCollision(3,10);
        //if (EA.hurt == false)
        //  HitMarker.SetActive(false);

        //if (EA.hurt == true)
        //  HitMarker.SetActive(true);
    }

    public void playerSearch()
    {
        player = GameObject.Find("Player");
        PM = player.GetComponent<PlayerMovement>();
        UM.cam = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
        
        if(gotDash)
        {
            dashScript = player.GetComponent<PlayerDash>();
            dashScript.enabled = true;
            
            // Restore assigned slot key if it was set
            if(dashSlotKey != KeyCode.None)
            {
                dashScript.dashKey = dashSlotKey;
            }
        }
        else 
            dashScript.enabled = false;


        if(gotDoubleJump)
        {
            doubleJumpScript = player.GetComponent<DoubleJump>();
            doubleJumpScript.enabled = true;
        }
        else
        {
            doubleJumpScript.enabled = false;
        }

        if(gotHighJump)
        {
            //PM.storeJumpForce = 11;
            //PM.jumpForce = 11;
        }
        if(gotSprintBoost)
        {
            //PM.sprintSpeed += 2;
        }
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method is called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerSearch();
        Debug.Log($"Scene Loaded: {scene.name} (Build Index: {scene.buildIndex})");
        Debug.Log($"Load Mode: {mode}");
        
        // Example: Check if it's the first scene
        if (scene.buildIndex == 0)
        {
            Debug.Log("This is the first scene in the build order.");
        }
    }
}
