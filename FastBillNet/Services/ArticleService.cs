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
    public interface IArticleService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Produkte. Wenn kein Filter gesetzt wird, werden 10 Produkte zurückgeliefert. <see cref="http://www.fastbill.com/api/produkte.html#article.get"/>
        /// </summary>
        ApiResponse<ArticleGetResponse> Get(ArticleGetRequest request);

        /// <summary>
        /// Erstellen eines neuen Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.create"/>
        /// </summary>
        ApiResponse<ArticleCreateResponse> Create(ArticleCreateRequest request);

        /// <summary>
        /// Verändern der Daten eines Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.update"/>
        /// </summary>
        ApiResponse<ArticleUpdateResponse> Update(ArticleUpdateRequest request);

        /// <summary>
        /// Löschen eines Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.delete"/>
        /// </summary>
        ApiResponse<ArticleDeleteResponse> Delete(ArticleDeleteRequest request);
    }

    #region Services

    public class ArticleService : ServiceBase, IArticleService
    {
        /// <summary>
        /// Abfragen der Details eines oder mehrerer Produkte. Wenn kein Filter gesetzt wird, werden 10 Produkte zurückgeliefert. <see cref="http://www.fastbill.com/api/produkte.html#article.get"/>
        /// </summary>
        public ApiResponse<ArticleGetResponse> Get(ArticleGetRequest request)
        {
            return this.Send<ArticleGetResponse>(new ApiRequest
            {
                Service = "article.get",
                Filter = request,
                Limit = request.Limit,
                Offset = request.Offset
            });
        }

        /// <summary>
        /// Erstellen eines neuen Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.create"/>
        /// </summary>
        public ApiResponse<ArticleCreateResponse> Create(ArticleCreateRequest request)
        {
            return this.Send<ArticleCreateResponse>(new ApiRequest
            {
                Service = "article.create",
                Data = request
            });
        }

        /// <summary>
        /// Verändern der Daten eines Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.update"/>
        /// </summary>
        public ApiResponse<ArticleUpdateResponse> Update(ArticleUpdateRequest request)
        {
            return this.Send<ArticleUpdateResponse>(new ApiRequest
            {
                Service = "article.update",
                Data = request
            });
        }

        /// <summary>
        /// Löschen eines Produktes. <see cref="http://www.fastbill.com/api/produkte.html#article.delete"/>
        /// </summary>
        public ApiResponse<ArticleDeleteResponse> Delete(ArticleDeleteRequest request)
        {
            return this.Send<ArticleDeleteResponse>(new ApiRequest
            {
                Service = "article.delete",
                Filter = request
            });
        }
    }

    #endregion

    #region Get

    public class ArticleGetRequest
    {
        /// <summary>
        /// Liefert ein bestimmtes Produkt nach ID
        /// </summary>
        [JsonProperty("ARTICLE_ID")]
        public string ArticleId { get; set; }

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

    public class ArticleGetResponse : ResponseBase
    {
        [JsonProperty("ARTICLES")]
        public Article[] Articles { get; set; }
    }

    #endregion

    #region Delete

    public class ArticleDeleteRequest
    {
        /// <summary>
        /// ID des zu löschenden Produktes.
        /// </summary>
        [Required]
        [JsonProperty("ARTICLE_ID")]
        public string ArticleId { get; set; }
    }

    public class ArticleDeleteResponse : ResponseBase { }

    #endregion

    #region Create

    public class ArticleCreateRequest : Article
    {
    }

    public class ArticleCreateResponse : ResponseBase
    {
        [JsonProperty("ARTICLE_ID")]
        public string ArticleId { get; set; }
    }

    #endregion

    #region Update

    public class ArticleUpdateRequest : Article { }

    public class ArticleUpdateResponse : ResponseBase { }

    #endregion

    #region Entities

    public class Article
    {
        /// <summary>
        /// Artikel ID
        /// </summary>
        [JsonProperty("ARTICLE_ID")]
        public string ArticleId { get; set; }


        /// <summary>
        /// Artikelnummer
        /// </summary>
        [JsonProperty("ARTICLE_NUMBER")]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Titel
        /// </summary>
        [JsonProperty("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// Beschreibung
        /// </summary>
        [JsonProperty("DESCRIPTION")]
        public string Description { get; set; }


        /// <summary>
        /// Einheit
        /// </summary>
        [JsonProperty("UNIT")]
        public string Unit { get; set; }


        /// <summary>
        /// Titel
        /// </summary>
        [JsonProperty("UNIT_PRICE")]
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// CODE der Währung: <see cref="Constants.CurrencyCodes"/>
        /// </summary>
        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; }


        /// <summary>
        /// Steuersatz in Prozent, z.B. 19.00
        /// </summary>
        [JsonProperty("VAT_PERCENT")]
        public decimal VatPercent { get; set; }
    }

    #endregion
}