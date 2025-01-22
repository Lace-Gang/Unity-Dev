using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Back to singletons...
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

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
    

    // Update is called once per frame
    void Update()
    {
        //swtich tab tab [state] enter enter
        //makes life easier
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    OnStartGame();

                }
                break;
            case eState.GAME:

                break;
            case eState.WIN:
                print("win:");
                break;
            case eState.LOSE:
                print("lose");
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
}

