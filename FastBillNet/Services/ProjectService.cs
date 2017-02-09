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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static FastBillNet.ProjectService;

namespace FastBillNet
{
    public interface IProjectService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        ApiResponse<ProjectGetResponse> Get(ProjectGetRequest request);

        //ApiResponse<ProjectCreateResponse> Create(ProjectCreateRequest request);
        //ApiResponse<ProjectUpdateResponse> Update(ProjectUpdateRequest request);
        //ApiResponse<ProjectDeleteResponse> Delete(ProjectDeleteRequest request);
    }

    #region Services

    public class ProjectService : ServiceBase, IProjectService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Kunden. Wenn kein Filter gesetzt wird, werden alle Kunden zurückgeliefert.
        /// </summary>
        public ApiResponse<ProjectGetResponse> Get(ProjectGetRequest request)
        {
            return this.Send<ProjectGetResponse>(new ApiRequest
            {
                Service = "project.get",
                Filter = request,
                Limit = request.Limit,
                Offset = request.Offset
            });
        }
        

        //    public ApiResponse<CustomerCreateResponse> Create(CustomerCreateRequest request)
        //    {
        //        return this.Send<CustomerCreateResponse>(new ApiRequest
        //        {
        //            Service = "customer.create",
        //            Data = request
        //        });
        //    }

        //    public ApiResponse<CustomerUpdateResponse> Update(CustomerUpdateRequest request)
        //    {
        //        return this.Send<CustomerUpdateResponse>(new ApiRequest
        //        {
        //            Service = "customer.update",
        //            Data = request
        //        });
        //    }

        //    public ApiResponse<CustomerDeleteResponse> Delete(CustomerDeleteRequest request)
        //    {
        //        return this.Send<CustomerDeleteResponse>(new ApiRequest
        //        {
        //            Service = "customer.delete",
        //            Filter = request
        //        });
        //    }
        //}

        #endregion

        #region Get

        public class ProjectGetRequest
        {
            /// <summary>
            /// Eine bestimmte Kundennummer
            /// </summary>
            [JsonProperty("CUSTOMER_ID")]
            public string CustomerId { get; set; }

            /// <summary>
            /// Eine bestimmte Projekt ID
            /// </summary>
            [JsonProperty("PROJECT_ID")]
            public string ProjectId { get; set; }

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

        public class ProjectGetResponse : ResponseBase
        {
            [JsonProperty("PROJECTS")]
            public List<Project> Projects { get; set; }
        }

        #endregion

        //#region Delete

        //public class CustomerDeleteRequest
        //{
        //    /// <summary>
        //    /// ID des zu ändernden Kunden.
        //    /// </summary>
        //    [Required]
        //    [JsonProperty("CUSTOMER_ID")]
        //    public string CustomerId { get; set; }
        //}

        //public class CustomerDeleteResponse : ResponseBase { }

        //#endregion

        //#region Create

        //public class CustomerCreateRequest : Customer { }

        //public class CustomerCreateResponse : ResponseBase
        //{
        //    [JsonProperty("CUSTOMER_ID")]
        //    public string CustomerId { get; set; }
        //}

        //#endregion

        //#region Update

        //public class CustomerUpdateRequest : Customer { }

        //public class CustomerUpdateResponse : ResponseBase { }

        //#endregion

        #region Entities

        public class Project
        {
            [JsonProperty("PROJECT_ID")]
            public string ProjectId { get; set; }

            [JsonProperty("PROJECT_NUMBER")]
            public string ProjectNumber { get; set; }

            [JsonProperty("PROJECT_NAME")]
            public string ProjectName { get; set; }

            [JsonProperty("CUSTOMER_ID")]
            public string CustomerId { get; set; }

            [JsonProperty("CUSTOMER_COSTCENTER_ID")]
            public string CustomerCostcenterId { get; set; }

            [JsonProperty("HOUR_PRICE")]
            public string HourPrice { get; set; }

            [JsonProperty("CURRENCY_CODE")]
            public string CurrencyCode { get; set; }

            [JsonProperty("VAT_PERCENT")]
            public string VatPercent { get; set; }

            [JsonProperty("START_DATE")]
            [JsonConverter(typeof(DateConverter))]
            public DateTime? StartDate { get; set; }

            [JsonProperty("END_DATE")]
            [JsonConverter(typeof(DateConverter))]
            public DateTime? EndDate { get; set; }

            //[JsonProperty("TASKS")]
            //public Task[] Tasks { get; set; }


        }


        //public class Task
        //{

        //    [JsonProperty("TASK_ID")]
        //    public DateTime? EndDate { get; set; }
        //    [JsonProperty("TASK_NAME")]
        //    public DateTime? EndDate { get; set; }
        //    [JsonProperty("TASK_NUMBER")]
        //    public DateTime? EndDate { get; set; }
        //    [JsonProperty("END_DATE")]
        //    public DateTime? EndDate { get; set; }
        //    [JsonProperty("END_DATE")]
        //    public DateTime? EndDate { get; set; }
        //}

        #endregion

    }
}
