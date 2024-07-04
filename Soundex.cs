using System;
using System.Text;
using System.Collections.Generic;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = BuildSoundex(name);
        PadSoundex(soundex);
        return soundex.ToString();
    }

    private static StringBuilder BuildSoundex(string name)
    {
        StringBuilder soundex = InitializeSoundex(name);
        var data = new BuildSoundexParams { Soundex = soundex, Name = name };
        BuildSoundexCode(data);
        return soundex;
    }

    private static StringBuilder InitializeSoundex(string name)
    {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        return soundex;
    }

    private static void BuildSoundexCode(BuildSoundexParams parameters)
    {
        StringBuilder soundex = parameters.Soundex;
        string name = parameters.Name;

        char prevCode = GetSoundexCode(name[0]);

        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            AppendNextSoundexCode(soundex, name[i], prevCode);
        }
    }

    private static void AppendNextSoundexCode(StringBuilder soundex, char letter, char prevCode)
    {
        char code = GetSoundexCode(letter);
        if (ShouldAppendCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    private static void PadSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        Dictionary<char, char> soundexCodes = new Dictionary<char, char>
        {
            {'B', '1'}, {'F', '1'}, {'P', '1'}, {'V', '1'},
            {'C', '2'}, {'G', '2'}, {'J', '2'}, {'K', '2'},
            {'Q', '2'}, {'S', '2'}, {'X', '2'}, {'Z', '2'},
            {'D', '3'}, {'T', '3'},
            {'L', '4'},
            {'M', '5'}, {'N', '5'},
            {'R', '6'}
        };

        return soundexCodes.TryGetValue(c, out char code) ? code : '0';
    }

    private class BuildSoundexParams
    {
        public StringBuilder Soundex { get; set; }
        public string Name { get; set; }
    }
    
}
