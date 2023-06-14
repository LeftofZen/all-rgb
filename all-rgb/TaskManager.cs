using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace all_rgb
{
	public interface IProcGenTask
	{ }

	public struct ProcGenTask<TResult, TProgressInfo> : IProcGenTask
	{
		public IProgress<TProgressInfo> Progress { get; init; }
		public Func<TResult> Function { get; init; }
		public Task<TResult> Task { get; set; }
	}

	public class ProcGenTaskScheduler : INotifyPropertyChanged
	{
		public ProcGenTaskScheduler()
		{
			ScheduledTasks = new List<IProcGenTask>();
			CancellationTokenSource = new CancellationTokenSource();
		}

		public ICollection<IProcGenTask> ScheduledTasks { get; init; }

		CancellationTokenSource CancellationTokenSource { get; init; }


		public Task<TResult> QueueTask<TResult, TProgressInfo>(Func<IProgress<TProgressInfo>, TResult> func, Action<TProgressInfo> progressAction)
		{
			var progress = new Progress<TProgressInfo>(progressAction);
			var procGenTask = new ProcGenTask<TResult, TProgressInfo> { Function = () => func(progress), Progress = progress };
			var task = new Task<TResult>(procGenTask.Function, CancellationTokenSource.Token);
			procGenTask.Task = task;
			ScheduledTasks.Add(procGenTask);
			OnPropertyChanged(nameof(ScheduledTasks));
			_ = task.ContinueWith((_) => RemoveTask(procGenTask));
			task.Start();
			return task;
		}
		protected virtual void OnPropertyChanged(string propertyName)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private void RemoveTask<TResult, TProgressInfo>(ProcGenTask<TResult, TProgressInfo> procGenTask)
		{
			ScheduledTasks.Remove(procGenTask);
			OnPropertyChanged(nameof(ScheduledTasks));
		}

		public void CancelAllTasks()
			=> CancellationTokenSource.Cancel();

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
