using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    private string[] compObject={"Rock","Paper","Scissors"};
    private string compDesicion;
    private inputScript inputScript;
    [SerializeField] private Sprite[] compImage;
    [SerializeField] private GameObject computerSelection;
    public bool sendCompChoice = false;
    [SerializeField] private TextMeshProUGUI whoWinsText;
    [SerializeField] private TextMeshProUGUI _countUI;
    private bool showWinText = false;
    [SerializeField] private float gameTime;
    [SerializeField] private Image vsImage;
    private float currentTime;
    private float countdown = 3f;
    private AudioSource _aSource;
    [SerializeField] private AudioClip[] winSounds;
    private bool justOneTimePlay = false;
    
   
    
    void Start()
    {
        _aSource=GetComponent<AudioSource>();
        inputScript=GameObject.Find("InputSystem").GetComponent<inputScript>();
        compDesicion = compRandomChoices();
        Debug.Log(compDesicion);
        currentTime=countdown;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        getResult();
        
        
    }

    private string compRandomChoices()
    {
        int randomChoice=Random.Range(0, compObject.Length);
        return compObject[randomChoice];
        
    }

    private void getResult()
    {
        if (!justOneTimePlay)
        {
            if (inputScript.playerChoices == compDesicion)
            {
                if (showWinText)
                {
                    whoWinsText.color = Color.green;
                    whoWinsText.text = "Draw!";
                }
            
            }
            else if (inputScript.playerChoices == "Rock" && compDesicion == "Scissors" )
            {
                if (showWinText)
                {
                    whoWinsText.color = Color.blue;
                    whoWinsText.text = "You win!";
                    if (!_aSource.isPlaying)
                    {
                        _aSource.PlayOneShot(winSounds[0]);
                        justOneTimePlay = true;
                    }
                
                }

            }
            else if (inputScript.playerChoices == "Paper" && compDesicion == "Rock" )
            {
                if (showWinText)
                {
                    whoWinsText.color = Color.blue;
                    whoWinsText.text = "You win!";
                    if (!_aSource.isPlaying)
                    {
                        _aSource.PlayOneShot(winSounds[0]);
                        justOneTimePlay = true;
                    }
                }

            }
            else if (inputScript.playerChoices == "Scissors" && compDesicion == "Paper" )
            {
                if (showWinText)
                {
                    whoWinsText.color = Color.blue;
                    whoWinsText.text = "You win!";
                    if (!_aSource.isPlaying)
                    {
                        _aSource.PlayOneShot(winSounds[0]);
                        justOneTimePlay = true;
                    }
                }
        
            }
            else
            {
                if (!string.IsNullOrEmpty(inputScript.playerChoices))
                {
                    if (showWinText)
                    {
                        whoWinsText.color = Color.red;
                        whoWinsText.text = "Computer win!";
                        if (!_aSource.isPlaying)
                        {
                            int randomSound=Random.Range(1,winSounds.Length);
                            _aSource.PlayOneShot(winSounds[randomSound]);
                            justOneTimePlay = true;
                        }
                    }
              
                }
            
            }
        }
        

        
        StartCoroutine(compSelectiontoImage());
    }

    IEnumerator  compSelectiontoImage()
    {
        if (sendCompChoice)
        {
            vsImage.GetComponent<Image>().enabled = false;
            countTimer();
            yield return new WaitForSeconds(gameTime);
            _countUI.GetComponent<TextMeshProUGUI>().enabled = false;
            
            showWinText = true;
            computerSelection.GetComponent<Image>().enabled = true;
            if (compDesicion == "Rock")
            {
                computerSelection.GetComponent<Image>().sprite = compImage[0];
            }
            else if (compDesicion == "Paper") 
            {
                computerSelection.GetComponent<Image>().sprite = compImage[1];
            }
            else
            {
                computerSelection.GetComponent<Image>().sprite = compImage[2];
            }
        }
        
    }

    

    private void countTimer()
    {
        
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            _countUI.text = Mathf.CeilToInt(currentTime).ToString();
        }
        
        if (currentTime <= 0)
        {
            currentTime = 0;
            vsImage.GetComponent<Image>().enabled = true;
        }
    }
}
