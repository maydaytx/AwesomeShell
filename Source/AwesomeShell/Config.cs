using System.Configuration;

namespace AwesomeShell
{
	internal static class Config
	{
		internal static bool AutoComplete
		{
			get
			{
				var autoComplete = ConfigurationManager.AppSettings["AutoComplete"];

				if (autoComplete != null)
					return bool.Parse(autoComplete);

				return true;
			}
		}

		internal static bool UseCamelHumps
		{
			get
			{
				var autoComplete = ConfigurationManager.AppSettings["UseCamelHumps"];

				if (autoComplete != null)
					return bool.Parse(autoComplete);

				return true;
			}
		}
	}
}
