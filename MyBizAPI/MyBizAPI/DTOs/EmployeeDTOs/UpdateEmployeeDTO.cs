﻿using FluentValidation;

namespace MyBizAPI.DTOs.BookDTOs
{
    public class UpdateEmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public int PositionId { get; set; }
        public string RedirectUrl { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class UpdateEmployeeDTOValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        public UpdateEmployeeDTOValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(200).MinimumLength(3);
            RuleFor(x => x.PositionId).NotNull().NotEmpty();
            RuleFor(x => x.RedirectUrl).NotNull().NotEmpty();
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageFile.ContentType != "image/png" && x.ImageFile.ContentType != "image/jpeg")
                {
                    context.AddFailure("ImageFile", "Must be in png or jpeg format");
                }
                if (x.ImageFile.Length > 1048576)
                {
                    context.AddFailure("ImageFile", "The file size is incorrect");
                }

            });
        }
    }
}
