using System;


namespace HurtLogger
{
	public static class Helper 
	{
		public static DateTime ConvertToLocalTime(DateTime utcDateTime){
			string utcDateTimeString = utcDateTime.ToString ();
			DateTime convertDateTime = DateTime.SpecifyKind(
				DateTime.Parse(utcDateTimeString),
				DateTimeKind.Utc);
			return convertDateTime.ToLocalTime();
		}

	}
}


