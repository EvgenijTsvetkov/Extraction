namespace Source.Data
{
    public class ConfigsProvider : IConfigsProvider
    {
        public ICharacterConfig CharacterConfig { get; set; }
        public IExtractConfig ExtractConfig { get; set; }
    }
}