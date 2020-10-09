using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField]
    private GameObject player;
    private CharacterParams charParams;

    void Start()
    {
        charParams = player.GetComponent<CharacterParams>();
    }

    void Update()
    {
        slider.value = charParams.player_HP;
    }
}
