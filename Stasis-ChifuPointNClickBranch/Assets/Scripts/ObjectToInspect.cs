using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectToInspect : MonoBehaviour
{
    public string TextToShow;
    public bool playerInDialogueRange;
    public float dialogueRange;
    public LayerMask isPlayer;
    private void Update()
    {
        playerInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, isPlayer);
        if(playerInDialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            TextPanel.inst.Show(TextToShow);
        }
    }
}
