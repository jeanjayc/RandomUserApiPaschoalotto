namespace RandomUserApiPasc.Infra.DTO.Request
{
    public class UserRandomEditDTO
    {
        public string Gender { get; set; }
        public string NameTitle { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public DateTime? DobDate { get; set; }
        public int DobAge { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string? PictureLarge { get; set; }
        public string? PictureMedium { get; set; }
        public string? PictureThumbnail { get; set; }
    }
}
