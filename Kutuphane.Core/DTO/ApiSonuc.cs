
using System.Net;
using System.Text.Json.Serialization;

namespace Kutuphane.Core.DTO
{
    public class ApiSonuc<T>
    {
        [JsonConstructor]
        public ApiSonuc() { }

        public ApiSonuc(T _data, string _mesaj, int _statusCode, HataBilgisi _hataBilgisi)
        {
            this.Data = _data;
            this.Mesaj = _mesaj;
            this.StatusCode = _statusCode;
            this.HataBilgisi = _hataBilgisi;
        }

        public ApiSonuc(T _data, string _message, int _statusCode)
        {
            this.Data = _data;
            this.StatusCode = _statusCode;
            this.Mesaj = _message;
        }

        public ApiSonuc(string _message, int _statusCode)
        {
            this.StatusCode = _statusCode;
            this.Mesaj = _message;
        }

        public ApiSonuc(string _message, int _statusCode, HataBilgisi _hataBilgisi)
        {
            this.StatusCode = _statusCode;
            this.Mesaj = _message;
            this.HataBilgisi = _hataBilgisi;
        }

        public T Data { get; set; }
        public string Mesaj { get; set; }
        public int StatusCode { get; set; }
        public HataBilgisi HataBilgisi { get; set; }

        public static ApiSonuc<T> SuccessWithData(T data, string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ApiSonuc<T>(data, message, statusCode);
        }

        public static ApiSonuc<T> SuccessWithoutData(string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ApiSonuc<T>(message, statusCode);
        }

        public static ApiSonuc<T> SuccessNoDataFound(string message = "Sonuç Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiSonuc<T>(message, statusCode, HataBilgisi.NotFound());
        }

        public static ApiSonuc<T> FieldValidationError(List<string>? errorMessages = null, string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiSonuc<T>(message, statusCode, HataBilgisi.FieldValidationError(errorMessages));
        }

        public static ApiSonuc<T> Error(HataBilgisi hataBilgisi, string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new ApiSonuc<T>(message, statusCode, HataBilgisi.Error());
        }


        public static ApiSonuc<T> AuthenticationError(string message = "Kullanıcı Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiSonuc<T>(message, statusCode, HataBilgisi.AuthenticationError());
        }
        
        public static ApiSonuc<T> RegistraionError(string message = "Kullanıcı kaydı yapılamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ApiSonuc<T>(message, statusCode, HataBilgisi.RegistraionError());
        }

        public static ApiSonuc<T> TokenError(HataBilgisi hatabilgisi, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new ApiSonuc<T>("Hata Oluştu", statusCode, HataBilgisi.TokenError());
        }
        public static ApiSonuc<T> TokenNotFoundError(HataBilgisi hatabilgisi, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new ApiSonuc<T>("Hata Oluştu", statusCode, HataBilgisi.TokenNotFoundError());
        }
    }
}
