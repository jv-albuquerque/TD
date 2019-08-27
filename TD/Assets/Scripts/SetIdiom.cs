using UnityEngine;

public class SetIdiom : MonoBehaviour
{
    private ImportantDatas datas;

    private void Awake()
    {
        datas = GameObject.FindGameObjectWithTag("Datas").GetComponent<ImportantDatas>();
    }

    public void ChooseIdiom(string idiom)
    {
        datas.SetIdiom = idiom;
    }
}
