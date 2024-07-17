namespace Frank.CrossPlatformWindow;

public interface IFrameUpdateAction
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}