using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuodLib.Strings;

namespace RAM_QVL_Search {
    class Kit
	{
		public string Vendor, PartNo, SS_DS, Chip, CL, Timings_Text;

		public int Sticks, Size_Stick;
		public int Size_Total => Sticks * Size_Stick;
		public int[] Timings;
		public float Voltage;
		public int Speed, Speed_Ryzen3;
		public Dictionary<byte, bool> Dimms;

		public Kit(string source)
		{
			string[] p = source.Split('\n');
			Vendor = FormatVendor(p[0]); //Vendor
			PartNo = p[1]; //#

			//Size
			if (p[2].Contains("(")) p[2] = p[2].GetAfter("(").GetBefore(")"); //16(2*GB) -> 2*8GB

			if (!p[2].Contains("x")) { // 8G, 16GB, etc.
				Size_Stick = int.Parse(p[2].RemoveTerm(" ").GetBefore("G"));
				Sticks = 1;
			} else {
				if (p[2].IndexOf('x') < 3) { // X*YGB
					Sticks = int.Parse("" + p[2][0]);
					Size_Stick = int.Parse(p[2].Split('x')[1].Split('G')[0]);
				} else { //YGB*X
					Size_Stick = int.Parse(p[2].Split('G')[0]); 
					Sticks = int.Parse(p[2].Split('x')[1]);
				}
			}
			SS_DS = p[3]; // (???)
			Chip = FormatVendor(p[4]); //Chip

			//Timings
			Timings = new int[4];
			Timings_Text = p[5].Replace("R", "").Replace("--", "-");
			string[] t = Timings_Text.Split('-');
			for (int i = 0; i < 4; i++)
				Timings[i] = byte.Parse(t[i]);
			CL = "" + Timings[0] + " CL";

			//Voltage
			Voltage = float.Parse(p[6].Replace("V", ""));

			//Speed
			Speed = int.Parse(p[8]);
			Speed_Ryzen3 = int.Parse(p[9]);

			//Dimms
			Dimms = new Dictionary<byte, bool>();
			for (int i = 0; i < 3; i++)
				Dimms.Add((byte)Math.Pow(2, i), p[10].Length > i);
		}

		public static implicit operator ListViewItem(Kit kit)
			=> new ListViewItem(new string[] {
					kit.Vendor, 
					kit.PartNo, $"{kit.Size_Stick}G x{kit.Sticks} = {kit.Size_Total}G{kit.SS_DS}",
					kit.Chip, kit.Timings_Text, 
					Misc.Num_AddCommas(Math.Round(kit.Voltage, 2)).RemoveTrailing('0'),
					kit.Speed.ToString(),
					kit.Speed_Ryzen3.ToString(),
					(kit.Dimms[1] ? "•" : string.Empty), 
					(kit.Dimms[2] ? "•" : string.Empty), 
					(kit.Dimms[4] ? "•" : string.Empty)
				});

        public static string FormatVendor(string vendor)
			=> vendor.ToUpper()
					.Replace("A-DATA", "ADATA")
                    .Replace(new string[] { "HYPER-X", "HYPER X", "HYPERX" }, "HYPER X")
                    .Replace(new string[] { "HYNIX" }, "SK HYNIX").Replace("SK SK", "SK")
                    .Replace(new string[] { "TEAM", "TEAM GROUP" }, "TEAMGROUP").Replace("TEAM TEAM", "TEAM").Replace("TEAMGROUPGROUP", "TEAMGROUP")
                    .Replace("AORUS", "GIGABYTE")
					.Capitalize();

    }
}
