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
using static FastBillNet.Constants;

// For reference: http://www.fastbill.com/api/ausgangsrechnungen.html 
namespace FastBillNet
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Abfragen der Details einer oder mehrerer Rechnungen. Wenn kein Filter gesetzt wird (alle Felder leer lassen), werden alle Rechnungen zurückgeliefert.
        /// </summary>
        ApiResponse<InvoiceGetResponse> Get(InvoiceGetRequest request);

        /// <summary>
        /// Abfragen der Positionen einer Rechnung.
        /// </summary>
        ApiResponse<ItemGetResponse> Get(ItemGetRequest request);

        /// <summary>
        /// Erstellen eines neuen Rechnungsentwurfs.
        /// </summary>
        ApiResponse<InvoiceCreateResponse> Create(InvoiceCreateRequest request);

        /// <summary>
        /// Verändern der Daten eines Rechnungsentwurfes.
        /// </summary>
        ApiResponse<InvoiceUpdateResponse> Update(InvoiceUpdateRequest request);

        /// <summary>
        /// Löschen eines Rechnungsentwurfes.
        /// </summary>
        ApiResponse<InvoiceDeleteResponse> Delete(InvoiceDeleteRequest request);

        /// <summary>
        /// Löschen einer Rechnungsposition.
        /// </summary>
        ApiResponse<ItemDeleteResponse> Delete(ItemDeleteRequest request);

        /// <summary>
        /// Erstellen einer fertigen Rechnung aus einem Rechnungsentwurf.
        /// </summary>
        ApiResponse<InvoiceCompleteResponse> Complete(InvoiceCompleteRequest request);

        /// <summary>
        /// Stornieren einer Rechnung
        /// </summary>
        ApiResponse<InvoiceCancelResponse> Cancel(InvoiceCancelRequest request);

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        ApiResponse<InvoiceSignResponse> Sign(InvoiceSignRequest request);

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        ApiResponse<InvoiceSendByEmailResponse> SendByEmail(InvoiceSendByEmailRequest request);

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        ApiResponse<InvoiceSendByPostResponse> SendByPost(InvoiceSendByPostRequest request);

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        ApiResponse<InvoiceSetPaidResponse> SetPaid(InvoiceSetPaidRequest request);
    }

    #region Services

    public class InvoiceService : ServiceBase, IInvoiceService
    {
        /// <summary>
        /// Abfragen der Details einer oder mehrerer Rechnungen. Wenn kein Filter gesetzt wird (alle Felder leer lassen), werden alle Rechnungen zurückgeliefert.
        /// </summary>
        public ApiResponse<InvoiceGetResponse> Get(InvoiceGetRequest request)
        {
            return this.Send<InvoiceGetResponse>(new ApiRequest
            {
                Service = "invoice.get",
                Filter = request,
                Limit = request.Limit,
                Offset = request.Offset
            });
        }

        /// <summary>
        /// Abfragen der Positionen einer Rechnung.
        /// </summary>
        public ApiResponse<ItemGetResponse> Get(ItemGetRequest request)
        {
            return this.Send<ItemGetResponse>(new ApiRequest
            {
                Service = "item.get",
                Filter = request
            });
        }

        /// <summary>
        /// Erstellen eines neuen Rechnungsentwurfs.
        /// </summary>
        public ApiResponse<InvoiceCreateResponse> Create(InvoiceCreateRequest request)
        {
            return this.Send<InvoiceCreateResponse>(new ApiRequest
            {
                Service = "invoice.create",
                Data = request
            });
        }

        /// <summary>
        /// Verändern der Daten eines Rechnungsentwurfes.
        /// </summary>
        public ApiResponse<InvoiceUpdateResponse> Update(InvoiceUpdateRequest request)
        {
            return this.Send<InvoiceUpdateResponse>(new ApiRequest
            {
                Service = "invoice.update",
                Data = request
            });
        }

        /// <summary>
        /// Löschen eines Rechnungsentwurfes.
        /// </summary>
        public ApiResponse<InvoiceDeleteResponse> Delete(InvoiceDeleteRequest request)
        {
            return this.Send<InvoiceDeleteResponse>(new ApiRequest
            {
                Service = "invoice.delete",
                Filter = request
            });
        }

        /// <summary>
        /// Löschen einer Rechnungsposition.
        /// </summary>
        public ApiResponse<ItemDeleteResponse> Delete(ItemDeleteRequest request)
        {
            return this.Send<ItemDeleteResponse>(new ApiRequest
            {
                Service = "item.get",
                Filter = request
            });
        }

        /// <summary>
        /// Erstellen einer fertigen Rechnung aus einem Rechnungsentwurf.
        /// </summary>
        public ApiResponse<InvoiceCompleteResponse> Complete(InvoiceCompleteRequest request)
        {
            return this.Send<InvoiceCompleteResponse>(new ApiRequest
            {
                Service = "invoice.complete",
                Data = request
            });
        }

        /// <summary>
        /// Stornieren einer Rechnung
        /// </summary>
        public ApiResponse<InvoiceCancelResponse> Cancel(InvoiceCancelRequest request)
        {
            return this.Send<InvoiceCancelResponse>(new ApiRequest
            {
                Service = "invoice.cancel",
                Data = request
            });
        }

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        public ApiResponse<InvoiceSignResponse> Sign(InvoiceSignRequest request)
        {
            return this.Send<InvoiceSignResponse>(new ApiRequest
            {
                Service = "invoice.sign",
                Data = request
            });
        }

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        public ApiResponse<InvoiceSendByEmailResponse> SendByEmail(InvoiceSendByEmailRequest request)
        {
            return this.Send<InvoiceSendByEmailResponse>(new ApiRequest
            {
                Service = "invoice.sign",
                Data = request
            });
        }

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        public ApiResponse<InvoiceSendByPostResponse> SendByPost(InvoiceSendByPostRequest request)
        {
            return this.Send<InvoiceSendByPostResponse>(new ApiRequest
            {
                Service = "invoice.sign",
                Data = request
            });
        }

        /// <summary>
        /// Hinzufügen einer qualifizierten elektronischen Signatur zu einer abgeschlossenen Rechnung.
        /// </summary>
        public ApiResponse<InvoiceSetPaidResponse> SetPaid(InvoiceSetPaidRequest request)
        {
            return this.Send<InvoiceSetPaidResponse>(new ApiRequest
            {
                Service = "invoice.sign",
                Data = request
            });
        }
    }
    #endregion

    #region SetPaid

    public class InvoiceSetPaidRequest
    {
        /// <summary>
        /// ID der betreffenden Rechnung.
        /// </summary>
        [Required]
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// DateTime format 2013-03-05
        /// </summary>
        [JsonProperty("PAID_DATE")]
        public string PaidDate { get; set; }
    }

    public class InvoiceSetPaidResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }

        [JsonProperty("INVOICE_NUMBER")]
        public bool InvoiceNumber { get; set; }
    }

    #endregion

    #region SendByPost

    public class InvoiceSendByPostRequest
    {
        /// <summary>
        /// ID der betreffenden Rechnung.
        /// </summary>
        [Required]
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class InvoiceSendByPostResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }

        [JsonProperty("REMAINING_CREDITS")]
        public string RemainingCredits { get; set; }
    }

    #endregion

    #region SendByEmail

    public class InvoiceSendByEmailRequest
    {
        /// <summary>
        /// ID der zu versendenden Rechnung.
        /// </summary>
        [Required]
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Muss als Unterknoten mind. den Knoten TO enthalten, kann ebenfalls den Knoten CC und BCC enthalten
        /// </summary>
        [Required]
        [JsonProperty("RECIPIENT")]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Betreff
        /// </summary>
        [JsonProperty("SUBJECT")]
        public string Subject { get; set; }

        /// <summary>
        /// E-Mail Text
        /// </summary>
        [JsonProperty("MESSAGE")]
        public string Message { get; set; }

        /// <summary>
        /// Angabe, ob Empfangsbestätigung angefordert werden soll: <see cref="Constants.YesNo"/>
        /// </summary>
        [JsonProperty("RECEIPT_CONFIRMATION")]
        public YesNo ReceiptConfirmation { get; set; }
    }

    public class InvoiceSendByEmailResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }
    }

    #endregion

    #region Sign

    public class InvoiceSignRequest
    {
        /// <summary>
        /// ID der zu signierenden Rechnung.
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class InvoiceSignResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }

        [JsonProperty("REMAINING_CREDITS")]
        public bool RemainingCredits { get; set; }
    }

    #endregion

    #region Get

    public class InvoiceGetRequest
    {
        /// <summary>
        /// Liefert eine bestimmte Rechnung nach ID
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Liefert eine bestimmte Rechnung nach Rechnungsnummer
        /// </summary>
        [JsonProperty("INVOICE_NUMBER")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Liefert alle Rechnungen eines Kunden
        /// </summary>
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Liefert alle Rechnungen eines Monats
        /// </summary>
        [JsonProperty("MONTH")]
        public string Month { get; set; }

        /// <summary>
        /// Liefert alle Rechnungen eines Jahres
        /// </summary>
        [JsonProperty("YEAR")]
        public string Year { get; set; }

        /// <summary>
        /// Liefert alle Rechnungen die nach einem bestimmten Datum fällig werden
        /// </summary>
        [JsonProperty("START_DUE_DATE")]
        public string StartDueDate { get; set; }

        /// <summary>
        /// Liefert Rechungen die vor einem bestimmten Datum fällig werden
        /// </summary>
        [JsonProperty("END_DUE_DATE")]
        public string EndDueDate { get; set; }

        /// <summary>
        /// Liefert die Rechnungen eines bestimmten Status: <see cref="Constants.InvoiceState"/>
        /// </summary>
        [JsonProperty("STATE")]
        public string State { get; set; }

        /// <summary>
        /// Liefert die Rechnungen die einem bestimmten Projekt zugeordnet sind
        /// </summary>
        [JsonProperty("PROJECT_ID")]
        public string ProjectId { get; set; }

        /// <summary>
        /// Liefert die Rechnungen eines bestimmten Types: <see cref="Constants.InvoiceType"/>
        /// </summary>
        [JsonProperty("TYPE")]
        public string Type { get; set; }

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

    public class InvoiceGetResponse : ResponseBase
    {
        [JsonProperty("INVOICES")]
        public Invoice[] Invoices { get; set; }
    }

    public class ItemGetRequest
    {
        /// <summary>
        /// Rechnungsnummer
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class ItemGetResponse : ResponseBase
    {
        [JsonProperty("LIMIT")]
        public Item[] Items { get; set; }
    }

    #endregion

    #region Create

    public class InvoiceCreateRequest : Invoice
    {
    }

    public class InvoiceCreateResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }

        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    #endregion

    #region Update

    /// <summary>
    /// Verändern der Daten eines Rechnungsentwurfes.
    /// </summary>
    public class InvoiceUpdateRequest : Invoice
    {
        /// <summary>
        /// Flag, das angibt, ob alle bestehenden Rechnungsposten gelöscht werden sollen. 
        /// </summary>
        [JsonProperty("DELETE_EXISTING_ITEMS")]
        public int DeleteExistingItems { get; set; }
    }

    public class InvoiceUpdateResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }
    }

    #endregion

    #region Delete

    public class InvoiceDeleteResponse : ResponseBase
    {
        /// <summary>
        /// ID des zu löschenden Rechnungsentwurfes.
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class InvoiceDeleteRequest
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }
    }

    public class ItemDeleteRequest
    {
        /// <summary>
        /// ID der zu löschenden Rechnungsposition.
        /// </summary>
        [JsonProperty("INVOICE_ITEM_ID")]
        public string InvoiceItemId { get; set; }
    }

    public class ItemDeleteResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }
    }

    #endregion

    #region Complete

    public class InvoiceCompleteRequest
    {
        /// <summary>
        /// ID des abzuschließenden Rechnungsentwurfes.
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class InvoiceCompleteResponse : ResponseBase
    {
        [JsonProperty("INVOICE_NUMBER")]
        public string InvoiceNumber { get; set; }
    }

    #endregion

    #region Cancel

    public class InvoiceCancelRequest
    {
        /// <summary>
        /// ID des zu löschenden Rechnungsentwurfes.
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class InvoiceCancelResponse : ResponseBase
    {
        [JsonProperty("STATUS")]
        public bool Status { get; set; }
    }

    #endregion

    #region Entities

    public class Invoice
    {
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }

        [JsonProperty("TYPE")]
        public string Type { get; set; }

        [JsonProperty("INVOICE_NUMBER")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("Invoice_COSTCENTER_ID")]
        public string InvoiceCostcenterId { get; set; }

        [JsonProperty("ORGANIZATION")]
        public string Organization { get; set; }

        [JsonProperty("SALUTATION")]
        public string Salutation { get; set; }

        [JsonProperty("FIRST_NAME")]
        public string FirstName { get; set; }

        [JsonProperty("LAST_NAME")]
        public string LastName { get; set; }

        [JsonProperty("ADDRESS")]
        public string Address { get; set; }

        [JsonProperty("ADDRESS_2")]
        public string Address2 { get; set; }

        [JsonProperty("ZIPCODE")]
        public string Zipcode { get; set; }

        [JsonProperty("CITY")]
        public string City { get; set; }

        [JsonProperty("COUNTRY_CODE")]
        public string CountryCode { get; set; }

        [JsonProperty("VAT_ID")]
        public string VatId { get; set; }

        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }

        [JsonProperty("TEMPLATE_ID")]
        public string TemplateId { get; set; }

        [JsonProperty("INTROTEXT")]
        public string Introtext { get; set; }

        [JsonProperty("EU_DELIVERY")]
        public string EuDelivery { get; set; }

        [JsonProperty("PAID_DATE")]
        public string PaidDate { get; set; }

        [JsonProperty("IS_CANCELED")]
        public string IsCanceled { get; set; }

        [JsonProperty("INVOICE_DATE")]
        public string InvoiceDate { get; set; }

        [JsonProperty("DUE_DATE")]
        public string DueDate { get; set; }

        [JsonProperty("DELIVERY_DATE")]
        public string DeliveryDate { get; set; }

        [JsonProperty("CASH_DISCOUNT_PERCENT")]
        public string CashDiscountPercent { get; set; }

        [JsonProperty("CASH_DISCOUNT_DAYS")]
        public string CashDiscountDays { get; set; }

        [JsonProperty("SUB_TOTAL")]
        public int SubTotal { get; set; }

        [JsonProperty("VAT_TOTAL")]
        public int VatTotal { get; set; }

        [JsonProperty("VAT_ITEMS")]
        public VatItem[] VatItems { get; set; }

        [JsonProperty("ITEMS")]
        public Item[] Items { get; set; }

        [JsonProperty("TOTAL")]
        public int Total { get; set; }

        [JsonProperty("DOCUMENT_URL")]
        public string DocumentUrl { get; set; }
    }

    public class VatItem
    {
        [JsonProperty("VAT_PERCENT")]
        public string VatPercent { get; set; }

        [JsonProperty("COMPLETE_NET")]
        public int CompleteNet { get; set; }

        [JsonProperty("VAT_VALUE")]
        public int VatValue { get; set; }
    }

    public class Item
    {
        [JsonProperty("INVOICE_ITEM_ID")]
        public string InvoiceItemId { get; set; }

        [JsonProperty("ARTICLE_NUMBER")]
        public string ArticleNumber { get; set; }

        [JsonProperty("DESCRIPTION")]
        public string Description { get; set; }

        [JsonProperty("QUANTITY")]
        public int Quantity { get; set; }

        [JsonProperty("UNIT_PRICE")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("VAT_PERCENT")]
        public decimal VatPercent { get; set; }

        [JsonProperty("VAT_VALUE")]
        public decimal VatValue { get; set; }

        [JsonProperty("COMPLETE_NET")]
        public decimal CompleteNet { get; set; }

        [JsonProperty("COMPLETE_GROSS")]
        public decimal CompleteGross { get; set; }

        [JsonProperty("SORT_ORDER")]
        public int SortOrder { get; set; }
    }

    public class Recipient
    {
        [JsonProperty("TO")]
        public string To { get; set; }

        [JsonProperty("CC")]
        public string Cc { get; set; }
    }

    #endregion
}