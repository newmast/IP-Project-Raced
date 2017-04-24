namespace Asset
{
    using System.Collections.Generic;

    public interface IObstacleProvider
    {
        string DirectoryName { get; }

        List<string> AllowedObstacles { get; }
    }
}