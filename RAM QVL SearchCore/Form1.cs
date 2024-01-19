using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using QuodLib.Strings;
using QuodLib.Drawing;

namespace RAM_QVL_Search
{
	public partial class Form1 : Form
	{
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
			public static implicit operator ListViewItem(Kit kit) {
				return new ListViewItem(new string[] {
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

			}
		}

		readonly Color CLR_T_NORM = classGraphics.CColor(58, 136, 198);
		readonly Color CLR_C_NORM = classGraphics.MColor(31);
		readonly Color CLR_C_DIS = classGraphics.CColor(130, 135, 144);
		readonly Color CLR_B_NORM = classGraphics.MColor(47);

		readonly Color CLR_FLD_T_NORM = classGraphics.CColor(58, 136, 198);
		readonly Color CLR_FLD_T_ERR = classGraphics.CColor(58, 136, 198);
		readonly Color CLR_FLD_B_NORM = classGraphics.MColor(39);
		readonly Color CLR_FLD_B_ERR = classGraphics.CColor(81, 31, 31);

		readonly Color CLR_FL_T_NORM = classGraphics.CColor(58, 136, 198);
		readonly Color CLR_FL_T_ERR = classGraphics.CColor(58, 136, 198);
		readonly Color CLR_FL_B_NORM = classGraphics.MColor(31);
		readonly Color CLR_FL_B_ERR = classGraphics.CColor(57, 27, 27);
		List<Kit> Kits = new List<Kit>();
		public Form1()
		{
			InitializeComponent();
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			int ik = 0;
			string src = Clipboard.GetText().Replace("\r\n", "\n").Replace("●", "•").Replace("•\n", "•");
			src = src.FromIndex(src.IndexOf("4 DIMM\n") + "4 DIMM\n".Length);
			src = src.GetBefore("Vendor");

			while (src.Length > 3) {
				ik++;
				int idx = src.IndexOf("•");
				string kit_s = "";

				if (idx < src.Length) {
					idx = src.SeekNot(idx, '•', true);
					if (idx < src.IndexOf("•")) idx = src.Length;
					kit_s = src.TowardIndex(idx, false);
					src = src.FromIndex(idx, true);
				} else {
					kit_s = src;
					src = "";
				}

				if (kit_s == "") continue;

				Kit kit_n = new Kit(kit_s);
				//if (!KnownVendor(kit_n.Vendor)) continue;

				Kits.Add(kit_n);
				lvQVL.Items.Add(kit_n);
				if (ik != Kits.Count || kit_n.PartNo == "KS2400D4P150B08G")
					ik = ik;
			}

			Search.Vendors = (from Kit kit in Kits orderby kit.Vendor select kit.Vendor)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.StickSizes = (from Kit kit in Kits orderby kit.Size_Stick select kit.Size_Stick + " GB")
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.SS_DS = (from Kit kit in Kits orderby kit.SS_DS descending select kit.SS_DS)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.Chips = (from Kit kit in Kits orderby kit.Chip select kit.Chip)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.Timings = (from Kit kit in Kits orderby kit.CL select kit.CL)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.Speeds = (from Kit kit in Kits orderby kit.Speed descending select kit.Speed)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();
			Search.Speeds_Ryzen3 = (from Kit kit in Kits orderby kit.Speed_Ryzen3 descending select kit.Speed)
				.GroupBy(i => i)
				.Select(g => g.First())
				.ToList();

			int y = 0, x = gbVdr.Location.X;

			//Vendors
			fillGroupbox(gbVdr, Search.Vendors);

			//Stick size
			fillGroupbox(gbStickSze, Search.StickSizes);

			//SS / DS
			fillGroupbox(gbSS_DS, Search.SS_DS);

			//Chips
			fillGroupbox(gbChp, Search.Chips);

			//Timings
			fillGroupbox(gbTmgs, Search.Timings);

			//Speed
			fillGroupbox(gbSpd, Search.Speeds);

			//Speed (Ryzen 5x)
			fillGroupbox(gbSpd5k, Search.Speeds_Ryzen3);

			//---- local methods
			void fillGroupbox<T>(GroupBox gb, List<T> lst) {
				gb.Location = new Point(x, gb.Location.Y);
				for (int i = 0; i < lst.Count; i++) {
					CheckBox chk = new CheckBox();
					chk.Text = "" + lst[i];
					chk.AutoSize = true;
					chk.ForeColor = classGraphics.CColor(58, 136, 198);
					gb.Controls.Add(chk);

					y = 15 + (i * chk.Height);
					chk.Location = new Point(10, y);
					gb.Height = 15 + y + chk.Height;
					gb.Width = Math.Max(gb.Width, chk.Width + 15);
				}
				x += gb.Width + 15;

				this.Height = Math.Max(this.Height, gb.Location.Y + 32 + gb.Height + 15);
			}

		}
		private int lstSort_idx = -1;
		private void lstSort_KeyUp(object sender, KeyEventArgs e)
		{
			int idx = lstSort_idx;
			if (e.KeyCode == Keys.Up) {
				if (idx > 0) {
					string temp = (string)lstSort.Items[idx - 1];
					lstSort.Items[idx - 1] = lstSort.Items[idx];
					lstSort.Items[idx] = temp;
					lstSort_idx -= 1;
				}
			}  else if (e.KeyCode == Keys.Down) {
				if (idx < lstSort.Items.Count - 1) {
					string temp = (string)lstSort.Items[idx + 1];
					lstSort.Items[idx + 1] = lstSort.Items[idx];
					lstSort.Items[idx] = temp;
					lstSort_idx += 1;
				}
			}
			lstSort.SelectedIndex = lstSort_idx;
		}

		private void lstSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (lstSort_idx < 0) lstSort_idx = lstSort.SelectedIndex;
		}

		private void lstSort_Click(object sender, EventArgs e)
		{
			lstSort_idx = lstSort.SelectedIndex;
		}
		public static string FormatVendor(string vendor) {
			vendor = vendor.ToUpper();
			vendor = vendor.Replace("A-DATA", "ADATA")
							.Replace(new string[] {"HYPER-X", "HYPER X", "HYPERX"}, "HYPER X")
							.Replace(new string[] {"HYNIX"}, "SK HYNIX").Replace("SK SK", "SK")
							.Replace(new string[] {"TEAM", "TEAM GROUP"}, "TEAMGROUP").Replace("TEAM TEAM", "TEAM").Replace("TEAMGROUPGROUP", "TEAMGROUP")
							.Replace("AORUS", "GIGABYTE");

			return vendor.Capitalize();
		}
		private static bool KnownVendor(string vendor) {
			return (new string[] {"ADATA", "CORSAIR", "CRUCIAL", "G.SKILL", "HYPER X", "KINGSTON", "SK HYNIX", "TEAMGROUP", "THERMALTAKE" }).Contains(vendor.ToUpper());
		}
		private void btnQry_Click(object sender, EventArgs e)
		{
			lvQVL.Items.Clear();

			for (int i = 0; i < lstSort.Items.Count; i++)
				(from Search.searchLookupItem sl in Search.SearchLookup where sl.Text == lstSort.Items[i].ToString() select sl).ToList()[0].Sort = i;

			List<(FieldInfo field, Search.searchLookupItem lookup)> sorts =
					(from f in typeof(Kit).GetFields()
						join s in Search.SearchLookup 
						on f.Name equals s.Field orderby s.Sort select (f, s)).ToList();

			foreach (Kit k in (from Kit kit in Kits
								orderby sorts[0].field.GetValue(kit),
									sorts[1].field.GetValue(kit),
									sorts[2].field.GetValue(kit),
									sorts[3].field.GetValue(kit),
									sorts[4].field.GetValue(kit),
									sorts[5].field.GetValue(kit),
									sorts[6].field.GetValue(kit)
								where filter(kit) select kit).ToList()
					) {
				lvQVL.Items.Add(k);
			}


			bool filter(Kit k) {
				bool rtn = true;
				for (int i = 0; i < lstSort.Items.Count && rtn; i++) {
					List<string> selections = getSelections(sorts[i].lookup.Text);
					if (selections.Count < 1) continue;

					rtn &= selections.Contains("" + sorts[i].field.GetValue(k));
				}
				return rtn;
			}
			List<string> getSelections(string text) {
				return (from Control ctrl in 
								(from GroupBox gb in new[] {gbVdr, gbStickSze, gbSS_DS, gbTmgs, gbChp, gbSpd, gbSpd5k} where gb.Text == text select gb).ToList()[0].Controls
						   where ((CheckBox)ctrl).Checked select ctrl.Text.Replace(" GB", "")).ToList();
			}
		}
		private void btnCpy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lvQVL.SelectedItems[0].SubItems[1].Text);
		}
	}
}
