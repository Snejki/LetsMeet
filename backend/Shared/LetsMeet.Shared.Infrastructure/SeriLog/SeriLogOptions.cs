namespace LetsMeet.Shared.Infrastructure.SeriLog;

public class SeriLogOptions
{
    public const string SectionName = "SeriLog";
    
    public FileOptions? File { get; set; }
    public SeqOptions? Seq { get; set; }

    public sealed class FileOptions : Options
    {
        public string? FilePath { get; set; }
        public string? LogTemplate { get; set; }
    }

    public sealed class SeqOptions : Options
    {
        public string? ServerUrl { get; set; }
    }

    public abstract class Options
    {
        public bool Enabled { get; set; }
    }
}