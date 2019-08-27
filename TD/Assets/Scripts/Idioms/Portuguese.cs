using System.Collections.Generic;

public class Portuguese : Idiom
{
    public Portuguese()
    {
        map = new Dictionary<string, string>();
        AddTexts();
    }


    public override string GetIdiomName()
    {
        return "Português";
    }

    public override string GetText(string index)
    {
        return map[index];
    }

    protected override void AddTexts()
    {
        // Main Menu
        // ---
        map.Add("Start", "Iniciar");
        map.Add("Settings", "Configurações");
        map.Add("Credits", "Créditos");
        map.Add("Exit", "Sair");
        // ---

        // Settings
        // ---
        map.Add("Music", "Música");
        map.Add("Effects", "Efeitos");
        map.Add("Idiom", "Idioma");
        map.Add("Back", "Voltar");
        // ---

        // Credits
        // ---
        map.Add("Programmer", "Programador");
        map.Add("Game Designer", "Game Designer");
        map.Add("Story", "Roteiro");
        map.Add("Animation", "Animacao"); // the font doen't work well with brazillian accents
        map.Add("Audio Artist", "Artista de audio"); // the font doen't work well with brazillian accents
        map.Add("Visual Artist", "Artista Visual");
        // ---

        //Loading Screen
        // ---
        map.Add("Loading Screen", "Tela de Loading");
        // ---

        //Pause
        // ---
        map.Add("Pause", "Pausa");
        map.Add("Resume", "Voltar");
        map.Add("Restart", "Recomeçar");
        map.Add("Back to Main Menu", "Voltar para o Menu Principal");
        // ---

        //Level 1
        // ---
        map.Add("Highscore", "Pontuação Máxima");
        map.Add("Score", "Pontuação");
        // ---
    }
}
