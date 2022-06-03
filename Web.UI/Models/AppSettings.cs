using Entities.Concrete;
using Newtonsoft.Json;
using System.Reflection;

namespace Web.UI.Models
{
	public static class AppSettings
	{
		public static UIStaticValue ReadFileValue()
		{
			string path = GetPath(Path.Combine("StaticValue", "config.json"));
			string staticValue = File.ReadAllText(path);
			return JsonConvert.DeserializeObject<UIStaticValue>(staticValue);
		}

		public static string GetPath(string cp)
		{

			return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), cp).Replace("file:\\", string.Empty);


		}
	}
}
