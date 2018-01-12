using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BitDiffer.Core;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class when_api_changes
	{
		private static string NugetPackageId = "ProductivityExtensions";
		private static string NugetOrgPackageSourceText = "https://api.nuget.org/v3/index.json";

		[Test]
		public async Task then_there_are_no_breaking_changes()
		{
			var source = new PackageSource(NugetOrgPackageSourceText);
			var providers = new List<Lazy<INuGetResourceProvider>>();
			providers.AddRange(Repository.Provider.GetCoreV3());
			var repo = new SourceRepository(source, providers);
			var metadataResource = repo.GetResource<PackageMetadataResource>();
			var searchResult =
				await metadataResource.GetMetadataAsync(NugetPackageId, false, false, NullLogger.Instance, CancellationToken.None);
			var packageSearchMetadata = searchResult.OrderByDescending(e => e.Identity.Version, VersionComparer.VersionRelease).First();
			Console.WriteLine(packageSearchMetadata.Description);
			var dl = repo.GetResource<DownloadResource>();
			using (var ephemeralDirectory = new EphemeralDirectory())
			{
				var directory = ephemeralDirectory.Path;
				using (var cacheContext = new SourceCacheContext())
				{
					var context = new PackageDownloadContext(cacheContext);
					using (var downloadResult = await dl.GetDownloadResourceResultAsync(packageSearchMetadata.Identity, context,
						directory, NullLogger.Instance, CancellationToken.None))
					{
						var oldAssemblyPath = typeof(PRI.ProductivityExtensions.ActionExtensions.Actionable).Assembly.Location;
						var oldFileName = Path.GetFileName(oldAssemblyPath);
						var newAssemblyPath = downloadResult.PackageReader.GetFiles().FirstOrDefault(e =>
							string.Compare(Path.GetFileName(e), oldFileName, StringComparison.OrdinalIgnoreCase) == 0);
						newAssemblyPath = Path.Combine(directory, packageSearchMetadata.Identity.Id,
							packageSearchMetadata.Identity.Version.ToString(), newAssemblyPath);
						var ac = new AssemblyComparer().CompareAssemblyFiles(newAssemblyPath, newAssemblyPath);
						Assert.IsTrue(ac.Groups.Count > 0);
						Assert.IsFalse(ac.Groups[0].HasErrors);
						Assert.IsNotNull(ac);
					}
				}
			}
		}

		public sealed class EphemeralDirectory : IDisposable
		{
			private readonly Lazy<string> _lazy;
			private bool _pathCreated;

			public EphemeralDirectory()
			{
				_lazy = new Lazy<string>(() =>
				{
					var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());
					var fullName = Directory.CreateDirectory(path).FullName;
					_pathCreated = true;
					return fullName;
				});
			}

			public string Path => _lazy.Value;

			public void Dispose()
			{
				if (_pathCreated)
				{
					Directory.Delete(Path, recursive: true);
				}
			}
		}
	}
	
}