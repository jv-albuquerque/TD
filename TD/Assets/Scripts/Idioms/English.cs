using System.Collections.Generic;

public class English : Idiom
{
    public English()
    {
        map = new Dictionary<string, string>();
        AddTexts();
    }


    public override string GetIdiomName()
    {
        return "English";
    }

    public override string GetText(string index)
    {
        return map[index];
    }

    protected override void AddTexts()
    {        
        // Main Menu
        // ---
        map.Add("Start", "Start");
        map.Add("Settings", "Settings");
        map.Add("Credits", "Credits");
        map.Add("Exit", "Exit");
        // ---

        // Settings
        // ---
        map.Add("Music", "Music");
        map.Add("Effects", "Effects");
        map.Add("Idiom", "Idiom");
        map.Add("Back", "Back");
        // ---

        // Credits
        // ---
        map.Add("Programmer", "Programmer");
        map.Add("Game Designer", "Game Designer");
        map.Add("Story", "Story");
        map.Add("Animation", "Animation");
        map.Add("Audio Artist", "Audio Artist");
        map.Add("Visual Artist", "Visual Artist");
        // ---

        //Loading Screen
        // ---
        map.Add("Loading Screen", "Loading Screen");
        // ---

        //Pause
        // ---
        map.Add("Pause", "Pause");
        map.Add("Resume", "Resume");
        map.Add("Restart", "Restart");
        map.Add("Back to Main Menu", "Back to Main Menu");
        // ---

        //Level 1
        // ---
        map.Add("Highscore", "Highscore");
        map.Add("Score", "Score");
        // ---
    }
}
