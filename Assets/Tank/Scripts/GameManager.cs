using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Back to singletons...
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject instructionUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject showScoreUI;
    [SerializeField] TMP_Text showScoreText;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera altCamera;
    [SerializeField] TMP_Text scoreText;


    enum eState
    {
        TITLE,
        START_GAME,
        GAME,
        WIN,
        LOSE
    }

    private void Awake()
    {
        instance = this;
    }

    eState state = eState.TITLE;
    float timer = 0;
    float transitionTimer = 0;
    int score = 0;
    

    // Update is called once per frame
    void Update()
    {
        //swtich tab tab [state] enter enter
        //makes life easier
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                winUI.SetActive(false);
                loseUI.SetActive(false);
                instructionUI.SetActive(false);
                showScoreUI.SetActive(false);


                altCamera.enabled = false;
                mainCamera.enabled = true;
                score = 0;


                if (Input.GetKeyUp(KeyCode.Space))
                {
                    transitionTimer = 5;
                    OnStartGame();
                }
                break;
            case eState.START_GAME:
                transitionTimer -= Time.deltaTime;
                if (transitionTimer <= 0 || Input.GetKeyDown(KeyCode.Space)) 
                {
                    instructionUI.SetActive(false);
                    state = eState.GAME;
                }
                break;
            case eState.GAME:

                break;
            case eState.WIN:
                showScoreText.text = "Final Score: " + score;
                showScoreUI.SetActive(true );
                winUI.SetActive(true);
                //print("win:");
                break;
            case eState.LOSE:
                //mainCamera.enabled = false;
                altCamera.enabled = true;
                showScoreText.text = "Final Score: " + score;
                showScoreUI.SetActive(true);
                loseUI?.SetActive(true);
                //print("lose");
                break;
            default:
                break;
        }


        
    }



    public void OnStartGame()
    {
        titleUI.SetActive(false);
        instructionUI.SetActive(true);
        state = eState.START_GAME;

    }

    public void SetGameOver()
    {
        state = eState.LOSE;
    }

    public void SetGameWin()
    {
        state = eState.WIN;
    }

    public void increaseScore(int scoreIncrease)
    {
        score += scoreIncrease;

        scoreText.text = "Score: " + score;
    }
}

