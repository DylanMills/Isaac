using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] Image healthbar;
    [SerializeField] Image soulbar;
    [SerializeField] Text coinCount;
    [SerializeField] Text bombCount;
    [SerializeField] Text splash;

    [SerializeField] Player player;

    void Start()
    {
        SetSplash("BASEMENT 1");
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = player._health / 100f;
        soulbar.fillAmount = player._soulHealth / 100f;

        coinCount.text = $"x {player._money}";
        bombCount.text = $"x {player._bombs}";

        splash.color = new Color(1, 1, 1, Mathf.Clamp01(splash.color.a - Time.deltaTime * .75f));
    }

    public void SetSplash(string text)
    {
        splash.text = text;
        splash.color = Color.white;
    }
}
