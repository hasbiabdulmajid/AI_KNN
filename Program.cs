using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace knn
{
	class MainClass
	{
		struct hitungKategori {
			public int kategori;
			public int count;
		};
		struct train
		{
			public int index;
			public double x1;
			public double x2;
			public double x3;
			public double x4;
			public double x5;
			public int y;
		};
		struct traintmp
		{
			public string index;
			public string x1;
			public string x2;
			public string x3;
			public string x4;
			public string x5;
			public string y;
		};
		struct hasil {
			public double jarak;
			public int kategori;
		};
		public class tmpDataTest {
			public void readTest()
			{
				
		
		
		}

	
		public static void Main(string[] args)
		{
				//BEGIN MASUKAN DATA TRAIN & DATA TEST KE ARRAY
			StreamReader reader= new StreamReader(File.OpenRead(@"D:\Backup Collyeah\Tugas\AI\Data Tugas 3 AI\DataTrain_Tugas3_AI.csv"));
			
			traintmp[] dataTmp = new traintmp[801];
			train[] dataTrain = new train[801];
			int i = 0;
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(',');

				dataTmp[i].index = values[0];
				dataTmp[i].x1 = values[1];
				dataTmp[i].x2 = values[2];
				dataTmp[i].x3 = values[3];
				dataTmp[i].x4 = values[4];
				dataTmp[i].x5 = values[5];
				dataTmp[i].y = values[6];
				i++;
			}

			//convert string
			for (int j = 1; j < 801; j++)
			{
				string stringVal = dataTmp[j].index;
				string stringVal1 = dataTmp[j].x1;
				string stringVal2 = dataTmp[j].x2;
				string stringVal3 = dataTmp[j].x3;
				string stringVal4 = dataTmp[j].x4;
				string stringVal5 = dataTmp[j].x5;
				string stringVal6 = dataTmp[j].y;
				if (stringVal1.Contains("."))
					stringVal1 = stringVal1.Replace(".", ",");
				if (stringVal2.Contains("."))
					stringVal2 = stringVal2.Replace(".", ",");
				if (stringVal3.Contains("."))
					stringVal3 = stringVal3.Replace(".", ",");
				if (stringVal4.Contains("."))
					stringVal4 = stringVal4.Replace(".", ",");
				if (stringVal5.Contains("."))
					stringVal5 = stringVal5.Replace(".", ",");

				int idx = System.Convert.ToInt32(stringVal);
				double x1 = System.Convert.ToDouble(stringVal1);
				double x2 = System.Convert.ToDouble(stringVal2);
				double x3 = System.Convert.ToDouble(stringVal3);
				double x4 = System.Convert.ToDouble(stringVal4);
				double x5 = System.Convert.ToDouble(stringVal5);
				int y = System.Convert.ToInt32(stringVal6);
				dataTrain[j].index = idx;
				dataTrain[j].x1 = x1;
				dataTrain[j].x2 = x2;
				dataTrain[j].x3 = x3;
				dataTrain[j].x4 = x4;
				dataTrain[j].x5 = x5;
				dataTrain[j].y = y;
			}
			StreamReader reader2 = new StreamReader(File.OpenRead(@"D:\Backup Collyeah\Tugas\AI\Data Tugas 3 AI\DataTest_Tugas3_AI.csv"));

			traintmp[] dataTmp2 = new traintmp[201];
			train[] dataTest = new train[201];
			int c = 0;
			while (!reader2.EndOfStream)
			{
					var line2 = reader2.ReadLine();
					var values2 = line2.Split(',');

					dataTmp2[c].index = values2[0];
					dataTmp2[c].x1 = values2[1];
					dataTmp2[c].x2 = values2[2];
					dataTmp2[c].x3 = values2[3];
					dataTmp2[c].x4 = values2[4];
					dataTmp2[c].x5 = values2[5];
					dataTmp2[c].y = values2[6];
					c++;
				}
			for (int j = 1; j< 201; j++)
			{
					string stringVal = dataTmp2[j].index;
					string stringVal1 = dataTmp2[j].x1;
					string stringVal2 = dataTmp2[j].x2;
					string stringVal3 = dataTmp2[j].x3;
					string stringVal4 = dataTmp2[j].x4;
					string stringVal5 = dataTmp2[j].x5;
					string stringVal6 = dataTmp2[j].y;
					if (stringVal1.Contains("."))
						stringVal1 = stringVal1.Replace(".", ",");
					if (stringVal2.Contains("."))
						stringVal2 = stringVal2.Replace(".", ",");
					if (stringVal3.Contains("."))
						stringVal3 = stringVal3.Replace(".", ",");
					if (stringVal4.Contains("."))
						stringVal4 = stringVal4.Replace(".", ",");
					if (stringVal5.Contains("."))
						stringVal5 = stringVal5.Replace(".", ",");

					int idx = System.Convert.ToInt32(stringVal);
					double x1 = System.Convert.ToDouble(stringVal1);
					double x2 = System.Convert.ToDouble(stringVal2);
					double x3 = System.Convert.ToDouble(stringVal3);
					double x4 = System.Convert.ToDouble(stringVal4);
					double x5 = System.Convert.ToDouble(stringVal5);

					dataTest[j].index = idx;
					dataTest[j].x1 = x1;
					dataTest[j].x2 = x2;
					dataTest[j].x3 = x3;
					dataTest[j].x4 = x4;
					dataTest[j].x5 = x5;
					dataTest[j].y = 4;
				}

				//END MEMASUKAN ARRAY
				List<int> hasilKategori = new List<int>();

				//MENGHITUNG JARAK SETIAP DATA TEST KE DATA TRAI
				for (int j = 1; j< 201; j++) {
					hasil[] tmpHasil = new hasil[801];
					for (int l = 1; l < 801; l++) {
						//MENGITUNG JARAK EUCLEDIAN
						double eucledian = Math.Sqrt(Math.Pow((dataTrain[l].x1-dataTest[j].x1),2) + Math.Pow((dataTrain[l].x2-dataTest[j].x2),2) +Math.Pow((dataTrain[l].x3-dataTest[j].x3),2) + Math.Pow((dataTrain[l].x4-dataTest[j].x4),2) + Math.Pow((dataTrain[l].x5-dataTest[j].x5),2)  );
						//MEMASUKKAN DATA JARAK & KELAS KE DALAM ARRAY
						tmpHasil[l].jarak = eucledian;
						tmpHasil[l].kategori = dataTrain[l].y;
					}
					//tmpHasil.OrderBy(x=>x.jarak);
					Array.Sort(tmpHasil, (x, y) => x.jarak.CompareTo(y.kategori));
					hitungKategori[] hitung = new hitungKategori[4];
					hitung[0].kategori = 0;
					hitung[1].kategori = 1;
					hitung[2].kategori = 2;
					hitung[3].kategori = 3;

					//MENGHITUNG MAYORITAS KELAS KATEGORI BERDASARKAN K=11
					for (int k = 1; k < 12; k++) {
						if (tmpHasil[k].kategori == 0) {
							hitung[0].count += 1;
						}
						else if (tmpHasil[k].kategori == 1) {
							hitung[1].count += 1;
						}
						else if (tmpHasil[k].kategori == 2) {
							hitung[2].count += 1;
						}
						else if (tmpHasil[k].kategori == 3) {
							hitung[3].count += 1;
						}
					
					}
					//hitung.OrderBy(x=>x.count);
					Array.Sort(hitung, (x, y) => y.count.CompareTo(x.count));
					//Console.WriteLine(hitung[0].kategori + " " + hitung[0].count);
					//Console.WriteLine(hitung[1].kategori + " " + hitung[1].count);
					//Console.WriteLine(hitung[2].kategori + " " + hitung[2].count);
					//Console.WriteLine(hitung[3].kategori + " " + hitung[3].count);
					//Console.ReadKey();
					dataTest[j].y = hitung[0].kategori;

					hasilKategori.Add(dataTest[j].y);







				
				}
				for (int j = 1; j < 201;j++) {
				Console.Write(dataTest[j].index + " "+dataTest[j].y);
					Console.WriteLine();
				}
				using (var file = File.CreateText(@"C:\Users\SyekhTampan\Desktop\Tugas2AI\DataTebakanTugas3.csv"))
				    {
						file.WriteLine("Kategori");
				        foreach(var arr in hasilKategori) {
							int count = 0;

							if (count <= 200) { 
							    file.WriteLine(string.Join(",", arr));
							}
							count++;
				        }
				    }
				Console.ReadKey();



			}












			
		}
	}
}
