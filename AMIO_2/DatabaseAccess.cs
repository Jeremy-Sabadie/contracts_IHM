//using Dapper;
//using MySql.Data.MySqlClient;
//using System.Net.Http.Json;

//namespace AMIO_2
//{
//    internal class DatabaseAccess
//    {
//        HttpClient httpRequest = new HttpClient();

//        httpRequest.BaseAddress = new Uri("http://localhost:5229/api/");
//        // Instance statique unique  de la classe afin d'autoriser une seule connection à la base de données:

//        private static DatabaseAccess DbInstance = new();
//        private static object _verrou = new();

//        private MySqlConnection _dbconnection;
//        // Constructeur privé Pour que seule la classe puisse l'utiliser.
//        private DatabaseAccess()
//        {
//            // Initialisation de la connexion à la base de données en passant la chaîne de connection à l'objet MySqlConnection:
//            _dbconnection = new MySqlConnection("Server=lab005.2isa.org;Port=33005;Database=filrouge;UID=root;PWD=1365lab005");
//        }
//        // Propriété statique publique qui retourne l'objet d'accès à la base de donnée:
//        //public static DatabaseAccess GetDb()
//        //Vérification lors du getDb:
//        {
//            //Verrouillage de l'objet servant de verrou:
//            //lock (_verrou)
//            //{//S'il n'y a pas déjà d'instance de céée de lobjet de cnnection à la base de donnée, une nouvelle instance est créée:
//            //    if (DbInstance is null)
//            //    {//Création de l'instance:
//            //        DbInstance = new();
//            //    }
//            //    //L'instance est erournée lors du GetDb
//            //    return DbInstance;
//            //}

//        }

//    // Constructeur en privé pour empêcher l'instanciation directe depuis l'extérieur de la classe


//    #region CRUD-read Materiels
//    //READ  of the CRUD:
//    /// <summary>
//    /// Asynchronously retrieves the list of materials from the database.
//    /// </summary>
//    /// <returns>An asynchronous task that returns a collection of Materiel objects.</returns>
//    public async Task<IEnumerable<Materiel>> GetMaterialsAsync()
//    {
//        try
//        {
//            HttpClient allMateriels = new HttpClient();
//            allMateriels.BaseAddress = new Uri("http://localhost:5229/api/");

//            var response = await allMateriels.GetFromJsonAsync<IEnumerable<Materiel>>("materiels");


//            return response;
//        }

//        catch (Exception e)
//        {
//            return null;

//        }
//    }
//    #endregion
//    #region getCategories
//    public async Task<IEnumerable<Category>> GetCategoriesAsync()
//    {
//        try
//        {
//            HttpClient allCategories = new HttpClient();
//            allCategories.BaseAddress = new Uri("http://localhost:5229/api/");

//            var response = await allCategories.GetFromJsonAsync<IEnumerable<Category>>("materiels/categories");


//            return response;
//        }

//        catch (Exception e)
//        {
//            return null;

//        }
//    }
//    #endregion
//    #region getCategory
//    public async Task<IEnumerable<Materiel>> GetMaterielWereCatAsync(int idCat)
//    {

//        try
//        {
//            HttpClient request = new HttpClient();
//            request.BaseAddress = new Uri($"http://localhost:5229/api/");

//            var response = await request.GetFromJsonAsync<IEnumerable<Materiel>>($"materiels/category/{idCat}");


//            return response;
//        }

//        catch (Exception e)
//        {
//            return null;

//        }
//    }
//    #endregion
//    #region CRUD-create
//    //CREATE of the CRUD:
//    /// <summary>
//    /// Adds a new material entry to the database with specified details.
//    /// </summary>
//    /// <param name="name">The name of the material.</param>
//    /// <param name="serviceDat">The service date of the material.</param>
//    /// <param name="endGarantee">The end guarantee date of the material.</param>
//    /// <param name="ownerName">The name of the owner for the material.</param>
//    /// <returns>An asynchronous task returning the ID of the newly inserted material.</returns>
//    public async Task<int> AddMaterialAsync(string name, DateTime serviceDat, DateTime endGarantee, string ownerName)
//    {
//        try
//        {
//            await _dbconnection.OpenAsync();
//            var insertQuery = "INSERT INTO article (name, serviceDat , endGarntee,propriétaireId) VALUES (@name, @endGarntee,@propriétaireId); SELECT LAST_INSERT_ID() ";
//            var result = _dbconnection.Query<int>(insertQuery, new { name });
//            return result.Single();
//        }
//        finally
//        {
//            _dbconnection.Close();
//        }
//    }
//    #endregion
//    //UPDATE of the CRUD:
//    /// <summary>
//    /// Asynchronously deletes a material from the database based on its name and ID.
//    /// </summary>
//    /// <param name="oldName">The current name of the material.</param>
//    /// <param name="oldServiceDat">The current service date of the material.</param>
//    /// <param name="oldEndGarantee">The current end guarantee date of the material.</param>
//    /// <param name="oldProprietaireId">The current owner ID of the material.</param>
//    /// <param name="newName">The new name to be updated.</param>
//    /// <param name="newServiceDat">The new service date to be updated.</param>
//    /// <param name="newEndGarantee">The new end guarantee date to be updated.</param>
//    /// <param name="newProprietaireId">The new owner ID to be updated.</param>
//    /// <returns>The number of rows affected by the update operation.</returns>
//    #region CRUD-update
//    public async int updateMaterial(Materiel materiel)
//    {
//        var response = await request.GetFromJsonAsync<IEnumerable<Materiel>>($"materiels/category/{idCat}");

//    }


//}
//#endregion

//#region CRUD-delete
////TO DO: DELETE for the crud:
///// <summary>
///// Asynchronously deletes a material from the database based on its name and ID.
///// </summary>
///// <param name="name">The name of the material to be deleted.</param>
///// <param name="id">The ID of the material to be deleted.</param>
///// <returns>An asynchronous task that returns an integer representing the number of affected rows.</returns>
//public async Task<int> DeleteMaterielAsync(string name, int id)
//{
//    //Variable contenant la requête pour la suppression de l'article:
//    var deleteQuery = "delete from materiel were id = @id";
//    // Affichage de la boîte de dialogue pour confirmation:

//    try
//    {
//        await _dbconnection.OpenAsync();
//        var res = await _dbconnection.ExecuteAsync(deleteQuery, new { name, id });
//        return res;
//    }
//    finally { await _dbconnection.CloseAsync(); }



//    #endregion

//}
//    // Function to retrive all the categories to be integrated into the combobox choice. 

//}
//}

