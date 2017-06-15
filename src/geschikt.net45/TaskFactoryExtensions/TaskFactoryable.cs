#if NET4_5
using System;
using System.Threading.Tasks;

namespace PRI.ProductivityExtensions.TaskFactoryExtensions
{
	public static class TaskFactoryable
	{
		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, null);
		}

		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><param name="creationOptions">The TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task"/>.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception><exception cref="T:System.ArgumentOutOfRangeException">The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. For more information, see the Remarks for <see cref="M:System.Threading.Tasks.TaskFactory.FromAsync(System.Func{System.AsyncCallback,System.Object,System.IAsyncResult},System.Action{System.IAsyncResult},System.Object,System.Threading.Tasks.TaskCreationOptions)"/></exception>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1>(this TaskFactory taskFactory, Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TaskCreationOptions creationOptions)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, null, creationOptions);
		}

		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception>
		/// <typeparam name="TArg2">The type of the third argument passed to <paramref name="beginMethod"/> delegate.</typeparam>
		/// <param name="arg2">The second argument passed to the <paramref name="beginMethod"/> delegate.</param>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1, TArg2>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, arg2, null);
		}

		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><param name="creationOptions">The TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task"/>.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception><exception cref="T:System.ArgumentOutOfRangeException">The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. For more information, see the Remarks for <see cref="M:System.Threading.Tasks.TaskFactory.FromAsync(System.Func{System.AsyncCallback,System.Object,System.IAsyncResult},System.Action{System.IAsyncResult},System.Object,System.Threading.Tasks.TaskCreationOptions)"/></exception>
		/// <typeparam name="TArg2">The type of the third argument passed to <paramref name="beginMethod"/> delegate.</typeparam>
		/// <param name="arg2">The second argument passed to the <paramref name="beginMethod"/> delegate.</param>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1, TArg2>(this TaskFactory taskFactory, Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TaskCreationOptions creationOptions)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, arg2, null, creationOptions);
		}

		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception>
		/// <typeparam name="TArg2">The type of the third argument passed to <paramref name="beginMethod"/> delegate.</typeparam><typeparam name="TArg3">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam>
		/// <param name="arg2">The second argument passed to the <paramref name="beginMethod"/> delegate.</param><param name="arg3">The third argument passed to the <paramref name="beginMethod"/> delegate.</param>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1, TArg2, TArg3>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, arg2, arg3, null);
		}

		/// <summary>
		///  Extends FromAsync so that when a state object is not needed, null does not need to be passed.
		/// </summary>
		/// <param name="taskFactory"></param>
		/// <param name="beginMethod">The delegate that begins the asynchronous operation.</param><param name="endMethod">The delegate that ends the asynchronous operation.</param><param name="arg1">The first argument passed to the <paramref name="beginMethod"/> delegate.</param><param name="creationOptions">The TaskCreationOptions value that controls the behavior of the created <see cref="T:System.Threading.Tasks.Task"/>.</param><typeparam name="TArg1">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam><exception cref="T:System.ArgumentNullException">The exception that is thrown when the <paramref name="beginMethod"/> argument is null.-or-The exception that is thrown when the <paramref name="endMethod"/> argument is null.</exception><exception cref="T:System.ArgumentOutOfRangeException">The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. The exception that is thrown when the <paramref name="creationOptions"/> argument specifies an invalid TaskCreationOptions value. For more information, see the Remarks for <see cref="M:System.Threading.Tasks.TaskFactory.FromAsync(System.Func{System.AsyncCallback,System.Object,System.IAsyncResult},System.Action{System.IAsyncResult},System.Object,System.Threading.Tasks.TaskCreationOptions)"/></exception>
		/// <typeparam name="TArg2">The type of the third argument passed to <paramref name="beginMethod"/> delegate.</typeparam><typeparam name="TArg3">The type of the first argument passed to the <paramref name="beginMethod"/> delegate.</typeparam>		/// <returns></returns>
		/// <param name="arg2">The second argument passed to the <paramref name="beginMethod"/> delegate.</param><param name="arg3">The third argument passed to the <paramref name="beginMethod"/> delegate.</param>
		/// <returns>
		/// The created <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public static Task FromAsync<TArg1, TArg2, TArg3>(this TaskFactory taskFactory, Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, TaskCreationOptions creationOptions)
		{
			if (taskFactory == null) throw new ArgumentNullException("taskFactory");
			return taskFactory.FromAsync(beginMethod, endMethod, arg1, arg2, arg3, null, creationOptions);
		}
	}
}
#endif // NET4_5