using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.ModelImage
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary cloudinary;
        private readonly ImageUploadSettings _options;
        public ImageService(IConfiguration configuration, IOptions<ImageUploadSettings> options)
        {
            _options = options.Value;
            _configuration = configuration;
            cloudinary = new Cloudinary(new Account(
                _options.CloudName,
                _options.APIKey,
                _options.APISecret));
        }

        public async Task<UploadResult> UploadAsync(IFormFile image)
        {
            var pictureSize = Convert.ToInt64(_configuration.GetSection("PhotoSettings:Size").Get<string>());
            if (image.Length > pictureSize)
            {
                throw new ArgumentException("File size exceeded");
            }
            var pictureFormat = false;
            var listOfImageExtensions = _configuration.GetSection("PhotoSettings:Formats").Get<List<string>>();
            foreach (var item in listOfImageExtensions)
            {
                if (image.FileName.EndsWith(item))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (pictureFormat == false)
            {
                throw new ArgumentException("File format not supported");
            }

            var uploadResult = new ImageUploadResult();

            //fetch the image using image stream
            using (var imageStream = image.OpenReadStream())
            {
                string fileName = Guid.NewGuid().ToString() + image.FileName;
                uploadResult = await cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),
                    Transformation = new Transformation().Crop("thumb").Gravity("face").Width(1000).Height(1000).Radius(40)
                });
            }
            return uploadResult;
        }

    }
}
