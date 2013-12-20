using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PRI.ProductivityExtensions.WebClientExtensions
{
	public static class WebClientable
	{
		public static Task<string> DownloadStringTaskAsync(this WebClient client, string address)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");
			var uri = new Uri(address);

			return DownloadStringTaskAsync(client, uri);
		}

		public static Task<string> DownloadStringTaskAsync(this WebClient client, Uri uri)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (uri == null) throw new ArgumentNullException("uri");

			var tcs = new TaskCompletionSource<string>();
			client.DownloadStringCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.DownloadStringAsync(uri);
			return tcs.Task;
		}

		public static Task<string> UploadStringTaskAsync(this WebClient client, string address, string data)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");
			if (string.IsNullOrWhiteSpace(data)) throw new ArgumentNullException("data");
			var uri = new Uri(address);
			return UploadStringTaskAsync(client, uri, data);
		}

		public static Task<string> UploadStringTaskAsync(this WebClient client, Uri uri, string data)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (uri == null) throw new ArgumentNullException("uri");
			if (string.IsNullOrWhiteSpace(data)) throw new ArgumentNullException("data");

			var tcs = new TaskCompletionSource<string>();
			client.UploadStringCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.UploadStringAsync(uri, data);
			return tcs.Task;
		}

		public static Task<string> UploadStringTaskAsync(this WebClient client, string address, string method, string data)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");
			if (string.IsNullOrWhiteSpace(method)) throw new ArgumentNullException("method");
			if (string.IsNullOrWhiteSpace(data)) throw new ArgumentNullException("data");
			var uri = new Uri(address);

			return UploadStringTaskAsync(client, uri, method, data);
		}

		public static Task<string> UploadStringTaskAsync(this WebClient client, Uri uri, string method, string data)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (uri == null) throw new ArgumentNullException("uri");
			if (string.IsNullOrWhiteSpace(method)) throw new ArgumentNullException("method");
			if (string.IsNullOrWhiteSpace(data)) throw new ArgumentNullException("data");

			var tcs = new TaskCompletionSource<string>();
			client.UploadStringCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.UploadStringAsync(uri, method, data);
			return tcs.Task;
		}

		public static Task<Stream> OpenReadTaskAsync(this WebClient client, string address)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");

			var uri = new Uri(address);
			return OpenReadTaskAsync(client, uri);
		}

		public static Task<Stream> OpenReadTaskAsync(this WebClient client, Uri uri)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (uri == null) throw new ArgumentNullException("uri");

			var tcs = new TaskCompletionSource<Stream>();
			client.OpenReadCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.OpenReadAsync(uri);
			return tcs.Task;
		}

		public static Task<Stream> OpenWriteTaskAsync(this WebClient client, string address)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");

			var uri = new Uri(address);

			return OpenWriteTaskAsync(client, uri);
		}

		public static Task<Stream> OpenWriteTaskAsync(this WebClient client, Uri uri)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (uri == null) throw new ArgumentNullException("uri");

			var tcs = new TaskCompletionSource<Stream>();
			client.OpenWriteCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.OpenWriteAsync(uri);
			return tcs.Task;
		}

		public static Task<Stream> OpenWriteTaskAsync(this WebClient client, string address, string method)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException("address");
			if (string.IsNullOrWhiteSpace(method)) throw new ArgumentNullException("method");

			var uri = new Uri(address);

			return OpenWriteTaskAsync(client, uri, method);
		}

		public static Task<Stream> OpenWriteTaskAsync(this WebClient client, Uri uri, string method)
		{
			if (client == null) throw new ArgumentNullException("client");
			if (string.IsNullOrWhiteSpace(method)) throw new ArgumentNullException("method");
			if (uri == null) throw new ArgumentNullException("uri");
			var tcs = new TaskCompletionSource<Stream>();

			client.OpenWriteCompleted += (sender, args) =>
			{
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.OpenWriteAsync(uri, method);
			return tcs.Task;
		}
	}
}