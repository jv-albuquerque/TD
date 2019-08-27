using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    [SerializeField] private string key = null;
    private ImportantDatas datas = null;
    private TextMeshProUGUI textMP = null;

    private void Start()
    {
        datas = GameObject.FindGameObjectWithTag("Datas").GetComponent<ImportantDatas>();

        textMP = GetComponent<TextMeshProUGUI>();

        textMP.text = datas.GetText(key);
    }


}
