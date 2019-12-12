using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{

    Text LiveText;
    [SerializeField] int damage = 1;
    [SerializeField] float baseLives = 5;
    float live;

    private void Start()
    {
        live = baseLives - PlayerPrefsController.GetDifficulty();
        LiveText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        LiveText.text = live.ToString();
    }
    public void TakeLife()
    {
        live -= damage;
        UpdateDisplay();

        if(live <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
