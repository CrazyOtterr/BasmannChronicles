using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPC_with_dialogue_AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask isGround, isPlayer;
    
    public float health;
    public bool isRunningTowardsPlayer = false;
    public bool isGivingQuest = false;
    public int _quest_id;
    private int _quest_stage;
    
    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    //Attacking
    // public float timeBetweenAttacks;
    // bool alreadyAttacked;
    // public GameObject projectile;
    private int indexChoices_current = 0;
    private int indexDialogue = 0;
    public bool isContainingChoices = false;

    [System.Serializable]
    public struct Choices
    {
        public string up_choice;
        // public int up_choice_index;
        public string down_choice;
        // public int down_choice_index;
        public string right_choice;
        // public int right_choice_index;
        public string left_choice;
        // public int left_choice_index;
    }

    public List<Choices> myChoices = new List<Choices>();
    private bool isChoosing = false;
    private bool hasTalked = false;

    // [System.Serializable]
    // public struct dialogueRoute
    // {
    //     public string[] Text;
    // }

    // public List<dialogueRoute> myDialogues = new List<dialogueRoute>();

    // [System.Serializable]
    // public class SubList {
    //     public string name;
    //     public List<Choices> list = new List<Choices>();
    // }

    // public List<SubList> myArray = new List<SubList>();
    

    public float sightRange, dialogueRange;
    public bool playerInSightRange, playerInDialogueRange;
    public GameObject plr;

    public Dialogue dialogue;

    public GameObject choicesMenu;
    public TMP_Text up;
    public TMP_Text down;
    public TMP_Text left;
    public TMP_Text right;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, indexDialogue);
    }

    public void GetQuestStage(int id)
    {
        _quest_stage = FindObjectOfType<QuestManager_Test>().CheckStage(id);
    }

    public void SetQuestStage(int id, int stage)
    {
        FindObjectOfType<QuestManager_Test>().SetStage(id, stage);
    }

    private void Awake()
    {
        // player = GameObject.Find("PlayerObj").transform;
        player = plr.transform;
        agent = GetComponent<NavMeshAgent>();
        if (isGivingQuest)
        {
            GetQuestStage(_quest_id);
        }
    }

    private void Update()
    {
        if (isRunningTowardsPlayer)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
            playerInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, isPlayer);

            if (!playerInSightRange && !playerInDialogueRange && !PlayerController.isInDialogue)
            {
                Patrolling();
            }
            if (playerInSightRange && !playerInDialogueRange && !PlayerController.isInDialogue && !hasTalked)
            {
                Chasing();
            }
            if (playerInSightRange && playerInDialogueRange && !PlayerController.isInDialogue && !hasTalked)
            {
                Dialogue();
            }
            
        }
        else
        {
            playerInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, isPlayer);

            if (PlayerController.isInDialogue || playerInDialogueRange)
            {
                transform.LookAt(player);
            }
            if (playerInDialogueRange && Input.GetKeyDown(KeyCode.E) && indexDialogue == 0 && DialogueManager.isEnded && !hasTalked)
            {
                Dialogue();
            }
        }

        if (PlayerController.isInDialogue || playerInDialogueRange)
        {
            transform.LookAt(player);
        }
        if (DialogueManager.isEnded)
        {
            PlayerController.isInDialogue = false;
        }
        else
        {
            PlayerController.isInDialogue = true;
        }
        if (isChoosing)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGivingQuest)
                {
                    GetQuestStage(_quest_id);
                    if (_quest_stage < 20)
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 1;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                    }
                    else if (_quest_stage == 20)
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 7;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                        SetQuestStage(_quest_id, 255);
                    }
                    else
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 8;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                    }
                }
                else
                {
                    PlayerController.canMove = true;
                    isChoosing = false;
                    indexDialogue = 1;
                    choicesMenu.SetActive(false);
                    TriggerDialogue();
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerController.canMove = true;
                isChoosing = false;
                indexDialogue = 2;
                choicesMenu.SetActive(false);
                TriggerDialogue();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (isGivingQuest)
                {
                    GetQuestStage(_quest_id);
                    if (_quest_stage == 0)
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 3;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                        SetQuestStage(_quest_id, 10);
                    }
                    else if (_quest_stage == 10 || _quest_stage == 20)
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 5;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                    }
                    else
                    {
                        PlayerController.canMove = true;
                        isChoosing = false;
                        indexDialogue = 6;
                        choicesMenu.SetActive(false);
                        TriggerDialogue();
                    }
                }
                else
                {
                    PlayerController.canMove = true;
                    isChoosing = false;
                    indexDialogue = 3;
                    choicesMenu.SetActive(false);
                    TriggerDialogue();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PlayerController.canMove = true;
                isChoosing = false;
                indexDialogue = 4;
                choicesMenu.SetActive(false);
                TriggerDialogue();
            }
        }
        if (indexDialogue == 0 && isContainingChoices && DialogueManager.isEnded && hasTalked)
        {
            choicesMenu.SetActive(true);
            up.text = myChoices[indexChoices_current].up_choice;
            down.text = myChoices[indexChoices_current].down_choice;
            right.text = myChoices[indexChoices_current].right_choice;
            left.text = myChoices[indexChoices_current].left_choice;
            isChoosing = true;
            PlayerController.canMove = false;
        }
        if (playerInDialogueRange && Input.GetKeyDown(KeyCode.E) && indexDialogue > 0 && DialogueManager.isEnded && hasTalked)
        {
            indexDialogue = 0;
            TriggerDialogue();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            walkPointSet = true;
        }
    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void Dialogue()
    {
        hasTalked = true;
        PlayerController.isInDialogue = true;
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        TriggerDialogue();
    }

    // private void Attacking()
    // {
    //     agent.SetDestination(transform.position);

    //     transform.LookAt(player);

    //     if (!alreadyAttacked)
    //     {
    //         /// attacking code
    //         Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
    //         rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
    //         rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    //         ///

    //         alreadyAttacked = true;
    //         Invoke(nameof(ResetAttack), timeBetweenAttacks);
    //     }
    // }

    // private void ResetAttack()
    // {
    //     alreadyAttacked = false;
    // }

    // public void TakeDamage(int damage)
    // {
    //     health -= damage;

    //     if (health <= 0)
    //     {
    //         Invoke(nameof(DestroyEnemy), 0.5f);
    //     }
    // }

    // private void DestroyEnemy()
    // {
    //     Destroy(gameObject);
    // }
}
