using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoController : Singleton<CargoController>
{
    public Button buttonGetCargo;
    public Text textScore;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        private set
        {
            score = value;
            UpdateViewScore();
        }
    }

    public Station CurrentStation { get; set; }

    private void Start()
    {
        Score = 0;

        buttonGetCargo.onClick.AddListener(GetCargo);
    }

    private void GetCargo()
    {
        Score++;
        CurrentStation = null;
    }

    private void UpdateViewScore()
    {
        textScore.text = $"Очки: {Score}";
    }

    private void Update()
    {
        if (CurrentStation != null && Train.Instance.Speed == 0 && !buttonGetCargo.gameObject.activeInHierarchy)
            buttonGetCargo.gameObject.SetActive(true);
        else if ((CurrentStation == null || Train.Instance.Speed != 0) && buttonGetCargo.gameObject.activeInHierarchy)
            buttonGetCargo.gameObject.SetActive(false);
    }
}
