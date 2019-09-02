using UnityEngine;
using TMPro;

public class SetHpText : MonoBehaviour
{
    private TextMeshProUGUI text = null;

    public static SetHpText instance;

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
