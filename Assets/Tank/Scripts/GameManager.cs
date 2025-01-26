using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Back to singletons...
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera altCamera;
    [SerializeField] TMP_Text scoreText;


    enum eState
    {
        TITLE,
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
    int score = 0;
    

    // Update is called once per frame
    void Update()
    {
        //swtich tab tab [state] enter enter
        //makes life easier
        switch (state)
        {
            case eState.TITLE:
                winUI.SetActive(false);
                loseUI.SetActive(false);
                altCamera.enabled = false;
                mainCamera.enabled = true;
                titleUI.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    OnStartGame();

                }
                break;
            case eState.GAME:

                break;
            case eState.WIN:
                winUI.SetActive(true);
                //print("win:");
                break;
            case eState.LOSE:
                //mainCamera.enabled = false;
                altCamera.enabled = true;
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
        state = eState.GAME;

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

