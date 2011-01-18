using System.Collections.Generic;

namespace AwesomeShell
{
	internal static class Extensions
	{
		internal static IEnumerable<T> ToEnumerable<T>(this T item)
		{
			yield return item;
		}

		private static IEnumerable<T> Concat<T>(this IEnumerable<T> list, T item)
		{
			foreach (var itemInList in list)
				yield return itemInList;

			yield return item;
		}

		private static IEnumerable<T> Concat<T>(this T item, IEnumerable<T> list)
		{
			yield return item;

			foreach (var itemInList in list)
				yield return itemInList;
		}
	}
}