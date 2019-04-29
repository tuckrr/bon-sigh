using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    public Button doneButton;
    public Text finishText;
    public float maxTime;
    private float timer = 0.0f;


    void Start()
    {
        doneButton.onClick.AddListener(Finish);
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    void Finish()
    {
        float mod = timer / maxTime;
        if (mod < 1)
        {
            mod = (1 - mod) * 100;
        }
        finishText.text = string.Format("Score: {0}", (int)(mod + RecFinish(transform)));
        doneButton.transform.GetChild(0).GetComponent<Text>().text = "Back";
        doneButton.onClick.RemoveListener(Finish);
        doneButton.onClick.AddListener(GoToMenu);
    }

    float RecFinish(Transform t)
    {
        TreePartController treePart = GetComponent<TreePartController>();
        if (t.childCount == 0)
        {
            if (treePart != null)
            {
                return treePart.Correct ? -2 : 1;
            }
            return 0;
        }
        float ret = 0;
        for (int i = 0; i < t.childCount; i++)
        {
            ret += RecFinish(t.GetChild(i));
        }
        if (treePart != null)
        {
            return treePart.Correct ? ret - 2 : ret + 1;
        }
        return ret;
    }
}
