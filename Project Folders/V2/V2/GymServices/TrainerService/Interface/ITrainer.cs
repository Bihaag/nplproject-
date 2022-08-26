using GymServices.TrainerService.Model;

namespace GymServices.TrainerService.Interface
{
    public interface ITrainer
    {
        void InsertUser(TrainerModel TrainerModel);

        string GetApps();

        string GetTrainer(string email);
    }
}
