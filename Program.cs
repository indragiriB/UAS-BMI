using System;
using System.Collections.Generic;

class Program
{
    static List<double> dataBMI = new List<double>();
    static List<string> kategoriBMI = new List<string>();
    static List<char> genderBMI = new List<char>();

    static void Main()
    {
        int pilihan;
        do
        {
            Console.Clear();
            Judul("===== MENU UTAMA =====");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Menu BMI");
            Console.WriteLine("0. Keluar");
            Console.ResetColor();
            Console.Write("Pilih: ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                {
                    MenuBMI();
                    break;
                }
                case 0:
                {
                    break;
                }
                default:
                {
                    PesanError("Pilihan tidak valid!");
                    break;
                }
            }
        } while (pilihan != 0);

        Console.WriteLine("Keluar...");
    }

    static void MenuBMI()
    {
        int pilihan;
        do
        {
            Console.Clear();
            Judul("===== MENU BMI =====");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Hitung BMI");
            Console.WriteLine("2. Lihat Riwayat BMI");
            Console.WriteLine("3. Statistik BMI");
            Console.WriteLine("4. Edit Data BMI");
            Console.WriteLine("5. Hapus Data BMI");
            Console.WriteLine("0. Kembali");
            Console.ResetColor();
            Console.Write("Pilih: ");
            pilihan = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (pilihan)
            {
                case 1:
                {
                    HitungBMI();
                    break;
                }
                case 2:
                {
                    LihatRiwayatBMI();
                    break;
                }
                case 3:
                {
                    StatistikBMI();
                    break;
                }
                case 4:
                {
                    EditBMI();
                    break;
                }
                case 5:
                {
                    HapusBMI();
                    break;
                }
                case 0:
                {
                    break;
                }
                default:
                {
                    PesanError("Pilihan tidak valid!");
                    break;
                }
            }

            if (pilihan != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Tekan ENTER untuk kembali...");
                Console.ReadLine();
            }
        } while (pilihan != 0);
    }

    static void HitungBMI()
    {
        Console.Write("Masukkan berat badan (kg): ");
        double berat = Convert.ToDouble(Console.ReadLine());

        if (berat <= 0 || berat > 300)
        {
            PesanError("Berat badan tidak valid! (harus 0 - 300 kg)");
            return;
        }

        Console.Write("Masukkan tinggi badan (cm): ");
        double tinggiCm = Convert.ToDouble(Console.ReadLine());

        if (tinggiCm <= 0 || tinggiCm > 250)
        {
            PesanError("Tinggi badan tidak valid! (harus 0 - 250 cm)");
            return;
        }

        Console.Write("Jenis kelamin (L/P): ");
        string inputJk = Console.ReadLine();
        if (inputJk.Length == 0)
        {
            PesanError("Jenis kelamin harus diisi!");
            return;
        }
        char jk = inputJk[0];
        if (jk != 'L' && jk != 'l' && jk != 'P' && jk != 'p')
        {
            PesanError("Jenis kelamin hanya L atau P!");
            return;
        }

        double tinggiM = tinggiCm / 100.0;
        double bmi = berat / (tinggiM * tinggiM);
        string kategori = TentukanKategoriBMI(bmi, jk);

        dataBMI.Add(bmi);
        kategoriBMI.Add(kategori);
        genderBMI.Add(jk);

        string teksGender;
        if (jk == 'L' || jk == 'l')
        {
            teksGender = "Laki-laki";
        }
        else
        {
            teksGender = "Perempuan";
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("BMI Anda: " + bmi.ToString("0.0"));
        Console.WriteLine("Kategori (" + teksGender + "): " + kategori);
        Console.ResetColor();
    }

    static string TentukanKategoriBMI(double bmi, char jk)
    {
        if (jk == 'L' || jk == 'l')
        {
            if (bmi < 18.5)
            {
                return "Kurus";
            }
            else if (bmi < 23)
            {
                return "Normal";
            }
            else if (bmi < 27.5)
            {
                return "Berat Badan Berlebih";
            }
            else
            {
                return "Obesitas";
            }
        }
        else
        {
            if (bmi < 18.5)
            {
                return "Kurus";
            }
            else if (bmi < 23)
            {
                return "Normal";
            }
            else if (bmi < 25)
            {
                return "Berat Badan Berlebih";
            }
            else
            {
                return "Obesitas";
            }
        }
    }

    static void LihatRiwayatBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Belum ada data BMI.");
        }
        else
        {
            Judul("=== RIWAYAT BMI ===");
            for (int i = 0; i < dataBMI.Count; i++)
            {
                string teksGender;
                if (genderBMI[i] == 'L' || genderBMI[i] == 'l')
                {
                    teksGender = "Laki-laki";
                }
                else
                {
                    teksGender = "Perempuan";
                }

                Console.Write(i + 1);
                Console.Write(". BMI: ");
                Console.Write(dataBMI[i].ToString("0.0"));
                Console.Write(" - ");
                Console.Write(kategoriBMI[i]);
                Console.Write(" (");
                Console.Write(teksGender);
                Console.WriteLine(")");
            }
        }
    }

    static void StatistikBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Belum ada data.");
        }
        else
        {
            double total = 0;
            double min = dataBMI[0];
            double max = dataBMI[0];

            for (int i = 0; i < dataBMI.Count; i++)
            {
                total = total + dataBMI[i];
                if (dataBMI[i] < min)
                {
                    min = dataBMI[i];
                }
                if (dataBMI[i] > max)
                {
                    max = dataBMI[i];
                }
            }

            double rataRata = total / dataBMI.Count;

            Judul("=== STATISTIK BMI ===");
            Console.WriteLine("Total data     : " + dataBMI.Count);
            Console.WriteLine("Rata-rata      : " + rataRata.ToString("0.0"));
            Console.WriteLine("BMI terendah   : " + min.ToString("0.0"));
            Console.WriteLine("BMI tertinggi  : " + max.ToString("0.0"));
        }
    }

    static void EditBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Tidak ada data untuk diedit.");
        }
        else
        {
            LihatRiwayatBMI();
            Console.WriteLine();
            Console.Write("Pilih nomor data yang ingin diedit: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index < 0 || index >= dataBMI.Count)
            {
                PesanError("Nomor tidak valid.");
            }
            else
            {
                Console.Write("Masukkan BMI baru: ");
                double bmiBaru = Convert.ToDouble(Console.ReadLine());

                if (bmiBaru <= 0 || bmiBaru > 100)
                {
                    PesanError("BMI tidak masuk akal!");
                }
                else
                {
                    dataBMI[index] = bmiBaru;
                    char jk = genderBMI[index];
                    kategoriBMI[index] = TentukanKategoriBMI(bmiBaru, jk);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Data berhasil diubah!");
                    Console.ResetColor();
                }
            }
        }
    }

    static void HapusBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Tidak ada data untuk dihapus.");
        }
        else
        {
            LihatRiwayatBMI();
            Console.WriteLine();
            Console.Write("Pilih nomor yang ingin dihapus: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index < 0 || index >= dataBMI.Count)
            {
                PesanError("Nomor tidak valid.");
            }
            else
            {
                dataBMI.RemoveAt(index);
                kategoriBMI.RemoveAt(index);
                genderBMI.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data berhasil dihapus!");
                Console.ResetColor();
            }
        }
    }

    static void PesanError(string pesan)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(pesan);
        Console.ResetColor();
    }

    static void Judul(string teks)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(teks);
        Console.ResetColor();
        Console.WriteLine();
    }
}