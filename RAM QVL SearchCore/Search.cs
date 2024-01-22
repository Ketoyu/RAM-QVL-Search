using System.Collections.Generic;

namespace RAM_QVL_Search {
    static class Search
	{
		public static List<string> Vendors, StickSizes, Chips, SS_DS, Timings;
		public static List<int> Speeds, Speeds_Ryzen3;
		public class searchLookupItem
		{
			public string Field, Text, List;
			public int Sort;
		}
		public static List<searchLookupItem> SearchLookup = new List<searchLookupItem>()
			{
				new searchLookupItem() {Field = "Vendor", Text = "Vendor", List = "Vendors"},
				new searchLookupItem() {Field = "Size_Stick", Text = "Stick size", List = "StickSizes"},
				new searchLookupItem() {Field = "SS_DS", Text = "SS / DS", List = "SS_DS"},
				new searchLookupItem() {Field = "CL", Text = "Timings", List = "Timings"},
				new searchLookupItem() {Field = "Chip", Text = "Chip", List = "Chips"},
				new searchLookupItem() {Field = "Speed", Text = "Speed", List = "Speeds"},
				new searchLookupItem() {Field = "Speed_Ryzen3", Text = "Speed (5k)", List = "Speeds_Ryzen3"}
			};
	}
}
