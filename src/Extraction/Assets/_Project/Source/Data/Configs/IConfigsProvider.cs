namespace Source.Data
{
    public interface IConfigsProvider
    {
        ICharacterConfig CharacterConfig { get; set; }
        IExtractConfig ExtractConfig { get; set; }
    }
}
