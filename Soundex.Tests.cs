using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Fact]
    public void HandlesThreeCharacter()
    {
        Assert.Equal("A120", Soundex.GenerateSoundex("ABC"));
    }

    [Fact]
    public void HandlesMultipleCharacter()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("ABCD"));
    }

    [Fact]
    public void HandlesVowelsCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("AEIOU"));
    }
    
    [Fact]
    public void DropsUnwantedCharacters()
    {
        Assert.Equal("C300", Soundex.GenerateSoundex("Cat"));
        Assert.Equal("D200", Soundex.GenerateSoundex("Dog"));
        Assert.Equal("F300", Soundex.GenerateSoundex("Fifth"));
        Assert.Equal("G400", Soundex.GenerateSoundex("Giggle"));
    }
    
    [Fact]
    public void CombinesAdjacentSameDigits()
    {
        Assert.Equal("C000", Soundex.GenerateSoundex("Cccc"));
        Assert.Equal("D000", Soundex.GenerateSoundex("Ddt"));
        Assert.Equal("F300", Soundex.GenerateSoundex("Ffifth"));
        Assert.Equal("G400", Soundex.GenerateSoundex("Gggggle"));
    }
    
    [Fact]
    public void HandlesAdjacentSameDigitsSeparatedByHOrW()
    {
        Assert.Equal("C000", Soundex.GenerateSoundex("Chwcch"));
        Assert.Equal("D000", Soundex.GenerateSoundex("Dth"));
        Assert.Equal("F300", Soundex.GenerateSoundex("Fifthw"));
        Assert.Equal("G400", Soundex.GenerateSoundex("Ggiggle"));
    }
    
    [Fact]
    public void ProducesCorrectOutputWithMultipleCharacters()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Soundex"));
        Assert.Equal("H440", Soundex.GenerateSoundex("Hello"));
        Assert.Equal("W643", Soundex.GenerateSoundex("World"));
        Assert.Equal("T252", Soundex.GenerateSoundex("Testing"));
        Assert.Equal("E251", Soundex.GenerateSoundex("Example"));
    }

    [Fact]
    public void HandlesSimpleString()
    {
        Assert.Equal("P624", Soundex.GenerateSoundex("Prajwal"));
    }
    [Fact]
    public void HandlesStringWithDuplicates()
    {
        Assert.Equal("W252", Soundex.GenerateSoundex("WashingtonDC"));
    }
        [Fact]
    public void HandlesStringWithVowels()
    {
        Assert.Equal("N623", Soundex.GenerateSoundex("NewYorkCity"));
    }

    [Fact]
    public void HandlesStringWithSilentLetters()
    {
        Assert.Equal("P260", Soundex.GenerateSoundex("Pfiser"));
    }

    [Fact]
    public void HandlesUppercaseAndLowercase()
    {
        Assert.Equal(Soundex.GenerateSoundex("Lee"), Soundex.GenerateSoundex("LEE"));
    }

    [Fact]
    public void HandlesStringEndingInS()
    {
        Assert.Equal("H213", Soundex.GenerateSoundex("HouseOfDragons"));
    }

    [Fact]
    public void HandlesStringWithConsecutiveSameCodes()
    {
        Assert.Equal("T520", Soundex.GenerateSoundex("Tymczak"));
    }

    [Fact]
    public void HandlesStringWithNoConsonants()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("AeioU"));
    }

    [Fact]
    public void HandlesVeryLongString()
    {
        Assert.Equal("H653", Soundex.GenerateSoundex("Hernandez"));
    }

    [Fact]
    public void HandlesMixedCaseString()
    {
        Assert.Equal("A510", Soundex.GenerateSoundex("AmeBa"));
    }

    [Fact]
    public void HandlesStringWithSpaces()
    {
        Assert.Equal("S534", Soundex.GenerateSoundex("Santa De La Cruz"));
    }

    [Fact]
    public void HandlesHyphenatedString()
    {
        Assert.Equal("M235", Soundex.GenerateSoundex("Mc-Donalds"));
    }
    
    
}
