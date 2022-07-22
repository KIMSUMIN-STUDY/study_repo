using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GamaManager : MonoBehaviour
{
    public UnityEvent onReset;
    public static GamaManager instance;

    public GameObject readyPannel;
    public Text scoreText;
    public Text bestScoreText;
    public Text messageText;
    public bool isRoundActive = false;
    private int score = 0;

    public ShooterRotater shooterRotater;
    public CamFollow cam;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        UpdaeUI();

        Start();
    }

    void Start()
    {
        StartCoroutine("RoundRoutine");
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateBestScore();
        UpdaeUI();
    }

    void UpdateBestScore()
    {
        if (GetBestScore() < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    int GetBestScore()
    {
        int bestScroe = PlayerPrefs.GetInt("BestScore");
        return bestScroe;
    }
    
    void UpdaeUI()
    {
        scoreText.text = "Score : " + score;
        bestScoreText.text = "Best Score : " + score;
    }

    public void OnBallDestroy()
    {
        UpdaeUI();
        isRoundActive = false;
    }

    public void Reset()
    {
        score = 0;
        UpdaeUI();

        StartCoroutine("RoundRoutine");
    }

    IEnumerator RoundRoutine()
    {
        //READY
        onReset.Invoke();
        
        readyPannel.SetActive(true);
        cam.SetTarget(shooterRotater.transform, CamFollow.State.Idle);
        shooterRotater.enabled = false;

        isRoundActive = false;

        messageText.text = "Ready ...";

        yield return new WaitForSeconds(3f);

        //PLAY
        isRoundActive = true;
        readyPannel.SetActive(false);
        shooterRotater.enabled = true;

        cam.SetTarget(shooterRotater.transform, CamFollow.State.Ready);

        while (isRoundActive == true)
        {
            yield return null;
        }

        //END
        readyPannel.SetActive(true);
        shooterRotater.enabled = false;

        messageText.text = "Wait For Next Round ...";

        yield return new WaitForSeconds(3f);
        Reset();
    }
}
