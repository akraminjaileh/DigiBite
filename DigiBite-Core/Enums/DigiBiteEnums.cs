namespace DigiBite_Core.Enums
{
    public static class DigiBiteEnums
    {
        public enum DefaultRole
        {
            Admin,
            Manager,
            Waiter,
            Chef,
            Cashier,
            Delivery,
            Customer
        }

        public enum BanType
        {
            Temporary = 101,
            Permanent,
            NoShowBan,
            PaymentIssueBan,
            MisconductBan,
            Other
        }

        public enum Gender
        {
            Male = 201,
            Female,
            Unknown
        }
        public enum OrderStatus
        {
            New = 301,
            Confirmed,
            Cancelled,
            Ready,
            Served,
            Delivered
        }

        public enum CartStatus
        {
            Active = 401,
            Ordered,
            Abandoned
        }

        public enum PaymentStatus
        {
            Pending = 501,
            Paid,
            Failed
        }
        public enum PaymentMethod
        {
            CreditCard = 601,
            Cash,
            Wallet
        }

        public enum IngredientUnit
        {
            gm = 701,
            ml,
            Pieces
        }

        public enum IngredientType
        {
            Free = 801,
            Paid
        }

        public enum FileType
        {
            Jpg = 901,
            Png,
            Gif,
            jpeg,
            Svg,
            Pdf
        }



    }
}
