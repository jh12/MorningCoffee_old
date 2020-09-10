namespace MorningCoffee.Shared.Configuration
{
    public class LaunchProgramRoutineConfiguration
    {
        public ProcessDefinition[]? Processes { get; set; }
    }

    public class ProcessDefinition
    {
        public string Name { get; set; }
        public string FileNameOrPath { get; set; }
        public string? Arguments { get; set; }
    }
}