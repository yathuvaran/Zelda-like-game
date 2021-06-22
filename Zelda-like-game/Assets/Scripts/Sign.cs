using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public SignalSender contextOn;
    public SignalSender contextOff;
    public GameObject dialogBox; //reference to dialog box itself
    public Text dialogText; //reference the text
    public string dialog; //reference the string to show up in place of dialog
    public bool playerInRange; //boolean to determine if dialog box should be active

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
