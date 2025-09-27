using UnityEngine;
using UnityEngine.UI;

public class inputScript : MonoBehaviour
{
    public string playerChoices;
    [SerializeField] private Sprite[] selectionResultItems;
    [SerializeField] private GameObject playerSelection;
    private bool canClickable = true;
    private gameManagerScript gameManager;
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource audioSource;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManagerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    public void RockChoice()
    {
        if (canClickable)
        {
            audioSource.PlayOneShot(_audioClips[0]);
            playerChoices = "Rock";
            playerSelection.GetComponent<Image>().enabled = true;
            playerSelection.GetComponent<Image>().sprite = selectionResultItems[0];
            canClickable = false;
            gameManager.sendCompChoice = true;
        }
    }

    public void PaperChoice()
    {
        if (canClickable)
        {
            audioSource.PlayOneShot(_audioClips[1]);
            playerChoices = "Paper";
            playerSelection.GetComponent<Image>().enabled = true;
            playerSelection.GetComponent<Image>().sprite = selectionResultItems[1];
            canClickable = false;
            gameManager.sendCompChoice = true;
        }
    }

    public void ScissorsChoice()
    {
        if (canClickable)
        {
            audioSource.PlayOneShot(_audioClips[2]);
            playerChoices = "Scissors";
            playerSelection.GetComponent<Image>().enabled = true;
            playerSelection.GetComponent<Image>().sprite = selectionResultItems[2];
            canClickable = false;
            gameManager.sendCompChoice = true;
        }
    }
}
