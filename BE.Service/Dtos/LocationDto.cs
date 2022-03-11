using BE.Service.Exceptions;
using BE.Service.Interfaces;

namespace BE.Service.Dtos
{
    public class LocationDto : IDtoValidator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            this.Name.ThrowIfEmpty();
        }

        public void ValidateForUpdate()
        {
            this.Validate();
        }
    }
}
