using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int points;
    public GameObject[] Debris;
    public GameObject Points;
    public GameObject Timer;

    float currenttime = 0f;
    float startingtime = 60f;
    float minutesLeft = 1;

    public bool GameStarted;
    public bool tutorial;

    public GameObject StartButton;
    public GameObject Tutorial;
    public GameObject Quit;
    public GameObject FinalPoints;
    public GameObject FinalRank;
    public GameObject MainMenu;
    public GameObject TutorialMarker;

    public LineRenderer pointer;

    private bool Spawned = false;

    public int tutorialIndex;

    public AudioSource Tutorial1;
    public AudioSource Tutorial2;
    public AudioSource Tutorial3;
    public GameObject Spawnpoint1;
    public GameObject Spawnpoint2;

    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
        tutorial = false;

        points = 0;

        currenttime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted == true)
        {
            pointer.enabled = false;

            if (Spawned == false)
            {
                for (int i = 0; i < 200; i++)
                {
                    Vector3 Coordinate = new Vector3(Random.Range(40, -40), Random.Range(10, -10), Random.Range(-10, -70));
                    Instantiate(Debris[Random.Range(0, 5)], Coordinate, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                }

                Spawned = true;
            }


            if (points <= 0)
            {
                points = 0;
            }

            Points.GetComponent<TextMeshProUGUI>().text = "Points - " + points;

            if (minutesLeft >= 0)
            {
                SecondsLeft();
            }

            if (minutesLeft < 0)
            {
                GameObject[] a = GameObject.FindGameObjectsWithTag("Debris");

                for (int i = 0; i < a.Length; i++)
                {
                    Destroy(a[i].gameObject);
                }

                GameStarted = false;
                FinalPoints.SetActive(true);
                FinalPoints.GetComponent<TextMeshProUGUI>().text = "Final Points - " + points;
                FinalRank.SetActive(true);
                FinalRank.GetComponent<TextMeshProUGUI>().text = GetRank(points);
                MainMenu.SetActive(true);
            }
        }

        else if (tutorial == true)
        {
            TutorialRunThrough();

            pointer.enabled = false;
        }


        else
        {
            Points.SetActive(false);
            Timer.SetActive(false);
            pointer.enabled = true;
        }

    }

    private void SecondsLeft()
    {
        currenttime -= 1 * Time.deltaTime;
        Timer.GetComponent<TextMeshProUGUI>().text = "Time - " + minutesLeft + ":" + currenttime.ToString("0");

        if (currenttime < 0)
        {
            currenttime = startingtime;
            minutesLeft -= 1;
        }
    }

    public void StartGame()
    {
        GameStarted = true;
        StartButton.SetActive(false);
        Tutorial.SetActive(false);
        Quit.SetActive(false);
        Points.SetActive(true);
        Timer.SetActive(true);

    }

    public void StartTutorial()
    {
        tutorial = true;
        StartButton.SetActive(false);
        Tutorial.SetActive(false);
        Quit.SetActive(false);
        tutorialIndex = 0;
    }

    public void Close()
    {
        Application.Quit();
    }

    public string GetRank(float points)
    {
        string rank;
        if (points < 40)
        {
            rank = "Rank D";
        }

        else if (points < 80 && points >= 40)
        {
            rank = "Rank C";
        }

        else if (points < 120 && points >= 80)
        {
            rank = "Rank B";
        }

        else if (points < 160 && points >= 120)
        {
            rank = "Rank A";
        }

        else if (points >= 160)
        {
            rank = "Rank S";
        }

        else
        {
            rank = "";
        }

        return rank;
    }

    public void Menu()
    {
        StartButton.SetActive(true);
        Tutorial.SetActive(true);
        Quit.SetActive(true);
        FinalPoints.SetActive(false);
        FinalRank.SetActive(false);
        MainMenu.SetActive(false);
    }

    private void TutorialRunThrough()
    {
        if (tutorialIndex == 0)
        {
            //Tutorial1.Play();
            Instantiate(TutorialMarker, Spawnpoint1.transform.position, transform.rotation);
            tutorialIndex++;
        }

        else if (tutorialIndex == 2)
        {
            //Tutorial2.Play();
            Instantiate(TutorialMarker, Spawnpoint2.transform.position, transform.rotation);
            tutorialIndex++;
        }

        else if (tutorialIndex == 4)
        {
            Instantiate(Debris[0], Spawnpoint1.transform.position, transform.rotation);
            tutorialIndex++;
            //Tutorial3.Play();
        }

        else if (tutorialIndex == 6)
        {
            Menu();
        }
    }
}
