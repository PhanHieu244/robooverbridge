using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Runing,
    Stop
}

public class GameUI : Singleton<GameUI>
{
    public Button back;
    public Button back1;
    public Button menu;

    public GameObject lose;

    public State currentState = State.Stop;


    // Start is called before the first frame update
    void Start()
    {
        back?.onClick.AddListener(ExitGame);
        back1?.onClick.AddListener(ExitGame);
        menu?.onClick.AddListener(RestartGame);

        SetState(State.Stop);
    }

    public float holdDuration = 1f;

    public float max = 3;
    public float rangeMove = 0;
    public int direction = 1;

    void Update()
    {
        if (currentState == State.Stop)
        {
            if (Input.GetMouseButton(0))
            {
                rangeMove += Time.deltaTime * direction;

                if (rangeMove >= max)
                {
                    direction = -1;
                }

                if (rangeMove < 0)
                {
                    direction = 1;
                }

                cau.Instance.SetLine(rangeMove);
            }

            if (Input.GetMouseButtonUp(0))
            {
                cau.Instance.SetLine(rangeMove, true);
                rangeMove = 0;
                SetState(State.Runing);
            }
        }
    }


    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowLose()
    {
        lose.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    [Button]
    public void Jump()
    {
        SetState(State.Runing);
    }

    private float duration = 1f;

    public void SetState(State state)
    {
        currentState = state;
    }
}