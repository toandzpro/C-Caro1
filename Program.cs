
using System.Text;

public class Program
{
    public static char[] CáiBảng = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static char NgườiChơi = 'X';

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Chào Mừng Bạn Đã Đến Cờ Caro");
        do
        {
            Bảngvẻ();
            Console.WriteLine($"Người Chơi {NgườiChơi}'Dến Lược. Nhập Một Vị Trí (1-9):");
            int a = int.Parse(Console.ReadLine()) - 1;

            if (a >= 0 && a < 9 && CáiBảng[a] != 'X' && CáiBảng[a] != 'O')
            {
                CáiBảng[a] = NgườiChơi;
                if (KiễmTraWin() || KiễmTraRút())
                {
                    Bảngvẻ();
                    Console.WriteLine(KiễmTraWin() ? $"Người Chơi {NgườiChơi} Thắng!" : "Đó là một trận hòa!"); //nếu kiểm tra win = true thì người chơi thắng, còn ko thì đó là một trận hòa
                    break;
                }
                NgườiChơi = (NgườiChơi == 'X') ? 'O' : 'X'; //nếu true '0' nếu false thì 'x'
            }
            else
            {
                Console.WriteLine("Duy Chuyển Khong Hộp Lệ. Thử Lại.");
            }
        } while (true);

        Console.ReadLine();
    }

    public static void Bảngvẻ()
    {
        Console.WriteLine($"{CáiBảng[0]} | {CáiBảng[1]} | {CáiBảng[2]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{CáiBảng[3]} | {CáiBảng[4]} | {CáiBảng[5]}");
        Console.WriteLine("---------");
        Console.WriteLine($"{CáiBảng[6]} | {CáiBảng[7]} | {CáiBảng[8]}");
    }

    public static bool KiễmTraWin()
    {
        return (CáiBảng[0] == NgườiChơi && CáiBảng[1] == NgườiChơi && CáiBảng[2] == NgườiChơi) ||
               (CáiBảng[3] == NgườiChơi && CáiBảng[4] == NgườiChơi && CáiBảng[5] == NgườiChơi) ||
               (CáiBảng[0] == NgườiChơi && CáiBảng[3] == NgườiChơi && CáiBảng[6] == NgườiChơi) ||
               (CáiBảng[1] == NgườiChơi && CáiBảng[4] == NgườiChơi && CáiBảng[7] == NgườiChơi) ||
               (CáiBảng[2] == NgườiChơi && CáiBảng[5] == NgườiChơi && CáiBảng[8] == NgườiChơi) ||
               (CáiBảng[0] == NgườiChơi && CáiBảng[4] == NgườiChơi && CáiBảng[8] == NgườiChơi) ||
               (CáiBảng[2] == NgườiChơi && CáiBảng[4] == NgườiChơi && CáiBảng[6] == NgườiChơi);
    }

    public static bool KiễmTraRút()
    {
        foreach (char cell in CáiBảng) //Vòng lặp này duyệt qua từng ô trên bảng (biến CáiBảng trong trường hợp này là mảng Cáibảng của chúng ta).
        {
            if (cell != 'X' && cell != 'O') // Điều kiện này kiểm tra xem ô hiện tại trên bảng có được điền với ký tự 'X' hoặc 'O' hay không. Nếu không tức là ô đó chưa được điền, điều này cho biết trò chơi chưa kết thúc.
                return false;// Nếu có bất kỳ ô nào trống trên bảng chưa được điền phương thức sẽ trả về giá trị false, cho biết trò chơi chưa kết thúc với kết quả hòa.
        }
        return true; // Nếu tất cả các ô trên bảng đều đã được điền với ký tự 'X' hoặc 'O', phương thức sẽ trả về true, cho biết trò chơi kết thúc với kết quả hòa.
    }
}