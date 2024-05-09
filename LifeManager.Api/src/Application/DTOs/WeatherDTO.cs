namespace LifeManage.src.Application.DTOs
{
	public class WeatherData
	{
		public string? Success { get; set; }
		public ResultData? Result { get; set; }
		public RecordData? Records { get; set; }
	}

	public class ResultData
	{
		public string? ResourceId { get; set; }
		public List<Field>? Fields { get; set; }
	}

	public class Field
	{
		public string? Id { get; set; }
		public string? Type { get; set; }
	}

	public class RecordData
	{
		public string? DatasetDescription { get; set; }
		public List<Location>? Location { get; set; }
	}

	public class Location
	{
		public string? LocationName { get; set; }
		public List<WeatherElement>? WeatherElement { get; set; }
	}

	public class WeatherElement
	{
		public string? ElementName { get; set; }
		public List<TimeData>? Time { get; set; }
	}

	public class TimeData
	{
		public string? StartTime { get; set; }
		public string? EndTime { get; set; }
		public Parameter? Parameter { get; set; }
	}

	public class Parameter
	{
		public string? ParameterName { get; set; }
		public string? ParameterValue { get; set; }
		public string? ParameterUnit { get; set; }
	}

}
