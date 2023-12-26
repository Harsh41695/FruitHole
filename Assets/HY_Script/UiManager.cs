
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    int minutes = 1;
    [SerializeField]
    float seconds = 60;
    public int attackScore;

    [SerializeField]
    TextMeshProUGUI scoreText, timerText, appleCountTxt,
        graphsCountTxt, mangoCountTxt,attackScoreTxt;

    [SerializeField]
    GameObject timeUpPanel, bossLvlPanel;

    float time=0;
   public bool timeStop = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        timeUpPanel.SetActive(false);
        bossLvlPanel.SetActive(false);
        attackScoreTxt.gameObject.SetActive(false);
        //ScoreAndTimPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
       // TimerUpdate();
        ScoreUpdate();
        FruitCountUpdate();
        if (timeStop == true)
        {
            time += Time.deltaTime;
            if (time > 2.0f)
            {
                bossLvlPanel.SetActive(true);
                timeUpPanel.SetActive(false);
            }
            //HY_SpawnObj.instance.canSpawn = false;
            //EnemyDistance.instance.gameObject.SetActive(true);
           // HY_PlayerMovements.instance.joystickInput.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
           // HY_PlayerMovements.instance.canRun = false;
            attackScoreTxt.gameObject.SetActive(true);
        }
        AttackScoreDisplay(attackScore);

    }

    public void OnPlayPressed()
    {
        // load gameplay scene
        SceneManager.LoadScene(1);
    }

    public void OnOkayPressed()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }

    void TimerUpdate()
    {
        seconds -= Time.deltaTime;
        if(seconds < 1)
        {
            minutes--;
            if(minutes < 0)
            {
                //Game Over
                if (bossLvlPanel != null)
                {
                    timeUpPanel.SetActive(true);
                    timeStop = true;
                }
            }
            seconds = 60;
        }
        if (seconds < 10)
        {
           timerText.text = "0"+minutes + " : " +"0"+ (int)seconds;

        }
        else
        {
            timerText.text =   "0"+minutes + " : " + (int)seconds;

        }
    }
    
    void ScoreUpdate()
    {
        //Display Score
        //scoreText.text = "Score : " + Hole.instance.totalScore;
    }
    void FruitCountUpdate()
    {
        //appleCountTxt.text = Hole.instance.appleCount.ToString();
        //graphsCountTxt.text = Hole.instance.graphCount.ToString();
        //mangoCountTxt.text = Hole.instance.mangoCount.ToString();
    }

    void AttackScoreDisplay(int score)
    {
        attackScoreTxt.text = score.ToString();
    }
}
