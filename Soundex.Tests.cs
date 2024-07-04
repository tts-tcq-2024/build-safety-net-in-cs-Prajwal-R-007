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
        Assert.Equal("C234", Soundex.GenerateSoundex("Cat"));
        Assert.Equal("D300", Soundex.GenerateSoundex("Dog"));
        Assert.Equal("F100", Soundex.GenerateSoundex("Fifth"));
        Assert.Equal("G200", Soundex.GenerateSoundex("Giggle"));
        Assert.Equal("P100", Soundex.GenerateSoundex("Pup"));
        Assert.Equal("V100", Soundex.GenerateSoundex("Viva"));
        Assert.Equal("L400", Soundex.GenerateSoundex("Love"));
        Assert.Equal("M500", Soundex.GenerateSoundex("Mama"));
        Assert.Equal("N500", Soundex.GenerateSoundex("Nanny"));
        Assert.Equal("R600", Soundex.GenerateSoundex("Rarity"));
    }
    
    [Fact]
    public void CombinesAdjacentSameDigits()
    {
        Assert.Equal("C234", Soundex.GenerateSoundex("Cccc"));
        Assert.Equal("D300", Soundex.GenerateSoundex("Ddt"));
        Assert.Equal("F100", Soundex.GenerateSoundex("Ffifth"));
        Assert.Equal("G200", Soundex.GenerateSoundex("Gggggle"));
        Assert.Equal("P100", Soundex.GenerateSoundex("Ppup"));
        Assert.Equal("V100", Soundex.GenerateSoundex("Vviva"));
        Assert.Equal("L400", Soundex.GenerateSoundex("Llllove"));
        Assert.Equal("M500", Soundex.GenerateSoundex("Mmama"));
        Assert.Equal("N500", Soundex.GenerateSoundex("Nnnanny"));
        Assert.Equal("R600", Soundex.GenerateSoundex("Rrarity"));
    }
    
    [Fact]
    public void HandlesAdjacentSameDigitsSeparatedByHOrW()
    {
        Assert.Equal("C234", Soundex.GenerateSoundex("Chwcch"));
        Assert.Equal("D300", Soundex.GenerateSoundex("Dth"));
        Assert.Equal("F100", Soundex.GenerateSoundex("Fifthw"));
        Assert.Equal("G200", Soundex.GenerateSoundex("Ggiggle"));
        Assert.Equal("P100", Soundex.GenerateSoundex("Phup"));
        Assert.Equal("V100", Soundex.GenerateSoundex("Vivah"));
        Assert.Equal("L400", Soundex.GenerateSoundex("Lwlove"));
        Assert.Equal("M500", Soundex.GenerateSoundex("Mnma"));
        Assert.Equal("N500", Soundex.GenerateSoundex("Nnnannyw"));
        Assert.Equal("R600", Soundex.GenerateSoundex("Rwrarity"));
    }
    
    [Fact]
    public void ProducesCorrectOutputWithMultipleCharacters()
    {
        Assert.Equal("S530", Soundex.GenerateSoundex("Soundex"));
        Assert.Equal("H440", Soundex.GenerateSoundex("Hello"));
        Assert.Equal("W324", Soundex.GenerateSoundex("World"));
        Assert.Equal("T630", Soundex.GenerateSoundex("Testing"));
        Assert.Equal("E623", Soundex.GenerateSoundex("Example"));
        Assert.Equal("I622", Soundex.GenerateSoundex("Interview"));
    }
    
}
