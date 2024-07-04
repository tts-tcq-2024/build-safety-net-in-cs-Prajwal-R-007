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
        Assert.Equal("G240", Soundex.GenerateSoundex("Giggle"));
    }
    
    [Fact]
    public void CombinesAdjacentSameDigits()
    {
        Assert.Equal("C000", Soundex.GenerateSoundex("Cccc"));
        Assert.Equal("D000", Soundex.GenerateSoundex("Ddt"));
        Assert.Equal("F130", Soundex.GenerateSoundex("Ffifth"));
        Assert.Equal("G200", Soundex.GenerateSoundex("Gggggle"));
    }
    
    [Fact]
    public void HandlesAdjacentSameDigitsSeparatedByHOrW()
    {
        Assert.Equal("C000", Soundex.GenerateSoundex("Chwcch"));
        Assert.Equal("D000", Soundex.GenerateSoundex("Dth"));
        Assert.Equal("F300", Soundex.GenerateSoundex("Fifthw"));
        Assert.Equal("G200", Soundex.GenerateSoundex("Ggiggle"));
    }
    
    [Fact]
    public void ProducesCorrectOutputWithMultipleCharacters()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Soundex"));
        Assert.Equal("H440", Soundex.GenerateSoundex("Hello"));
        Assert.Equal("W643", Soundex.GenerateSoundex("World"));
        Assert.Equal("T235", Soundex.GenerateSoundex("Testing"));
        Assert.Equal("E251", Soundex.GenerateSoundex("Example"));
    }
    
}
