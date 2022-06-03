using System.Reflection;
using Entities.Concrete;
using Newtonsoft;
using Newtonsoft.Json;

namespace Web.API.Business.Concrete
{
	public static class ReadFile
	{

		public static StaticValue ReadFileValue()
		{
			string path = GetPath(Path.Combine("StaticValue","config.json"));
			string staticValue=File.ReadAllText(path);
			return JsonConvert.DeserializeObject<StaticValue>(staticValue);
		}

		public static string GetPath(string cp) { 
			
			return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase),cp).Replace("file:\\",string.Empty); 
		
		
		}	
	}
}
