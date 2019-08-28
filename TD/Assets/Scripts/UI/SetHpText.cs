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
    }

    // Start is called before the first frame update
    void Start()
    {
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
