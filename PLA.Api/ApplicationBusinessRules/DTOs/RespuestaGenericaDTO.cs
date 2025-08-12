namespace PLA.Api.ApplicationBusinessRules.DTOs
{
    public class RespuestaGenericaDTO<T>
    {
        public T Objeto { get; set; }
        public string Mensaje { get; set; }
        public bool EstatusOperacion { get; set; }
    }
}
