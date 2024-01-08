using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicHeroScript : MonoBehaviour
{
    public float animstate;
    [Header("Basic data")]
    public int id;
    public float defaultMiningTime;
    public float defaultChoppingTime;
    public float defaultLootingTime;
    public float defaultBuildingTime;
    public float currentResearchTime;
    public float defaultHp = 10;
    public float healthPoints;

    public float defaultHunger = 240;
    public float hunger;

    [HideInInspector]
    public ResearchBase researchId;


    [Header("States")]
    public HeroBaseState currentState;
    public IdleState idleState = new IdleState();
    public ChoppingState choppingState = new ChoppingState();
    public MiningState miningState = new MiningState();
    public BuildingState buildingState = new BuildingState();
    public ShootingState shootingState = new ShootingState();
    public WalkingState walkingState = new WalkingState();
    public LootingState lootingState = new LootingState();
    public ResearchingState researchingState = new ResearchingState();
    public DeadState deadState = new DeadState();

    [Header("Scripts")]
    public controller controller;
    public GameResources resources;
    public ActionsScript ActionsScript;
    public ScriptingUI scriptingUI;
    public AIPath AiPath;
    public AstarPath AsPath;
    public ResearchPanelScripts rps;

    [Header("Cosmetics")]
    public GameObject progressBar;
    public GameObject bar;
    public GameObject circle;
    public GameObject axe;
    public GameObject pickaxe;
    public GameObject hammer;
    public GameObject square;
    public GameObject gun;
    public GameObject arms;
    public GameObject bullet;
    public GameObject basicHero;
    public GameObject flask;
    public Sprite tombstone;

    public Animator anim;
    public Rigidbody2D rgb;


    [Header("Other")]
    public bool isWorking;
    public float specialTimeMultiplier;
    public float hungerTimeMultiplier;
    bool canInteract;
    public GameObject resourceObject;
    public GameObject target_zombie;
    public GameObject discharge;






    // Start is called before the first frame update
    void Start()
    {
        if(specialTimeMultiplier == 0)
        {
            specialTimeMultiplier = 1;
        }

        ActionsScript = GetComponentInChildren<ActionsScript>();
        scriptingUI = GameObject.Find("GlobalScripts").GetComponent<ScriptingUI>();
        anim = GetComponentInChildren<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        AiPath = GetComponent<AIPath>();
        rps = GameObject.Find("ResearchScripts").GetComponent<ResearchPanelScripts>();
        square.SetActive(false);
        circle.SetActive(false);
        axe.SetActive(false);
        pickaxe.SetActive(false);
        gun.SetActive(false);
        hammer.SetActive(false);
        flask.SetActive(false);
        progressBar.SetActive(false);
        healthPoints = defaultHp;

        currentState = idleState;
        hunger = defaultHunger;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != deadState)
        {
            BugFixing();
            Animations();
            Actions();
            ResearchEffects();
            hunger -= Time.deltaTime * 0.3f;
        }

        if(healthPoints <= 0 && currentState != deadState)
        {
            SwitchState(deadState);
            scriptingUI.DeadHero(id - 1);
        }

        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {

    }



    public void StopRightThere()
    {
        controller.pointer[id].transform.position = this.transform.position;
    }



    void Actions()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && controller.heroId == id)
        {
            progressBar.SetActive(false);
            SwitchState(walkingState);
            
        }
        if(AiPath.remainingDistance < 1 && !isWorking && currentState != shootingState)
        {
            SwitchState(idleState);
        } 

    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (!isWorking && currentState != deadState)
        {
            switch (collision.tag)
            {
                case "tree":
                    square.SetActive(true);
                    ActionsScript.Actions("tree");
                    resourceObject = collision.gameObject;
                    break;

                case "rock":
                    square.SetActive(true);
                    ActionsScript.Actions("rock");
                    resourceObject = collision.gameObject;
                    break;

                case "loot":
                    square.SetActive(true);
                    ActionsScript.Actions("loot");
                    resourceObject = collision.gameObject;
                    break;

                case "tobuild":
                    square.SetActive(true);
                    ActionsScript.Actions("build");
                    resourceObject = collision.gameObject;
                    break;
            }
        }

       
        if (collision.tag == "enemy" && !isWorking && AiPath.remainingDistance < 1 && currentState != deadState)
        {
           
            if (currentState != shootingState)
            {
                GameObject zom = collision.gameObject;
                target_zombie = zom;

                if (currentState == idleState && rps.makeWeapon.isResearched == true)
                {
                    Debug.Log("startedShooting");
                    SwitchState(shootingState);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(currentState != deadState)
        if (collision.tag == "tree" || collision.tag == "rock" || collision.tag == "loot" || collision.tag == "tobuild")
            square.SetActive(false);

    }


    void Animations()
    {
        anim.SetFloat("speed", AiPath.remainingDistance);
        anim.speed = specialTimeMultiplier;

        if (controller.heroId == id)
            circle.SetActive(true);
        else
            circle.SetActive(false);

    }


    public void BugFixing()
    {
        AiPath.maxSpeed = 5 * specialTimeMultiplier;

        if (hunger <= 0)
        {
            hunger = 0;
        }

        if (hunger > defaultHunger)
        {
            hunger = defaultHunger;
        }

        if(healthPoints <= 0)
        {
            healthPoints = 0;
        }

        if(healthPoints > defaultHp)
        {
            healthPoints = defaultHp;
        }

        if (hunger <= 70)
        {
            hungerTimeMultiplier = 0.7f;
        }

        else
        {
            hungerTimeMultiplier = 1;
        }

        specialTimeMultiplier = 1 * hungerTimeMultiplier;
    }

    public void SwitchState(HeroBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);

    }

    public void Shoot()
    {
       GameObject actualBullet = bullet;
        
        //influence of research on bullets
        if (rps.ghostBullets.isResearched == true)
        {
            actualBullet.layer = 9;
        }

        else
        {
            actualBullet.layer = 0;
        }

       
        Instantiate(actualBullet, discharge.transform.position, discharge.transform.rotation);
    }

    public void StartResearch(float researchTime, ResearchBase research)
    {
        researchId = research;
        currentResearchTime = researchTime;
        SwitchState(researchingState);
    }

    public void Destroying(GameObject obj)
    {
        Destroy(obj);
    }

    void ResearchEffects()
    {

    }    

}

