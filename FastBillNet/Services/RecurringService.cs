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
    public interface IRecurringService
    {
        /// <summary>
        /// Abfragen der Details einer oder mehrerer wiederkehrender Rechnungen. Wenn kein Filter gesetzt wird, werden alle wiederkehrenden Rechnungen zurückgeliefert.
        /// </summary>
        ApiResponse<RecurringGetResponse> Get(RecurringGetRequest request);

        /// <summary>
        /// Erstellen einer neuen wiederkehrenden Rechnung.
        /// </summary>
        ApiResponse<RecurringCreateResponse> Create(RecurringCreateRequest request);

        /// <summary>
        /// Verändern der Daten einer wiederkehrenden Rechnung.
        /// </summary>
        ApiResponse<RecurringUpdateResponse> Update(RecurringUpdateRequest request);

        /// <summary>
        /// Löschen einer wiederkehrenden Rechnung.
        /// </summary>
        ApiResponse<RecurringDeleteResponse> Delete(RecurringDeleteRequest request);
    }

    #region Services
    
    public class RecurringService : ServiceBase, IRecurringService
    {
        /// <summary>
        /// Abfragen der Details einer oder mehrerer wiederkehrender Rechnungen. Wenn kein Filter gesetzt wird, werden alle wiederkehrenden Rechnungen zurückgeliefert.
        /// </summary>
        public ApiResponse<RecurringGetResponse> Get(RecurringGetRequest request)
        {
            return this.Send<RecurringGetResponse>(new ApiRequest
            {
                Service = "recurring.get",
                Filter = request,
                Limit = request.Limit,
                Offset = request.Offset
            });
        }

        /// <summary>
        /// Erstellen einer neuen wiederkehrenden Rechnung.
        /// </summary>
        public ApiResponse<RecurringCreateResponse> Create(RecurringCreateRequest request)
        {
            return this.Send<RecurringCreateResponse>(new ApiRequest
            {
                Service = "recurring.create",
                Data = request
            });
        }

        /// <summary>
        /// Verändern der Daten einer wiederkehrenden Rechnung.
        /// </summary>
        public ApiResponse<RecurringUpdateResponse> Update(RecurringUpdateRequest request)
        {
            return this.Send<RecurringUpdateResponse>(new ApiRequest
            {
                Service = "recurring.update",
                Data = request
            });
        }

        /// <summary>
        /// Löschen einer wiederkehrenden Rechnung.
        /// </summary>
        public ApiResponse<RecurringDeleteResponse> Delete(RecurringDeleteRequest request)
        {
            return this.Send<RecurringDeleteResponse>(new ApiRequest
            {
                Service = "recurring.delete",
                Filter = request
            });
        }
    }

    #endregion

    #region Get

    public class RecurringGetRequest
    {
        /// <summary>
        /// Rechnungsnummer
        /// </summary>
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }

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

    public class RecurringGetResponse : ResponseBase
    {
        [JsonProperty("RECURINGS")]
        public Recurring[] Recurrings { get; set; }
    }

    #endregion

    #region Delete

    public class RecurringDeleteRequest
    {
        /// <summary>
        /// ID der zu löschenden wiederkehrenden Rechnung.
        /// </summary>
        [Required]
        [JsonProperty("INVOICE_ID")]
        public string InvoiceId { get; set; }
    }

    public class RecurringDeleteResponse : ResponseBase { }

    #endregion

    #region Create

    public class RecurringCreateRequest : Recurring
    {
    }

    public class RecurringCreateResponse : ResponseBase
    {
        [JsonProperty("RECURING_ID")]
        public string RecurringId { get; set; }
    }

    #endregion

    #region Update

    public class RecurringUpdateRequest : Recurring
    {
        /// <summary>
        /// Flag, das angibt, ob alle bestehenden Rechnungsposten gelöscht werden sollen. <see cref="Constants.YesNo"/>
        /// </summary>
        [JsonProperty("DELETE_EXISTING_ITEMS")]
        public bool DeleteExistingItems { get; set; }

    }

    public class RecurringUpdateResponse : ResponseBase { }

    #endregion

    #region Entities

    public class Recurring
    {

    }

    #endregion
}