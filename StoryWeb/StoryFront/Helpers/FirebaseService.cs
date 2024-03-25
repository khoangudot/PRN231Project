using System;
using System.IO;
using Firebase.Storage;
using ObjectModel.Dtos;

namespace StoryFront.Helpers
{
	public static class FirebaseService
	{
		public async static Task<string> CreateImage(IFormFile file, params string[] folder)
		{
            FirebaseStorage storage = new FirebaseStorage("fir-react-87033.appspot.com");
            string filename = Guid.NewGuid() + ".jpg";
            var stream = file.OpenReadStream();
            string folderPath = string.Join("/", folder);
            var task = await storage.Child(folderPath)
                              .Child(filename)
                              .PutAsync(stream);
            UriBuilder uriBuilder = new UriBuilder(task.ToString());
            Uri uri = uriBuilder.Uri;
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            queryParams.Remove("token");
            uriBuilder.Query = queryParams.ToString();
            return uriBuilder.ToString();
        }

        public async static Task EditImage(IFormFile file, string pathImage, params string[] folder)
        {
            string correctedPathImage = pathImage.TrimEnd('/'); // Loại bỏ dấu '/' ở cuối đường dẫn
            UriBuilder uriBuilder = new UriBuilder(correctedPathImage);
            Uri uri = uriBuilder.Uri;
            string nameImage = System.IO.Path.GetFileName(uri.LocalPath);
            FirebaseStorage storage = new FirebaseStorage("fir-react-87033.appspot.com");
            var stream = file.OpenReadStream();
            string folderPath = string.Join("/", folder);
            var task = await storage.Child(folderPath)
                              .Child(nameImage)
                              .PutAsync(stream);
        }


        public async static Task DeleteImage(string pathImage, params string[] folder)
        {
            UriBuilder uriBuilder = new UriBuilder(pathImage);
            Uri uri = uriBuilder.Uri;
            string nameImage = System.IO.Path.GetFileName(uri.LocalPath);
            FirebaseStorage storage = new FirebaseStorage("fir-react-87033.appspot.com");
            string folderPath = string.Join("/", folder);
            await storage.Child(folderPath)
                              .Child(nameImage)
                              .DeleteAsync();
        }
	}
}

