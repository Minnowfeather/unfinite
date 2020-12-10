using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingScreenMain : MonoBehaviour
{

    public enum Screens
    {
        NORMAL,
        CREDIT,
        START,
        OPTIONS,
        EXIT
    }

    public Screens screen;
    public GameObject StartB;
    public GameObject CreditB;
    public GameObject OptionsB;
    public GameObject ExitB;
    public GameObject XB;

    // Start is called before the first frame update
    void Start()
    {
        screen = Screens.NORMAL;

        StartB = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        StartB.GetComponent<Button>().onClick.AddListener(() => StartState());

        CreditB = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        CreditB.GetComponent<Button>().onClick.AddListener(() => CreditsState());

        OptionsB = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        OptionsB.GetComponent<Button>().onClick.AddListener(() => OptionsState());

        ExitB = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        ExitB.GetComponent<Button>().onClick.AddListener(() => ExitState());

        XB = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        XB.GetComponent<Button>().onClick.AddListener(() => NormalState());
        XB.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        switch(screen)
        {
            case (Screens.NORMAL)://Display options
                {
                    TurnOnButtons();
                    print("normal");
                    break;
                }
            case (Screens.START)://start
                {
                    TurnOffButtons();
                    //INSERT SCENE HERE *************************
                    SceneManager.LoadScene(sceneName:"bulletHellTesting");
                    print("Start");
                    break;
                }
            case (Screens.CREDIT)://Display credits
                {
                    TurnOffButtons();
                    print("credits");
                    break;
                }
         
            case (Screens.OPTIONS)://options
                {
                    TurnOffButtons();
                    print("options");
                    break;
                }
            case (Screens.EXIT)://Exit
                {
                    TurnOffButtons();
                    Application.Quit();
                    print("exit");
                    break;
                }


        }
       

    }


    public void TurnOffButtons()
    {
        StartB.SetActive(false);
        CreditB.SetActive(false);
        OptionsB.SetActive(false);
        ExitB.SetActive(false);
        XB.SetActive(true);
    }

    public void TurnOnButtons()
    {
        StartB.SetActive(true);
        CreditB.SetActive(true);
        OptionsB.SetActive(true);
        ExitB.SetActive(true);
        XB.SetActive(false);
    }

    public void StartState()
    {
        screen = Screens.START;
    }
    public void CreditsState()
    {
        screen = Screens.CREDIT;
    }
    public void OptionsState()
    {
        screen = Screens.OPTIONS;
    }
    public void ExitState()
    {
        screen = Screens.EXIT;
    }
    public void NormalState()
    {
        screen = Screens.NORMAL;
    }

    /*button1 = GameObject.Find("BattleCanvas").transform.GetChild(0).gameObject;//finds the button
       button1.SetActive(true);

       button1.GetComponent<Button>().onClick.AddListener(() => Input1(0));*/
}
