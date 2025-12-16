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
            System.Console.Clear();
            TeksBiru("===== MENU BMI =====");
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("1. Hitung BMI");
            System.Console.WriteLine("2. Lihat Riwayat BMI");
            System.Console.WriteLine("3. Hapus Data BMI");
            System.Console.WriteLine("0. Keluar");
            TeksBiru("====================");
            System.Console.ResetColor();

            pilihan = ValidasiInputInt("Pilih", 0, 4);

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
                    HapusBMI();
                    break;
                }
                case 0:
                {
                    break;
                }
            }

            if (pilihan != 0)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Tekan ENTER untuk kembali...");
                System.Console.ReadLine();
            }
        } while (pilihan != 0);
    }

    static void HitungBMI()
    {
        double berat;
        double tinggiCm;
        char jk;

        double tinggiM;
        double bmi;
        string kategori;

        string teksGender;
        berat = ValidasiInputDouble("Berat badan", "kg", 1, 500);
        tinggiCm = ValidasiInputDouble("Tinggi badan", "cm", 1, 250);
        jk = ValidasiInputChar();

        tinggiM = tinggiCm / 100.0;
        bmi = berat / (tinggiM * tinggiM);
        kategori = TentukanKategoriBMI(bmi, jk);

        dataBMI.Add(bmi);
        kategoriBMI.Add(kategori);
        genderBMI.Add(jk);

        teksGender = (jk == 'L' || jk == 'l') ? "Laki-laki" : "Perempuan";

        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine();
        System.Console.WriteLine($"BMI Anda: {bmi.ToString("0.0")}");
        System.Console.WriteLine($"Kategori ('{teksGender}'): {kategori}");
        System.Console.ResetColor();

        RekomendasiBeratBadan(tinggiM, berat);

        System.Console.ResetColor();
    }

    static void RekomendasiBeratBadan(double tinggiM, double berat)
    {
        double idealMin = 18.5 * (tinggiM * tinggiM);
        double idealMax = 22.9 * (tinggiM * tinggiM);

        System.Console.WriteLine();
        System.Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Rekomendasi Berat Badan Normal:");
        System.Console.WriteLine($"Batas minimal : {idealMin.ToString("0.0")} kg");
        System.Console.WriteLine($"Batas maksimal : {idealMax.ToString("0.0")} kg");

        if (berat < idealMin)
        {
            double perluNaik = idealMin - berat;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(
                $"Anda perlu menaikkan berat sekitar {perluNaik.ToString("0.0")} kg."
            );
        }
        else if (berat > idealMax)
        {
            double perluTurun = berat - idealMax;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(
                $"Anda perlu menurunkan berat sekitar {perluTurun.ToString("0.0")} kg."
            );
        }
        else
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Berat badan Anda sudah berada dalam rentang ideal.");
        }
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
                return "Ideal";
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
                return "Ideal";
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
            TeksMerah("Belum ada data BMI.");
        }
        else
        {
            string teksGender;
            TeksBiru("=== RIWAYAT BMI ===");
            for (int i = 0; i < dataBMI.Count; i++)
            {
                if (genderBMI[i] == 'L' || genderBMI[i] == 'l')
                {
                    teksGender = "Laki-laki";
                }
                else
                {
                    teksGender = "Perempuan";
                }

                System.Console.WriteLine(
                    $"{i + 1}. BMI: {dataBMI[i].ToString("0.0")} - {kategoriBMI[i]} ({teksGender})"
                );
            }
        }
    }

    static void HapusBMI()
    {
        if (dataBMI.Count == 0)
        {
            TeksMerah("Tidak ada data untuk dihapus.");
        }
        else
        {
            LihatRiwayatBMI();
            System.Console.WriteLine();
            int index = ValidasiInputInt("Pilih nomor yang ingin dihapus", 1, dataBMI.Count) - 1;

            dataBMI.RemoveAt(index);
            kategoriBMI.RemoveAt(index);
            genderBMI.RemoveAt(index);

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Data berhasil dihapus!");
            System.Console.ResetColor();
        }
    }

    static double ValidasiInputDouble(string nilai, string nilaiUkur, double min, double max)
    {
        double input = 0;
        bool validInput = false;

        while (!validInput)
        {
            System.Console.Write($"Masukkan {nilai} ({nilaiUkur}): ");
            if (double.TryParse(System.Console.ReadLine(), out input))
            {
                if (input <= min || input > max)
                {
                    TeksMerah($"{nilai} harus antara {min + 1} sampai {max} {nilaiUkur}!");
                }
                else
                {
                    validInput = true;
                }
            }
            else
            {
                TeksMerah("Input harus berupa Angka!");
            }
        }
        return input;
    }

    static int ValidasiInputInt(string nilai, int min, int max)
    {
        int input = 0;
        bool validInput = false;

        while (!validInput)
        {
            System.Console.Write($"{nilai}: ");
            if (int.TryParse(System.Console.ReadLine(), out input))
            {
                if (input < min || input > max)
                {
                    TeksMerah($"{nilai} harus antara {min} sampai {max}!");
                }
                else
                {
                    validInput = true;
                }
            }
            else
            {
                TeksMerah("Input harus berupa Angka!");
            }
        }
        return input;
    }

    static char ValidasiInputChar()
    {
        char jk = ' ';
        bool validInput = false;

        while (!validInput)
        {
            System.Console.Write("Jenis kelamin (L/P): ");
            string inputJk = System.Console.ReadLine();

            if (inputJk.Length == 0)
            {
                TeksMerah("Jenis kelamin harus diisi!");
            }
            else
            {
                jk = inputJk[0];
                if (jk == 'L' || jk == 'l' || jk == 'P' || jk == 'p')
                {
                    validInput = true;
                }
                else
                {
                    TeksMerah("Jenis kelamin hanya L atau P!");
                }
            }
        }
        return jk;
    }

    static void TeksMerah(string pesan)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(pesan);
        System.Console.ResetColor();
    }

    static void TeksBiru(string teks)
    {
        System.Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine(teks);
        System.Console.ResetColor();
    }
}
