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

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FastBillNet
{
    public interface ICustomerService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        ApiResponse<CustomerGetResponse> Get(CustomerGetRequest request);

        ApiResponse<CustomerCreateResponse> Create(CustomerCreateRequest request);
        ApiResponse<CustomerUpdateResponse> Update(CustomerUpdateRequest request);
        ApiResponse<CustomerDeleteResponse> Delete(CustomerDeleteRequest request);
    }

    #region Services

    public class CustomerService : ServiceBase, ICustomerService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        public ApiResponse<CustomerGetResponse> Get(CustomerGetRequest request)
        {
            return this.Send<CustomerGetResponse>(new ApiRequest
            {
                Service = "customer.get",
                Filter = request,
                Limit = request.Limit,
                Offset = request.Offset
            });
        }

        public ApiResponse<CustomerCreateResponse> Create(CustomerCreateRequest request)
        {
            return this.Send<CustomerCreateResponse>(new ApiRequest
            {
                Service = "customer.create",
                Data = request
            });
        }

        public ApiResponse<CustomerUpdateResponse> Update(CustomerUpdateRequest request)
        {
            return this.Send<CustomerUpdateResponse>(new ApiRequest
            {
                Service = "customer.update",
                Data = request
            });
        }

        public ApiResponse<CustomerDeleteResponse> Delete(CustomerDeleteRequest request)
        {
            return this.Send<CustomerDeleteResponse>(new ApiRequest
            {
                Service = "customer.delete",
                Filter = request
            });
        }
    }

    #endregion

    #region Get

    public class CustomerGetRequest
    {
        /// <summary>
        /// Liefert einen bestimmten Kunden
        /// </summary>
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Liefert einen bestimmten Kunden anhand der Kundennummer
        /// </summary>
        [JsonProperty("CUSTOMER_NUMBER")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Liefert alle Kunden eines Landes (ISO 3166 ALPHA-2)
        /// </summary>
        [JsonProperty("CUSTOMER_COUNTRY")]
        public string CustomerCountry { get; set; }

        /// <summary>
        /// Liefert alle Kunden einer Stadt
        /// </summary>
        [JsonProperty("CITY")]
        public string City { get; set; }

        /// <summary>
        /// Sucht nach Kunden mit dem Suchterm in einem der Felder: ORGANIZATION, FIRST_NAME, LAST_NAME, ADDRESS, ADDRESS_2, ZIPCODE, EMAIL
        /// </summary>
        [JsonProperty("TERM")]
        public string Term { get; set; }

        /// <summary>
        /// Parameter zur Begrenzung der Anzahl der Elemente bei Abfrage einer Liste
        /// </summary>
        [JsonProperty("LIMIT")]
        public int? Limit { get; set; }

        /// <summary>
        /// Parameter zur Festlegung des ersten Elements bei Abfrage einer Liste
        /// </summary>
        [JsonProperty("OFFSET")]
        public int? Offset { get; set; }
    }

    public class CustomerGetResponse : ResponseBase
    {
        [JsonProperty("CUSTOMERS")]
        public Customer[] Customers { get; set; }
    }

    #endregion

    #region Delete

    public class CustomerDeleteRequest
    {
        /// <summary>
        /// ID des zu ändernden Kunden.
        /// </summary>
        [Required]
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }
    }

    public class CustomerDeleteResponse : ResponseBase { }

    #endregion

    #region Create

    public class CustomerCreateRequest : Customer { }

    public class CustomerCreateResponse : ResponseBase
    {
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }
    }

    #endregion

    #region Update

    public class CustomerUpdateRequest : Customer { }

    public class CustomerUpdateResponse : ResponseBase { }

    #endregion

    #region Entities

    public class Customer
    {
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Frei wählbare Kundennummer. Bei fehlender Angabe wird automatisch die nächste freie Nummer verwendet 
        /// </summary>
        [JsonProperty("CUSTOMER_NUMBER")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Tage zum Zahlungsziel. Default: Einstellungen des Users. Falls dort nicht gesetzt Default = 14;
        /// </summary>
        [JsonProperty("DAYS_FOR_PAYMENT")]
        public string DaysForPayment { get; set; }

        [JsonProperty("CREATED")]
        public string Created { get; set; }

        /// <summary>
        /// Zahlungsart des Kunden: <see cref="Constants.PaymentType"/>
        /// </summary>
        [JsonProperty("PAYMENT_TYPE")]
        public int PaymentType { get; set; }

        /// <summary>
        /// ame des Bank-Instituts wenn Zahlungsart Lastschrif
        /// </summary>
        [JsonProperty("BANK_NAME")]
        public string BankName { get; set; }

        /// <summary>
        /// Kontonummer wenn Zahlungsart Lastschrift
        /// </summary>
        [JsonProperty("BANK_ACCOUNT_NUMBER")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Bankleitzahl wenn Zahlungsart Lastschrift
        /// </summary>
        [JsonProperty("BANK_CODE")]
        public string BankCode { get; set; }

        /// <summary>
        /// Name des Kontoinhabers wenn Zahlungsart Lastschrift
        /// </summary>
        [JsonProperty("BANK_ACCOUNT_OWNER")]
        public string BankAccountOwner { get; set; }

        /// <summary>
        /// Zahlungshinweis auf Rechnung anzeigen: <see cref="Constants.YesNo"/>
        /// </summary>
        [JsonProperty("SHOW_PAYMENT_NOTICE")]
        public string ShowPaymentNotice { get; set; }

        /// <summary>
        /// Kundentyp: <see cref="Constants.CustomerType"/> 
        /// </summary>
        [JsonProperty("CUSTOMER_TYPE")]
        public string CustomerType { get; set; }

        [JsonProperty("NEWSLETTER_OPTIN")]
        public bool NewsletterOptin { get; set; }

        [JsonProperty("AFFILIATE")]
        public string Affiliate { get; set; }

        [JsonProperty("HASH")]
        public string Hash { get; set; }

        /// <summary>
        /// Firmenname wenn CUSTOMER_TYPE = business
        /// </summary>
        [JsonProperty("ORGANIZATION")]
        public string Organization { get; set; }

        /// <summary>
        /// Position in der Firma
        /// </summary>
        [JsonProperty("POSITION")]
        public string Position { get; set; }

        /// <summary>
        /// Anrede: <see cref="Constants.Salutation"/>
        /// </summary>
        [JsonProperty("SALUTATION")]
        public string Salutation { get; set; }

        /// <summary>
        /// Vorname
        /// </summary>
        [JsonProperty("FIRST_NAME")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nachname wenn CUSTOMER_TYPE = consumer
        /// </summary>
        [JsonProperty("LAST_NAME")]
        public string LastName { get; set; }

        /// <summary>
        /// Adresszeile 1
        /// </summary>
        [JsonProperty("ADDRESS")]
        public string Address { get; set; }

        /// <summary>
        /// Adresszeile 2
        /// </summary>
        [JsonProperty("ADDRESS_2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Postleitzahl
        /// </summary>
        [JsonProperty("ZIPCODE")]
        public string Zipcode { get; set; }

        /// <summary>
        /// Stadt
        /// </summary>
        [JsonProperty("CITY")]
        public string City { get; set; }

        /// <summary>
        /// Länder-Code (ISO 3166 ALPHA-2)
        /// </summary>
        [JsonProperty("COUNTRY_CODE")]
        public object CountryCode { get; set; }

        [JsonProperty("STATE")]
        public string State { get; set; }

        /// <summary>
        /// Telefonnummer
        /// </summary>
        [JsonProperty("PHONE")]
        public string Phone { get; set; }

        /// <summary>
        /// zweite Telefonnummer
        /// </summary>
        [JsonProperty("PHONE_2")]
        public string Phone2 { get; set; }

        /// <summary>
        /// Telefaxnummer
        /// </summary>
        [JsonProperty("FAX")]
        public string Fax { get; set; }

        /// <summary>
        /// Mobiltelefonnummer
        /// </summary>
        [JsonProperty("MOBILE")]
        public string Mobile { get; set; }

        /// <summary>
        /// E-Mail Adresse
        /// </summary>
        [JsonProperty("EMAIL")]
        public string Email { get; set; }

        /// <summary>
        /// UST-IDNr.
        /// </summary>
        [JsonProperty("VAT_ID")]
        public string VatId { get; set; }

        /// <summary>
        /// CODE der Standard-Währung des Kunden
        /// </summary>
        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }

        [JsonProperty("COMMENT")]
        public string Comment { get; set; }

        [JsonProperty("LASTUPDATE")]
        public string Lastupdate { get; set; }

        [JsonProperty("CUSTOMER_EXT_UID")]
        public bool CustomerExtUid { get; set; }

        [JsonProperty("LANGUAGE_CODE")]
        public string LanguageCode { get; set; }

        [JsonProperty("CHANGEDATA_URL")]
        public string ChangedataUrl { get; set; }

        [JsonProperty("DASHBOARD_URL")]
        public string DashboardUrl { get; set; }
    }

    #endregion
}