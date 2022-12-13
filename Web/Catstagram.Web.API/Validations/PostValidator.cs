using Catstagram.Data.Configurations.Constants;
using Catstagram.Services.Data.Models;
using FluentValidation;

namespace Catstagram.Web.API.Validations
{
    public class PostValidator : AbstractValidator<PostInputModel>
    {
        public PostValidator()
        {
            RuleFor(x => x.Caption).NotEmpty().Length(1, ConfigurationConstants.PostCaptionMaxLength);
        }
    }
}
