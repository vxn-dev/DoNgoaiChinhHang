using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PayMethod
    {
        public const int COD = 1;
        public const int BANK = 2;
    }

    public class RateRank
    {
        public const int TE = 1; // Tệ
        public const int TB = 2; // Trung bìng
        public const int KHA = 3;// Khá
        public const int TOT = 4;//Tốt
        public const int XS = 5; //Xuất sắc
    }

    public class RateType
    {
        public const int POST = 1;
        public const int PRODUCT = 2;
    }

    public class SaleMode
    {
        public const int ModeOne = 1; // Giảm ngay x đ/sp khi mua từ y sản phẩm
        public const int ModeTwo = 2; // Giảm ngay x đ
    }


    public class ProductState
    {
        public const int HangSapVe = -1;
        public const int HetHang = 0;
        public const int ConHang = 1;
    }

    public class MemberType
    {
        public const int Admin = 1;
        public const int User = 1;
    }

    public class OrderState
    {
        public const int New = 1;
        public const int Processed = 2; 
    }
}
