using GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GUI
{
    public class ImageController
    {
        private List<ImageModel> _imageCollection;
        public ImageModel SelectedImage;

        /// <summary>
        /// Initializes a new instance of the ImageController class.
        /// </summary>
        public ImageController()
        {
            _imageCollection = new List<ImageModel>();
        }
        /// <summary>
        /// Loads the images from the specified file names into the image collection.
        /// Only PNG files are loaded.
        /// </summary>
        public void LoadImages(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                if (Path.GetExtension(fileName).ToLower() == ".png")
                {
                    ImageModel imageModel = new ImageModel
                    {
                        Image = new Bitmap(fileName),
                        FileName = Path.GetFileName(fileName)
                    };

                    _imageCollection.Add(imageModel);
                }
            }
        }
        /// <summary>
        /// Retrieves the thumbnails of all the images in the image collection.
        /// </summary>
        /// <returns>A list of thumbnail images.</returns>
        public List<Image> GetImageThumbnails()
        {
            List<Image> thumbnails = new List<Image>();

            foreach (ImageModel imageModel in _imageCollection)
            {
                thumbnails.Add(imageModel.Image);
            }

            return thumbnails;
        }
        /// <summary>
        /// Selects the image with the specified file name from the image collection.
        /// </summary>
        /// <param name="fileName">The file name of the image to select.</param>
        public void SelectImage(string fileName)
        {
            SelectedImage = _imageCollection.Find(image => image.FileName == fileName);
        }
        /// <summary>
        /// Sets the selected image to the specified ImageModel.
        /// </summary>
        /// <param name="imageModel">The ImageModel to set as the selected image.</param>
        public void SetSelectedImage(ImageModel imageModel)
        {
            SelectedImage = imageModel;
        }
        /// <summary>
        /// Rotates the selected image 90 degrees clockwise.
        /// </summary>
        public void RotateImage()
        {
            if (SelectedImage != null)
            {
                SelectedImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }
        /// <summary>
        /// Flips the selected image horizontally.
        /// </summary>
        public void FlipImage()
        {
            if (SelectedImage != null)
            {
                SelectedImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }
        /// <summary>
        /// Saves the selected image to the specified file path.
        /// </summary>
        /// <param name="fileName">The file path to save the image.</param>
        public void SaveImage(string fileName)
        {
            if (SelectedImage != null)
            {
                SelectedImage.Image.Save(fileName);
            }
        }
        /// <summary>
        /// Retrieves the selected image.
        /// </summary>
        /// <returns>The selected ImageModel.</returns>
        public ImageModel GetSelectedImage()
        {
            return SelectedImage;
        }
        /// <summary>
        /// Retrieves the collection of all images.
        /// </summary>
        /// <returns>A list of ImageModel objects representing the image collection.</returns>
        public List<ImageModel> GetImageCollection()
        {
            return _imageCollection;
        }
    }
}
