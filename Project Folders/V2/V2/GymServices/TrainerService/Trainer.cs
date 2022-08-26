using GymServices.TrainerService.Interface;
using GymServices.TrainerService.Model;

namespace GymServices.TrainerService
{
    public class Trainer : ITrainer
    {
        SqlHelper sqlHelper = new SqlHelper("server=tcp:nplappserver.database.windows.net,1433;Initial Catalog=nplDB;Persist Security Info=False;User ID=npladmin;Password=NPLgym007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        public void InsertUser(TrainerModel TrainerModel)
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC InsertTrainer '{TrainerModel.TrainerName}','{TrainerModel.Meta}','{TrainerModel.Date}','{TrainerModel.Location}','{TrainerModel.Duration}','{TrainerModel.Extras}','{TrainerModel.Email}'");
        }

        public string GetApps()
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Trainer");
            return output;
        }

        public string GetTrainer(string email)
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Trainer WHERE Email = '{email}'");
            return output;
        }
    }
}
