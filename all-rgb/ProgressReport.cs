using Zenith.Drawing;

namespace all_rgb
{
	//public class BaseAction : IAction
	//{
	//	public void Run()
	//	{
	//		if (_task == null && _task?.Status == TaskStatus.Created && Action != null && !tokenSource.IsCancellationRequested)
	//		{
	//			token = tokenSource.Token;
	//			var progress = new Progress<ProgressReport>(value => ProgressCallback(value));
	//			_task = Task.Run(Action.Invoke(progress), token);
	//		}
	//	}

	//	public void Pause()
	//	{

	//	}

	//	public void Abort()
	//	{
	//		if (!tokenSource.IsCancellationRequested)
	//		{
	//			tokenSource.Cancel();
	//		}
	//	}

	//	CancellationToken token;
	//	CancellationTokenSource tokenSource;

	//	public Task _task;

	//	Action<ProgressReport> ProgressCallback = new((_) => { });

	//	IProgress<ProgressReport> Progress;
	//	Action<IProgress<ProgressReport>> Action { get; init; }
	//}

	public record ProgressReport(float Percent, string ETAText, ImageBuffer ProgressReportImageBuffer, string BatchInfo, float CurrentAverageRadius);
}
