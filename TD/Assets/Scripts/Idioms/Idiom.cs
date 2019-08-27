using System.Collections.Generic;

public abstract class Idiom
{
    protected Dictionary<string, string> map;

    public abstract string GetIdiomName();

    public abstract string GetText(string index);

    protected abstract void AddTexts();

}
