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

using FastBillNet.Converter;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using static FastBillNet.Constants;

namespace FastBillNet
{
    public interface IContactService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        ApiResponse<ContactGetResponse> Get(ContactGetRequest request);
        ApiResponse<ContactCreateResponse> Create(ContactCreateRequest request);
        ApiResponse<ContactUpdateResponse> Update(ContactUpdateRequest request);
        ApiResponse<ContactDeleteResponse> Delete(ContactDeleteRequest request);
    }

    #region Services

    public class ContactService : ServiceBase, IContactService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        public ApiResponse<ContactGetResponse> Get(ContactGetRequest request)
        {
            return this.Send<ContactGetResponse>(new ApiRequest
            {
                Service = "contact.get",
                Filter = request,
                //Limit = request.Limit,
                //Offset = request.Offset
            });
        }

        public ApiResponse<ContactCreateResponse> Create(ContactCreateRequest request)
        {
            return this.Send<ContactCreateResponse>(new ApiRequest
            {
                Service = "contact.create",
                Data = request
            });
        }

        public ApiResponse<ContactUpdateResponse> Update(ContactUpdateRequest request)
        {
            return this.Send<ContactUpdateResponse>(new ApiRequest
            {
                Service = "contact.update",
                Data = request
            });
        }

        public ApiResponse<ContactDeleteResponse> Delete(ContactDeleteRequest request)
        {
            return this.Send<ContactDeleteResponse>(new ApiRequest
            {
                Service = "contact.delete",
                Filter = request
            });
        }
    }

    #endregion

    #region Get

    public class ContactGetRequest 
    {
        /// <summary>
        /// Eine bestimmte Kundennummer
        /// </summary>
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Eigene Kundennummer
        /// </summary>
        [JsonProperty("CUSTOMER_NUMBER")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Suchwort in einem der Felder: ORGANIZATION, FIRST_NAME, LAST_NAME, ADDRESS, ADDRESS_2, ZIPCODE, EMAIL, TAGS.
        /// </summary>
        [JsonProperty("TERM")]
        public string Term { get; set; }

        /// <summary>
        /// Ein bestimmter Kontakt
        /// </summary>
        [JsonProperty("CONTACT_ID")]
        public string ContactId { get; set; }
    }

    public class ContactGetResponse : ResponseBase
    {
        [JsonProperty("CONTACTS")]
        public Contact[] Contacts { get; set; }
    }

    #endregion

    #region Delete

    public class ContactDeleteRequest
    {
        /// <summary>
        /// ID des zu ändernden Kontakt.
        /// </summary>
        [Required]
        [JsonProperty("CONTACT_ID")]
        public string ContactId { get; set; }
    }

    public class ContactDeleteResponse : ResponseBase { }

    #endregion

    #region Create

    public class ContactCreateRequest : Contact { }

    public class ContactCreateResponse : ResponseBase
    {
        [JsonProperty("CONTACT_ID")]
        public string ContactId { get; set; }
    }

    #endregion

    #region Update

    public class ContactUpdateRequest : Contact { }

    public class ContactUpdateResponse : ResponseBase { }

    #endregion

    #region Entities

    public class Contact
    {
        /// <summary>
        /// Eine bestimmte Kontaktnummer
        /// </summary>
        [JsonProperty("CONTACT_ID")]
        public string ContactId { get; set; }

        /// <summary>
        /// Eine bestimmte Kundennummer
        /// </summary>
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Firmenname [REQUIRED] wenn CUSTOMER_TYPE = business
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

        /// <summary>
        /// Lieferadresse
        /// </summary>
        [JsonProperty("SECONDARY_ADDRESS")]
        public string SecondaryAddress { get; set; }

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

        [JsonProperty("CREATED")]
        public DateTime Created { get; set; }
    }

    #endregion
}