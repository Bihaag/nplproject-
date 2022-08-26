using GymServices.UsersService.Model;

namespace GymServices.UsersService
{
    public interface IUsers
    {
        string GetAllUser();
        void InsertUser(UsersModel UsersModel);
        void UpdateUser(UsersModel UsersModel);
        string GetUserPasswordFromEmail(string email);
        void UpdateUserCourse(UsersCourseModel UsersCourseModel);
        string GetUserData(string email);
    }
}
