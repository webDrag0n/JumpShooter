using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIupdate : MonoBehaviour
{
    public GameObject character;

    public GameObject height_label;
    public GameObject dead_message;

    // Start is called before the first frame update
    void Start()
    {
        dead_message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("player_dead") == 1)
        {
            dead_message.SetActive(true);
        }
        else
        {
            dead_message.SetActive(false);
        }
        height_label.GetComponent<TextMeshProUGUI>().text = "Height: " + Mathf.RoundToInt(character.transform.position.y);
    }
}
