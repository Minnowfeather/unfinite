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

    public GameObject credits;
    public GameObject optionstext;
    public GameObject here;

    public GameObject chest;
    private Animator open;

    public GameObject afterText;
    public GameObject forchestopeningbutton;

    public bool yes = false;

    // Start is called before the first frame update
    void Start()
    {
        screen = Screens.NORMAL;

       // StartB = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        StartB.GetComponent<Button>().onClick.AddListener(() => StartState());

      //  CreditB = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        CreditB.GetComponent<Button>().onClick.AddListener(() => CreditsState());

       // OptionsB = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        OptionsB.GetComponent<Button>().onClick.AddListener(() => OptionsState());

        //ExitB = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        ExitB.GetComponent<Button>().onClick.AddListener(() => ExitState());

       // XB = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        XB.GetComponent<Button>().onClick.AddListener(() => NormalState());
        XB.SetActive(false);

        forchestopeningbutton.GetComponent<Button>().onClick.AddListener(() => displaychesttext());

        credits.SetActive(false);
        optionstext.SetActive(false);
        here.SetActive(false);
        chest.SetActive(false);
        forchestopeningbutton.SetActive(false);
        afterText.SetActive(false);

        open = chest.GetComponent<Animator>();
        open.enabled = false;
        //open.cullingMode = AnimatorCullingMode.CullCompletely;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(screen)
        {
            case (Screens.NORMAL)://Display options
                {
                    TurnOnButtons();
                    credits.SetActive(false);
                    optionstext.SetActive(false);
                    here.SetActive(false);
                    chest.SetActive(false);
                    forchestopeningbutton.SetActive(false);
                    afterText.SetActive(false);
                    open.enabled = false;
                    break;
                }
            case (Screens.START)://start
                {
                    TurnOffButtons();
                    //INSERT SCENE HERE ******************************************************
                   // SceneManager.LoadScene(sceneName:"bulletHellTesting");
                    print("Start");
                    break;
                }
            case (Screens.CREDIT)://Display credits
                {
                    TurnOffButtons();
                    credits.SetActive(true);
                   
                    break;
                }
         
            case (Screens.OPTIONS)://options
                {
                    TurnOffButtons();
                    optionstext.SetActive(true);
                    here.SetActive(true);
                    chest.SetActive(true);
                    
                    forchestopeningbutton.SetActive(true);
                    if(yes)
                    {
                        afterText.SetActive(true);
                        XB.SetActive(false);
                    }
                    
                    break;
                }
            case (Screens.EXIT)://Exit
                {
                    TurnOffButtons();
                    Application.Quit();
                   
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


    public void displaychesttext()
    {
        //open.cullingMode= AnimatorCullingMode.AlwaysAnimate;
        open.enabled = true;
        afterText.SetActive(true);
        yes = true;
      
    }

    /*button1 = GameObject.Find("BattleCanvas").transform.GetChild(0).gameObject;//finds the button
       button1.SetActive(true);

       button1.GetComponent<Button>().onClick.AddListener(() => Input1(0));*/
}
