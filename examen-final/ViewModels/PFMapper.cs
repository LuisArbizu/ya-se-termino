using AppUCA.Entities;

namespace AppUCA.ViewModels
{
    public static class PFMapper
    {
        public static CourseVm MapCourseToCourseVm(Course c)
        {
            return new CourseVm
            {
                Id = c.Id,
                Title = c.Title,
                Modules = c.Modules,
                Topic = c.Topic,
                Author = c.Author,
                Duration = c.Duration,
                Schedule = c.Schedule
            };
        }
        
        public static InscriptionVm MapInscriptionToInscriptionVm(Inscription i)
        {
            return new InscriptionVm()
            {
                Id = i.Id,
                FullName = i.FullName,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber
            };
            
        }
    }
}