using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RandomUserApiPasc.Infra.DTO;
using RandomUserApiPasc.Infra.Interfaces;

namespace RandomUserApiPasc.Infra.DAO
{
    public class UserRandomDAO : IUserRandomDAO
    {
        private readonly IConfiguration _configuration;

        public UserRandomDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDataDTO>> GetAllUsers()
        {
            var connectionString = _configuration.GetSection("connectionString").Value;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                await conn.OpenAsync();

                const string query = @"SELECT 
                                          gender, name_title as NameTitle, name_first as NameFirst, name_last as NameLast,
                                          street_number as StreetNumber, street_name as StreetName, city as City, state as State,
                                          country as Country, postcode as Postcode, latitude as Latitude, longitude as Longitude,
                                          timezone_offset as TimezoneOffset, timezone_description as TimezoneDescription, email as Email,
                                          login_uuid as LoginUuid, login_username as LoginUsername, login_password as LoginPassword, login_salt as LoginSalt,
                                          login_md5 as LoginMd5, login_sha1 as LoginSha1, login_sha256 as LoginSha256, dob_date as DobDate, dob_age as DobAge,
                                          registered_date as RegisteredDateRegisteredDate, registered_age as RegisteredAge, phone as Phone, cell as Cell, 
                                          id_name as IdName,id_value as IdValue, picture_large as PictureLarge, picture_medium as PictureMedium, 
                                          picture_thumbnail as PictureThumbnail, nat as Nat,seed as Seed, results_count as ResultsCount, page as Page, 
                                          version as Version
                                       FROM users";

                return await conn.QueryAsync<UserDataDTO>(query);
            }
        }
    }
}
