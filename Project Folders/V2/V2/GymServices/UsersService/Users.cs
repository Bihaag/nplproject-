using GymServices.UsersService.Model;

namespace GymServices.UsersService
{
    public class Users : IUsers
    {
        SqlHelper sqlHelper = new SqlHelper("server=tcp:nplappserver.database.windows.net,1433;Initial Catalog=nplDB;Persist Security Info=False;User ID=npladmin;Password=NPLgym007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public string GetAllUser() 
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Users");
            return output;
        }

        public void InsertUser(UsersModel UsersModel) 
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC CreateUser '{UsersModel.Email}','{UsersModel.Password}','{UsersModel.Meta}'");
           

        }

        public void UpdateUser(UsersModel UsersModel) 
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC UpdateUser '{UsersModel.Email}','{UsersModel.Meta}'");
        }

        public string GetUserPasswordFromEmail(string email) 
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT Password FROM Users WHERE Email = '{email}'");
            return output;
        }

        public string GetUserData(string email)
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Users WHERE Email = '{email}'");
            return output;
        }

        public void UpdateUserCourse(UsersCourseModel UsersCourseModel)
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC UpdateUserPlan '{UsersCourseModel.Email}','{UsersCourseModel.C1}','{UsersCourseModel.C2}','{UsersCourseModel.C3}','{UsersCourseModel.DietPlan}'");
        }
    }
}
