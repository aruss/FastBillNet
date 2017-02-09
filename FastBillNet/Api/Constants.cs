#region License

/* Copyright (c) 2013 Russlan Akiev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
 * sell copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software. 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
 */

#endregion

namespace FastBillNet
{
    public static class Constants
    {
        public const string Success = "success";

        public enum YesNo : int
        {
            No = 0,
            Yes = 1
        }

        /// <summary>
        /// CODE der Währung
        /// </summary>
        public static class CurrencyCodes
        {
            public const string EUR = "EUR";
            public const string CHF = "CHF";
            public const string GBP = "GBP";
            public const string USD = "USD";
        }

        /// <summary>
        /// Liefert die Rechnungen eines bestimmten Types
        /// </summary>
        public static class InvoiceType
        {
            /// <summary>
            /// Rechnungen
            /// </summary>
            public const string Outgoing = "outgoing";

            /// <summary>
            /// Entwürfe
            /// </summary>
            public const string Draft = "draft";

            /// <summary>
            /// Gutschriften
            /// </summary>
            public const string Credit = "credit";
        }

        /// <summary>
        /// Liefert die Rechnungen eines bestimmten Status
        /// </summary>
        public static class InvoiceState
        {
            /// <summary>
            /// unbezahlt (inkl. überfällig) 
            /// </summary>
            public const string Unpaid = "unpaid";

            /// <summary>
            /// bezahlt 
            /// </summary>
            public const string Paid = "paid ";

            /// <summary>
            /// überfällig
            /// </summary>
            public const string Overdue = "overdue";
        }

        public static class CustomerType
        {
            /// <summary>
            /// Geschäftskunde
            /// </summary>
            public const string Business = "business";

            /// <summary>
            /// Privatperson
            /// </summary>
            public const string Consumer = "consumer";
        }

        public class Salutation
        {
            /// <summary>
            /// ohne title
            /// </summary>
            public const string NoTitle = "";

            /// <summary>
            /// Familie
            /// </summary>
            public const string Family = "family";

            /// <summary>
            /// Frau
            /// </summary>
            public const string Mrs = "mrs";

            /// <summary>
            /// Herr
            /// </summary>
            public const string Mr = "mr";

        }

        public class PaymentType
        {
            /// <summary>
            /// ueberweisung
            /// </summary>
            public const int Transfer = 1;

            /// <summary>
            /// lastschrift
            /// </summary>
            public const int Charge = 2;

            /// <summary>
            /// bar
            /// </summary>
            public const int Cash = 3;

            /// <summary>
            /// paypal
            /// </summary>
            public const int PayPal = 4;

            /// <summary>
            /// Vorkasse
            /// </summary>
            public const int Prepayment = 5;

            /// <summary>
            /// Kreditkarte
            /// </summary>
            public const int CreditCard = 6;
        }

        public class CountryCode
        {
            public const string DE = "DE";
        }
    }
}
