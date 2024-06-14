using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Npgsql;
using RandomUserApiPasc.Infra.DTO;
using RandomUserApiPasc.Infra.Interfaces;

namespace RandomUserApiPasc.Infra.Repository
{
    public class UserRandomRepository : IUserRandomRepository
    {
        private readonly IConfiguration _configuration;

        public UserRandomRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddNewRandomUser(string json)
        {
            try
            {
                var userData = ParseJsonToUserData(json);
                var connectionString = _configuration.GetSection("connectionString").Value;

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string sql = @"
                    INSERT INTO users (
                        gender, name_title, name_first, name_last,
                        street_number, street_name, city, state, country, postcode,
                        latitude, longitude, timezone_offset, timezone_description,
                        email, login_uuid, login_username, login_password, login_salt,
                        login_md5, login_sha1, login_sha256,
                        dob_date, dob_age, registered_date, registered_age,
                        phone, cell, id_name, id_value,
                        picture_large, picture_medium, picture_thumbnail,
                        nat, seed, results_count, page, version
                    )
                    VALUES (
                        @Gender, @NameTitle, @NameFirst, @NameLast,
                        @StreetNumber, @StreetName, @City, @State, @Country, @Postcode,
                        @Latitude, @Longitude, @TimezoneOffset, @TimezoneDescription,
                        @Email, @LoginUuid, @LoginUsername, @LoginPassword, @LoginSalt,
                        @LoginMd5, @LoginSha1, @LoginSha256,
                        @DobDate, @DobAge, @RegisteredDate, @RegisteredAge,
                        @Phone, @Cell, @IdName, @IdValue,
                        @PictureLarge, @PictureMedium, @PictureThumbnail,
                        @Nat, @Seed, @ResultsCount, @Page, @Version
                    )";

                    await conn.ExecuteAsync(sql, userData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private UserDataDTO ParseJsonToUserData(string json)
        {
            var jsonObject = JObject.Parse(json);
            var userResult = jsonObject["results"][0];

            return new UserDataDTO
            {
                Gender = userResult["gender"].ToString(),
                NameTitle = userResult["name"]["title"].ToString(),
                NameFirst = userResult["name"]["first"].ToString(),
                NameLast = userResult["name"]["last"].ToString(),
                StreetNumber = (int)userResult["location"]["street"]["number"],
                StreetName = userResult["location"]["street"]["name"].ToString(),
                City = userResult["location"]["city"].ToString(),
                State = userResult["location"]["state"].ToString(),
                Country = userResult["location"]["country"].ToString(),
                Postcode = userResult["location"]["postcode"].ToString(),
                Latitude = userResult["location"]["coordinates"]["latitude"].ToString(),
                Longitude = userResult["location"]["coordinates"]["longitude"].ToString(),
                TimezoneOffset = userResult["location"]["timezone"]["offset"].ToString(),
                TimezoneDescription = userResult["location"]["timezone"]["description"].ToString(),
                Email = userResult["email"].ToString(),
                LoginUuid = userResult["login"]["uuid"].ToString(),
                LoginUsername = userResult["login"]["username"].ToString(),
                LoginPassword = userResult["login"]["password"].ToString(),
                LoginSalt = userResult["login"]["salt"].ToString(),
                LoginMd5 = userResult["login"]["md5"].ToString(),
                LoginSha1 = userResult["login"]["sha1"].ToString(),
                LoginSha256 = userResult["login"]["sha256"].ToString(),
                DobDate = DateTime.Parse(userResult["dob"]["date"].ToString()),
                DobAge = (int)userResult["dob"]["age"],
                RegisteredDate = DateTime.Parse(userResult["registered"]["date"].ToString()),
                RegisteredAge = (int)userResult["registered"]["age"],
                Phone = userResult["phone"].ToString(),
                Cell = userResult["cell"].ToString(),
                IdName = userResult["id"]["name"].ToString(),
                IdValue = userResult["id"]["value"].ToString(),
                PictureLarge = userResult["picture"]["large"].ToString(),
                PictureMedium = userResult["picture"]["medium"].ToString(),
                PictureThumbnail = userResult["picture"]["thumbnail"].ToString(),
                Nat = userResult["nat"].ToString(),
                Seed = jsonObject["info"]["seed"].ToString(),
                ResultsCount = (int)jsonObject["info"]["results"],
                Page = (int)jsonObject["info"]["page"],
                Version = jsonObject["info"]["version"].ToString()
            };
        }
    }
}
