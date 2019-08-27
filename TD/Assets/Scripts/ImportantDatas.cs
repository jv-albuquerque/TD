using UnityEngine;

public class ImportantDatas : MonoBehaviour
{
    private GameObject importantDatas = null;

    private int nextScene = 2;

    private Idiom idiom;
    private string sIdiom;

    private bool needFadeIn = true;

    private void Awake()
    {
        sIdiom = PlayerPrefs.GetString("Idiom", "English");

        switch (sIdiom)
        {
            case "Portuguese":
                idiom = new Portuguese();
                break;
            case "English":
                idiom = new English();
                break;
            default:
                idiom = new English();
                break;
        }

        if (importantDatas == null)
        {
            if (GameObject.FindGameObjectsWithTag("Datas").Length == 1)
                importantDatas = gameObject;
            else
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public int NextScene
    {
        set
        {
            nextScene = value;
        }
        get
        {
            return nextScene;
        }
    }

    public string SetIdiom
    {
        set
        {
            switch (value)
            {
                case "Portuguese":
                    idiom = new Portuguese();
                    break;
                case "English":
                    idiom = new English();
                    break;
                default:
                    idiom = new English();
                    break;
            }

            PlayerPrefs.SetString("Idiom", value);
        }
    }

    public bool NeedFadeIn { get => needFadeIn; set => needFadeIn = value; }

    public string GetText(string index)
    {
        return idiom.GetText(index);
    }

}
