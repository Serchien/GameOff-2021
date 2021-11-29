using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutoBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text descritption;

    [SerializeField] GameObject group;

    // Start is called before the first frame update
    void Start()
    {
        group.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowSecondary()
    {
        group.SetActive(true);
        title.text = "Secondary Attack";
        descritption.text = "Right click with the mouse to shoot a projectile that deals heavy damage but use your energy (the green bar)";
    }
    public void ShowDash()
    {
        group.SetActive(true);
        title.text = "Combat Dash";
        descritption.text = "Press space bar to to make a quick dash and become invincible for a few moment";
    }
    public void ShowShield()
    {
        group.SetActive(true);
        title.text = "Combat Shield";
        descritption.text = "Press F to active your combat shield become invicible for a short time";
    }

    public void HideTuto()
    {
        group.SetActive(false);
    }
}
