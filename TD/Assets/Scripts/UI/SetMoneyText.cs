using UnityEngine;
using TMPro;

public class SetMoneyText : MonoBehaviour
{
    private TextMeshProUGUI text = null;

    public static SetMoneyText instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        text = GetComponent<TextMeshProUGUI>();
    }

    public int SetText
    {
        set
        {
            text.text = value.ToString();
        }
    }
}
