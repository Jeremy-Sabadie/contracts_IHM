using AMIO_2.entities;
using domain.DTO;
using domain.DTO.DTOrequests;
using domain.DTO.Requests;
using domain.DTO.Responses;
using domain.Entities;
using System.Net.Http.Json;
namespace AMIO_2
{
    public class MaterielApi
    {
        public HttpClient callAPI;

        public object CBcategoyChoice { get; private set; }

        public MaterielApi()
        {
            HttpClient httpClient = new();
            httpClient.BaseAddress = new Uri("http://localhost:5229/api/");
            callAPI = httpClient;
        }

        #region read materiels
        //READ  of the CRUD:
        /// <summary>
        /// Asynchronously retrieves the list of materials from the database.
        /// </summary>
        /// <returns>An asynchronous task that returns a collection of Materiel objects.</returns>
        public async Task<IEnumerable<Materiel>> GetMaterialsAsync()
        {
            try
            {
                HttpClient allMateriels = new HttpClient();
                allMateriels.BaseAddress = new Uri("http://localhost:5229/api/");

                var response = await allMateriels.GetFromJsonAsync<IEnumerable<Materiel>>("materiels");


                return response;
            }

            catch (Exception e)
            {
                return null;

            }
        }

        #endregion
        #region getCategories
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                HttpClient allCategories = new HttpClient();
                allCategories.BaseAddress = new Uri("http://localhost:5229/api/");

                var response = await allCategories.GetFromJsonAsync<IEnumerable<Category>>("materiels/categories");


                return response;
            }

            catch (Exception e)
            {
                return null;

            }
        }

        #endregion
        #region getCategory
        public async Task<IEnumerable<Materiel>> GetMaterielWereCatAsync(int idCat)
        {

            try
            {
                HttpClient request = new HttpClient();
                request.BaseAddress = new Uri($"http://localhost:5229/api/");

                var response = await request.GetFromJsonAsync<IEnumerable<Materiel>>($"materiels/category/{idCat}");


                return response;
            }

            catch (Exception e)
            {
                return null;

            }
        }
        #region create materiel
        public async Task<Materiel> CreateMaterielAsync(Materiel materiel)
        {// New DTOrequest object to map the Materiel object passed as argument to the méthod.
            var requestDTO = new DTOmaterielRequest()
            { //Mapping
                //categories = materiel.categories
                Name = materiel.Name,
                proprietaireId = materiel.ProprietaireId,
                serviceDat = materiel.ServiceDat,
                LastUpdate = materiel.lastUpdate,
                //Selection of the catecories's reference attribute in categories list of the material 
                categories = (materiel.categories is not null) ? materiel.categories.Select(c => c.Reference).ToList() : new List<int>(),
                endGarantee = materiel.EndGarantee
            };
            //Response of the API post material:
            var response = await callAPI.PostAsJsonAsync("materiels", requestDTO);
            //If the response is successful
            if (response.IsSuccessStatusCode)
            {// Read of the Json DTOresponse returned:
                var responseDTO = await response.Content.ReadFromJsonAsync<DTOmaterielResponse>();
                //Création of a new material object to map the DTOresponse values:
                return new Materiel()
                {
                    Id = responseDTO.Id,
                    categories = responseDTO.categories,
                    EndGarantee = responseDTO.EndGarantee,
                    ProprietaireId = responseDTO.proprietaireId,
                    Name = responseDTO.Name,
                    ServiceDat = responseDTO.ServiceDat,
                    lastUpdate = responseDTO.LastUpdate
                };
            }

            var error = await response.Content.ReadAsStringAsync();
            return null;
        }
        #endregion
        #region update materiel
        public async Task<Materiel> UpdateMaterielAsync(Materiel materiel)
        {// New DTOrequest object to map the Materiel object passed as argument to the méthod.
            var requestDTO = new DTOmaterielRequest()
            { //Mapping
                //categories = materiel.categories
                Name = materiel.Name,
                proprietaireId = materiel.ProprietaireId,
                serviceDat = materiel.ServiceDat,
                LastUpdate = materiel.lastUpdate,
                //Selection of the catecories's reference attribute in categories list of the material 
                categories = (materiel.categories is not null) ? materiel.categories.Select(c => c.Reference).ToList() : new List<int>(),
                endGarantee = materiel.EndGarantee
            };
            //Response of the API post material:
            var response = await callAPI.PutAsJsonAsync($"materiels/{materiel.Id}", requestDTO);
            //If the response is successful
            if (response.IsSuccessStatusCode)
            {// Read of the Json DTOresponse returned:
                var responseDTO = await response.Content.ReadFromJsonAsync<DTOmaterielResponse>();
                //Création of a new material object to map the DTOresponse values:
                return new Materiel()
                {
                    Id = responseDTO.Id,
                    categories = responseDTO.categories,
                    EndGarantee = responseDTO.EndGarantee,
                    ProprietaireId = responseDTO.proprietaireId,
                    Name = responseDTO.Name,
                    ServiceDat = responseDTO.ServiceDat,
                    lastUpdate = responseDTO.LastUpdate
                };
            }
            #endregion
            var error = await response.Content.ReadAsStringAsync();
            return null;
        }
        #region delete matériel
        public async Task<bool> DeleteMaterielAsync(int id)
        {
            var response = await callAPI.DeleteAsync($"materiels/{id}");
            return response.IsSuccessStatusCode;

        }

        internal Task DeleteMaterielAsync(object id)
        {
            throw new NotImplementedException();
        }

        #endregion



        #endregion
        #region get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                HttpClient allUsers = new HttpClient();
                allUsers.BaseAddress = new Uri("http://localhost:5229/api/");
                var response = await allUsers.GetFromJsonAsync<IEnumerable<User>>("materiels/users");

                return response;
            }

            catch (Exception e)
            {
                return null;

            }
        }
        #endregion
        public async Task<IEnumerable<Materiel>> GetMaterielByKeyValueAsync(string keyValue)
        {
            try
            {
                HttpClient materiels = new HttpClient();
                materiels.BaseAddress = new Uri("http://localhost:5229/api/");
                var response = await materiels.GetFromJsonAsync<IEnumerable<Materiel>>($"materiels/search?keyValue={keyValue}");

                return response;
            }

            catch (Exception e)
            {
                return null;

            }
        }
        public async Task<IEnumerable<Category>> GetMaterialCategories(int idMat)
        {
            HttpClient materiels = new HttpClient();
            materiels.BaseAddress = new Uri("http://localhost:5229/api/");
            var response = await materiels.GetFromJsonAsync<IEnumerable<Category>>($"materiels/categories/{idMat}");
            return response;
        }
        public async Task<string> UserConnectFromForm(DTOconnectionRequest values)
        {
            var rep = await callAPI.PostAsJsonAsync<DTOconnectionRequest>("user/login", values);


            if (rep.IsSuccessStatusCode)
            {
                string token = (await rep.Content.ReadFromJsonAsync<DTOLoginResponse>()).access_token;
                return token;
            }

            return null;
        }

    }
}