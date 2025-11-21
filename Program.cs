using System;
using System.Collections.Generic;

class Program
{
    // ===== DATA PROGRAM =====
    static List<double> dataBMI = new List<double>();
    static List<string> kategoriBMI = new List<string>();

    static List<double> dataBMR = new List<double>();
    static List<string> genderBMR = new List<string>();

    static void Main()
    {
        int pilih;

        do
        {
            Console.Clear();
            Judul("===== MENU UTAMA =====");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Menu BMI");
            Console.WriteLine("2. Menu BMR");
            Console.WriteLine("0. Keluar");
            Console.ResetColor();
            Console.Write("Pilih: ");
            pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1: MenuBMI(); break;
                case 2: MenuBMR(); break;
                case 0: break;
                default: PesanError("Pilihan tidak valid!"); break;
            }

        } while (pilih != 0);

        Console.WriteLine("Keluar...");
    }

    // ================================
    // ========== MENU BMI ============
    // ================================
    static void MenuBMI()
    {
        int pilih;

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
            pilih = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            switch (pilih)
            {
                case 1: HitungBMI(); break;
                case 2: LihatRiwayatBMI(); break;
                case 3: StatistikBMI(); break;
                case 4: EditBMI(); break;
                case 5: HapusBMI(); break;
                case 0: break;
                default: PesanError("Pilihan tidak valid!"); break;
            }

            if (pilih != 0)
            {
                Console.WriteLine("\nTekan ENTER untuk kembali...");
                Console.ReadLine();
            }

        } while (pilih != 0);
    }

    // ================================
    // ======== MENU BMR ==============
    // ================================
    static void MenuBMR()
    {
        int pilih;

        do
        {
            Console.Clear();
            Judul("===== MENU BMR =====");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Hitung BMR");
            Console.WriteLine("2. Lihat Riwayat BMR");
            Console.WriteLine("3. Edit Data BMR");
            Console.WriteLine("4. Hapus Data BMR");
            Console.WriteLine("0. Kembali");
            Console.ResetColor();

            Console.Write("Pilih: ");
            pilih = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            switch (pilih)
            {
                case 1: HitungBMR(); break;
                case 2: LihatRiwayatBMR(); break;
                case 3: EditBMR(); break;
                case 4: HapusBMR(); break;
                case 0: break;
                default: PesanError("Pilihan tidak valid!"); break;
            }

            if (pilih != 0)
            {
                Console.WriteLine("\nTekan ENTER untuk kembali...");
                Console.ReadLine();
            }

        } while (pilih != 0);
    }

    // ======================================
    // ============ BMI SECTION =============
    // ======================================

    static void HitungBMI()
    {
        Console.Write("Masukkan berat badan (kg): ");
        double bb = Convert.ToDouble(Console.ReadLine());

        Console.Write("Masukkan tinggi badan (cm): ");
        double tb = Convert.ToDouble(Console.ReadLine());

        double tinggiMeter = tb / 100.0;
        double bmi = bb / (tinggiMeter * tinggiMeter);

        string kategori = "";
        if (bmi < 18.5) kategori = "Kurus";
        else if (bmi < 25) kategori = "Normal";
        else if (bmi < 30) kategori = "Berlebih";
        else kategori = "Obesitas";

        dataBMI.Add(bmi);
        kategoriBMI.Add(kategori);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBMI: " + bmi.ToString("0.0"));
        Console.WriteLine("Kategori: " + kategori);
        Console.ResetColor();
    }

    static void LihatRiwayatBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Belum ada data BMI.");
            return;
        }

        Judul("=== RIWAYAT BMI ===");
        for (int i = 0; i < dataBMI.Count; i++)
        {
            Console.WriteLine($"{i + 1}. BMI: {dataBMI[i]:0.0} - {kategoriBMI[i]}");
        }
    }

    static void StatistikBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Belum ada data.");
            return;
        }

        double total = 0;
        double min = dataBMI[0];
        double max = dataBMI[0];

        foreach (double bmi in dataBMI)
        {
            total += bmi;
            if (bmi < min) min = bmi;
            if (bmi > max) max = bmi;
        }

        double rata = total / dataBMI.Count;

        Judul("=== STATISTIK BMI ===");
        Console.WriteLine("Total data   : " + dataBMI.Count);
        Console.WriteLine("Rata-rata    : " + rata.ToString("0.0"));
        Console.WriteLine("BMI terendah : " + min.ToString("0.0"));
        Console.WriteLine("BMI tertinggi: " + max.ToString("0.0"));
    }

    static void EditBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Tidak ada data untuk diedit.");
            return;
        }

        LihatRiwayatBMI();
        Console.Write("\nPilih nomor data yang ingin diedit: ");
        int idx = int.Parse(Console.ReadLine()) - 1;

        if (idx < 0 || idx >= dataBMI.Count)
        {
            PesanError("Nomor tidak valid.");
            return;
        }

        Console.Write("Masukkan BMI baru: ");
        double bmiBaru = double.Parse(Console.ReadLine());

        dataBMI[idx] = bmiBaru;
        kategoriBMI[idx] = HitungKategori(bmiBaru);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Data berhasil diubah!");
        Console.ResetColor();
    }

    static void HapusBMI()
    {
        if (dataBMI.Count == 0)
        {
            PesanError("Tidak ada data untuk dihapus.");
            return;
        }

        LihatRiwayatBMI();
        Console.Write("\nPilih nomor yang ingin dihapus: ");
        int idx = Convert.ToInt32(Console.ReadLine()) - 1;

        if (idx < 0 || idx >= dataBMI.Count)
        {
            PesanError("Nomor tidak valid.");
            return;
        }

        dataBMI.RemoveAt(idx);
        kategoriBMI.RemoveAt(idx);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Data berhasil dihapus!");
        Console.ResetColor();
    }

    static string HitungKategori(double bmi)
    {
        if (bmi < 18.5) return "Kurus";
        if (bmi < 25) return "Normal";
        if (bmi < 30) return "Berlebih";
        return "Obesitas";
    }

    // ======================================
    // ============= BMR SECTION ============
    // ======================================

    static void HitungBMR()
    {
        Console.Write("Masukkan berat (kg): ");
        double bb = double.Parse(Console.ReadLine());

        Console.Write("Masukkan tinggi (cm): ");
        double tb = double.Parse(Console.ReadLine());

        Console.Write("Masukkan umur: ");
        int umur = int.Parse(Console.ReadLine());

        Console.Write("Jenis kelamin (L/P): ");
        string jk = Console.ReadLine().ToUpper();

        double bmr;

        // Rumus Harris-Benedict (basic)
        if (jk == "L")
        {
            bmr = 88.4 + (13.4 * bb) + (4.8 * tb) - (5.7 * umur);
            genderBMR.Add("Laki-laki");
        }
        else
        {
            bmr = 447.6 + (9.2 * bb) + (3.1 * tb) - (4.3 * umur);
            genderBMR.Add("Perempuan");
        }

        dataBMR.Add(bmr);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBMR Anda: " + bmr.ToString("0.0"));
        Console.ResetColor();
    }

    static void LihatRiwayatBMR()
    {
        if (dataBMR.Count == 0)
        {
            PesanError("Belum ada data BMR.");
            return;
        }

        Judul("=== RIWAYAT BMR ===");
        for (int i = 0; i < dataBMR.Count; i++)
        {
            Console.WriteLine($"{i + 1}. BMR: {dataBMR[i]:0.0} ({genderBMR[i]})");
        }
    }

    static void EditBMR()
    {
        if (dataBMR.Count == 0)
        {
            PesanError("Tidak ada data untuk diedit.");
            return;
        }

        LihatRiwayatBMR();
        Console.Write("\nPilih nomor yang ingin diedit: ");
        int idx = Convert.ToInt32(Console.ReadLine()) - 1;

        if (idx < 0 || idx >= dataBMR.Count)
        {
            PesanError("Nomor tidak valid.");
            return;
        }

        Console.Write("Masukkan BMR baru: ");
        double baru = Convert.ToDouble(Console.ReadLine());

        dataBMR[idx] = baru;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Data berhasil diubah!");
        Console.ResetColor();
    }

    static void HapusBMR()
    {
        if (dataBMR.Count == 0)
        {
            PesanError("Tidak ada data.");
            return;
        }

        LihatRiwayatBMR();
        Console.Write("\nPilih nomor yang ingin dihapus: ");
        int idx = Convert.ToInt32(Console.ReadLine()) - 1;

        if (idx < 0 || idx >= dataBMR.Count)
        {
            PesanError("Nomor tidak valid.");
            return;
        }

        dataBMR.RemoveAt(idx);
        genderBMR.RemoveAt(idx);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Data berhasil dihapus!");
        Console.ResetColor();
    }

    // ======================================
    // ============ UTILITAS ===============
    // ======================================
    static void PesanError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    static void Judul(string txt)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(txt);
        Console.ResetColor();
        Console.WriteLine();
    }
}
