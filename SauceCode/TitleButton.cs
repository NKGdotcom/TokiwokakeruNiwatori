using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : ButtonTransition
{
    private Button titleButton;
    // Start is called before the first frame update
    void Start()
    {
        titleButton = GetComponent<Button>();
        titleButton.onClick.AddListener(OnButtonClick);
    }
    /// <summary>
    /// ボタンをクリックしたら
    /// </summary>
    private void OnButtonClick()
    {
        SceneChange("Title");
    }
}


