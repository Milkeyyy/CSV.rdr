using Microsoft.VisualBasic.FileIO;
using Produire;
using System.Collections.Generic;

namespace CSV.rdr
{
	public class CSV形式 : IProduireStaticClass
	{
		[自分("として"), 手順("読み込む")]
		public string[][] 読み込む([から] string ファイル名)
		{
			var list = new List<string[]>();
			using (TextFieldParser parser = new TextFieldParser(ファイル名))
			{
				parser.SetDelimiters(",");
				while (!parser.EndOfData)
				{
					string[] values = parser.ReadFields();
					list.Add(values);
				}
			}
			return list.ToArray();
		}

		[自分("として"), 手順("書き出す")]
		public string 書き出す([を] string[][] 内容)
		{
			var csv = "";
			foreach (string[] row in 内容)
			{
				csv = csv + string.Join(",", row) + "\n";
			}
			return csv;
		}
	}
}
